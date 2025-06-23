// <copyright file="InicioController.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using PBAPP.Filtros;
using PBAPP.Herramientas;
using PBAPP.Modelos;
using PBAPP.Modelos.ClubsTodos;
using PBAPP.Valores;

namespace PBAPP.Controladores
{
    public class InicioController(ManejoSesion manejoSesion, IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly ManejoSesion manejoSesion = manejoSesion;

        private readonly HttpClient httpClient = httpClientFactory.CreateClient();

        [TieneToken]
        public async Task<IActionResult> Dashboard()
        {
            string? token = string.Empty;

            try
            {
                token = this.manejoSesion.Obtener<string>("token_Peticiones");
                if (string.IsNullOrEmpty(token))
                {
                    Excepcion.BitacoraErrores("Token vacio", token);
                    return this.View();
                }

                PerfilUsuario infoUsuario = new();

                infoUsuario = await API.ConsumirApiAsync<object, PerfilUsuario>(this.httpClient, RutasAPI.RutaPerfil, token, HttpMethod.Get);

                if (infoUsuario == null)
                {
                    Excepcion.BitacoraErrores("Información del usuario es nulo", RutasAPI.RutaPerfil);
                    return this.View();
                }

                this.ViewData["infoPerfil"] = infoUsuario;

                long idUsuario = infoUsuario.Result.Id;

                EstadisticasUsuarioCalculado estadisticasUsuario = new();
                estadisticasUsuario = await API.ConsumirApiAsync<object, EstadisticasUsuarioCalculado>(
                    this.httpClient, RutasAPI.RutaEstadisticasUsuario(idUsuario), token, HttpMethod.Get);
                if (estadisticasUsuario == null)
                {
                    Excepcion.BitacoraErrores("Estadisticas del usuario es nulo", RutasAPI.RutaEstadisticasUsuario);
                    return this.View();
                }

                this.ViewData["estadisticasCalculadas"] = estadisticasUsuario;

                TodosClubsResponse clubsUsuario = new();
                clubsUsuario = await API.ConsumirApiAsync<object, TodosClubsResponse>(
                    this.httpClient, RutasAPI.RutaClubs, token, HttpMethod.Get);
                if (clubsUsuario == null)
                {
                    Excepcion.BitacoraErrores("Clubes del usuario es nulo", RutasAPI.RutaClubs);
                    return this.View();
                }

                this.ViewData["clubesUsuario"] = clubsUsuario;
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), token);
            }

            return this.View();
        }
    }
}
