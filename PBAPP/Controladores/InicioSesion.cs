using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBAPP.Herramientas;
using PBAPP.Modelos;
using PBAPP.Modelos.Login;
using PBAPP.Valores;
using System;
using System.Text.Json;

namespace PBAPP.Controladores
{
    public class InicioSesion : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly ManejoSesion _manejoSesion;

        public InicioSesion(ManejoSesion manejoSesion, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _manejoSesion = manejoSesion;
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {

            string? token = string.Empty;
            try
            {
                token = this._manejoSesion.Obtener<string>("token_Peticiones");

                if (!string.IsNullOrEmpty(token))
                {
                    return this.RedirectToAction("Dashboard", "Inicio");
                }
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), token);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> IniciarSesion(InicioSesionRequest parametros)
        {
            HttpResponseMessage response;
            Root respuesta = new();
            try
            {
                response = await _httpClient.PostAsJsonAsync(Constantes.Dominio + RutasAPI.rutaLogin, parametros);
                string json = string.Empty;

                if (!response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    RespuestaErrorLogin mensaje = new RespuestaErrorLogin();

                    mensaje = JsonSerializer.Deserialize<RespuestaErrorLogin>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
                    ViewBag.Mensaje = $"Error: {(int)response.StatusCode} - {mensaje?.message}";

                    return this.View();
                }

                json = await response.Content.ReadAsStringAsync();

                respuesta = JsonSerializer.Deserialize<Root>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                ViewBag.Mensaje = $"Éxito: {(int)response.StatusCode} - {response.StatusCode}";

                _manejoSesion.Agregar("token_Peticiones", respuesta.Result.AccessToken);
                return this.RedirectToAction("Dashboard", "Inicio");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Ha ocurrido un error interno";
                Excepcion.BitacoraErrores(ex.ToString(), parametros);
            }

            return this.View(respuesta);
        }
    }
}
