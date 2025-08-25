// <copyright file="InicioSesion.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PBAPP.Herramientas;
using PBAPP.Modelos;
using PBAPP.Modelos.Login;
using PBAPP.Valores;

namespace PBAPP.Controladores
{
    public class InicioSesion : Controller
    {
        private readonly HttpClient httpClient;

        private readonly ManejoSesion manejoSesion;

        public InicioSesion(ManejoSesion manejoSesion, IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.manejoSesion = manejoSesion;
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            string? token = string.Empty;
            try
            {
                token = this.manejoSesion.Obtener<string>("token_Peticiones");

                if (!string.IsNullOrEmpty(token))
                {
                    return this.RedirectToAction("Dashboard", "Inicio");
                }
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), token);
            }

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> IniciarSesion(InicioSesionRequest parametros)
        {
            HttpResponseMessage response;
            Root respuesta = new();
            try
            {
                response = await this.httpClient.PostAsJsonAsync(Constantes.Dominio + RutasAPI.RutaLogin, parametros);
                string json = string.Empty;

                JsonSerializerOptions? options = null;
                if (!response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    RespuestaError mensaje = new();

                    options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    mensaje = JsonSerializer.Deserialize<RespuestaError>(
                        json,
                        options) ?? new RespuestaError();

                    this.ViewBag.Mensaje = $"Error: {(int)response.StatusCode} - {mensaje?.message}";

                    return this.View();
                }

                json = await response.Content.ReadAsStringAsync();

                options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                respuesta = JsonSerializer.Deserialize<Root>(
                    json,
                    options) ?? new Root();

                this.ViewBag.Mensaje = $"Éxito: {(int)response.StatusCode} - {response.StatusCode}";

                this.manejoSesion.Agregar("token_Peticiones", respuesta.Result.AccessToken);
                return this.RedirectToAction("Dashboard", "Inicio");
            }
            catch (Exception ex)
            {
                this.ViewBag.Mensaje = $"Ha ocurrido un error interno";
                Excepcion.BitacoraErrores(ex.ToString(), parametros);
            }

            return this.View(respuesta);
        }
    }
}
