using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PBAPP.Filtros;
using PBAPP.Herramientas;
using PBAPP.Modelos;
using PBAPP.Modelos.Login;
using PBAPP.Valores;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PBAPP.Controladores
{
    public class InicioController : Controller
    {

        private readonly ManejoSesion _manejoSesion;

        private readonly HttpClient _httpClient;
        public InicioController(ManejoSesion manejoSesion, IHttpClientFactory httpClientFactory)
        {
            _manejoSesion = manejoSesion;
            _httpClient = httpClientFactory.CreateClient();
        }

        [TieneToken()]
        public async Task<IActionResult> Dashboard()
        {
            string? token = string.Empty;

            try
            {
                token = this._manejoSesion.Obtener<string>("token_Peticiones");
                if (string.IsNullOrEmpty(token))
                {
                    Excepcion.BitacoraErrores("Token vacio", token);
                    return this.View();
                } 

                PerfilUsuario infoUsuario = new PerfilUsuario();

                infoUsuario = await API.ConsumirApiAsync<object, PerfilUsuario>(_httpClient, RutasAPI.rutaPerfil, token, HttpMethod.Get);

                if (infoUsuario == null)
                {
                    Excepcion.BitacoraErrores("Información del usuario es nulo", RutasAPI.rutaPerfil);
                    return this.View();
                }

                this.ViewData["infoPerfil"] = infoUsuario;

                long idUsuario = infoUsuario.Result.Id;

                EstadisticasUsuarioCalculado estadisticasUsuario = new EstadisticasUsuarioCalculado();
                estadisticasUsuario = await API.ConsumirApiAsync<object, EstadisticasUsuarioCalculado>
                    (_httpClient, RutasAPI.rutaEstadisticasUsuario(idUsuario), token, HttpMethod.Get);
                if (estadisticasUsuario == null)
                {
                    Excepcion.BitacoraErrores("Estadisticas del usuario es nulo", RutasAPI.rutaPerfil);
                    return this.View();
                }

                this.ViewData["estadisticasCalculadas"] = estadisticasUsuario;

            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), token);
            }

            return this.View();
        }
    }
}
