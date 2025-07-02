// <copyright file="InicioController.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Threading;
using Microsoft.AspNetCore.Mvc;
using PBAPP.Filtros;
using PBAPP.Herramientas;
using PBAPP.Modelos;
using PBAPP.Modelos.ClubsTodos;
using PBAPP.Modelos.HistorialPartidos;
using PBAPP.Modelos.RatingUsuario;
using PBAPP.Modelos.SeguidoresUsuario;
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

                var estadisticasUsuario = API.ConsumirApiAsync<object, EstadisticasUsuarioCalculado>(
                                    this.httpClient, RutasAPI.RutaEstadisticasUsuario(idUsuario), token, HttpMethod.Get);

                var clubsUsuario = API.ConsumirApiAsync<object, TodosClubsResponse>(
                    this.httpClient, RutasAPI.RutaClubs, token, HttpMethod.Get);

                var seguidoresUsuario = API.ConsumirApiAsync<object, SeguidoresUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaSeguidoresUsuario(idUsuario), token, HttpMethod.Get);

                var ratingSinglesUsuario = API.ConsumirApiAsync<RatingUsuarioRequest, RatingUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaHistorialRatingUsuario(idUsuario), token, HttpMethod.Post, Rating.LlenarRatingMensual(DateTime.Now, "SINGLES"));

                var ratingDoublesUsuario = API.ConsumirApiAsync<RatingUsuarioRequest, RatingUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaHistorialRatingUsuario(idUsuario), token, HttpMethod.Post, Rating.LlenarRatingMensual(DateTime.Now, "DOUBLES"));

                var historialPartidosUsuario = API.ConsumirApiAsync<HistorialPartidosRequest, HistorialPartidosResponse>(
                    this.httpClient, RutasAPI.RutaHistorialPartidosUsuario(idUsuario), token, HttpMethod.Post, HistorialPartidos.LlenarParametrosHistorial());

                await Task.WhenAll(estadisticasUsuario, clubsUsuario, seguidoresUsuario, ratingSinglesUsuario, ratingDoublesUsuario, historialPartidosUsuario);

                var estadisticas = await estadisticasUsuario;
                var clubs = await clubsUsuario;
                var seguidores = await seguidoresUsuario;
                var ratingSingles = await ratingSinglesUsuario;
                var ratingDoubles = await ratingDoublesUsuario;
                var historialPartidos = await historialPartidosUsuario;

                if (estadisticas == null)
                {
                    Excepcion.BitacoraErrores("Estadisticas del usuario es nulo", RutasAPI.RutaEstadisticasUsuario);
                    return this.View();
                }

                this.ViewData["estadisticasCalculadas"] = estadisticas;

                if (clubs == null)
                {
                    Excepcion.BitacoraErrores("Clubes del usuario es nulo", RutasAPI.RutaClubs);
                    return this.View();
                }

                this.ViewData["clubesUsuario"] = clubs;

                if (seguidores == null)
                {
                    Excepcion.BitacoraErrores("Seguidores del usuario es nulo", RutasAPI.RutaSeguidoresUsuario);
                    return this.View();
                }

                this.ViewData["seguidoresUsuario"] = seguidores;

                if (double.TryParse(infoUsuario.Result.Stats.Singles, out double singles))
                {
                    singles = 0;
                }

                if (double.TryParse(infoUsuario.Result.Stats.Doubles, out double doubles))
                {
                    doubles = 0;
                }

                List<RatingPorFecha> ratingPorFechas = Rating.GenerarHistorialGrafica(ratingSingles, ratingDoubles, singles, doubles);
                this.ViewData["RatingPorMes"] = ratingPorFechas;

                List<HistorialPorMapa> historial = HistorialPartidos.GenerarLugaresPartidos(historialPartidos);
                this.ViewData["HistorialLugaresPartidos"] = historial;
                this.ViewData["HistorialPartidos"] = historialPartidos;
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), token);
            }

            return this.View();
        }
    }
}
