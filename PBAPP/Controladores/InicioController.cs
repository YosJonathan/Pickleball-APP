// <copyright file="InicioController.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PBAPP.Filtros;
using PBAPP.Herramientas;
using PBAPP.Modelos;
using PBAPP.Modelos.ClubsTodos;
using PBAPP.Modelos.HistorialPartidos;
using PBAPP.Modelos.Perfil;
using PBAPP.Modelos.RatingUsuario;
using PBAPP.Modelos.SeguidoresUsuario;
using PBAPP.Repositorio;
using PBAPP.Valores;
using static System.Reflection.Metadata.BlobBuilder;

namespace PBAPP.Controladores
{
    public class InicioController : Controller
    {
        private readonly ManejoSesion manejoSesion;

        private readonly HttpClient httpClient;

        public InicioController(ManejoSesion manejoSesion, IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.manejoSesion = manejoSesion;
        }

        [TieneToken]
        public async Task<IActionResult> Dashboard()
        {
            string? token = string.Empty;

            try
            {
                token = this.manejoSesion.Obtener<string>("token_Peticiones");

                PerfilUsuario infoUsuario = new();

                infoUsuario = await API.ConsumirApiAsync<object, PerfilUsuario>(this.httpClient, RutasAPI.RutaPerfil, token ?? string.Empty, HttpMethod.Get);

                if (infoUsuario == null)
                {
                    Excepcion.BitacoraErrores("Información del usuario es nulo", RutasAPI.RutaPerfil);
                    return this.View();
                }

                if (infoUsuario.Result.Addresses.Count > 0)
                {
                    Address direccion = infoUsuario.Result.Addresses[0];
                    if (!SitioRepositorio.ExisteSitioPorLugar(direccion.ShortAddress))
                    {
                        HistorialPorMapa nuevo = new()
                        {
                            Lugar = direccion.ShortAddress,
                            Latencia = direccion.Latitude,
                            Longitud = direccion.Longitude
                        };
                        SitioRepositorio.AgregarSitio(nuevo);
                    }
                }

                long idUsuario = infoUsuario.Result.Id;

                var estadisticasUsuario = API.ConsumirApiAsync<object, EstadisticasUsuarioCalculado>(
                                    this.httpClient, RutasAPI.RutaEstadisticasUsuario(idUsuario), token ?? string.Empty, HttpMethod.Get);

                var clubsUsuario = API.ConsumirApiAsync<object, TodosClubsResponse>(
                    this.httpClient, RutasAPI.RutaClubs, token ?? string.Empty, HttpMethod.Get);

                var seguidoresUsuario = API.ConsumirApiAsync<object, SeguidoresUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaSeguidoresUsuario(idUsuario), token ?? string.Empty, HttpMethod.Get);

                var ratingSinglesUsuario = API.ConsumirApiAsync<RatingUsuarioRequest, RatingUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaHistorialRatingUsuario(idUsuario), token ?? string.Empty, HttpMethod.Post, Rating.LlenarRatingMensual(DateTime.Now, "SINGLES"));

                var ratingDoublesUsuario = API.ConsumirApiAsync<RatingUsuarioRequest, RatingUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaHistorialRatingUsuario(idUsuario), token ?? string.Empty, HttpMethod.Post, Rating.LlenarRatingMensual(DateTime.Now, "DOUBLES"));

                var historialPartidosUsuario = API.ConsumirApiAsync<HistorialPartidosRequest, HistorialPartidosResponse>(
                    this.httpClient, RutasAPI.RutaHistorialPartidosUsuario(idUsuario), token ?? string.Empty, HttpMethod.Post, HistorialPartidos.LlenarParametrosHistorial());

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

                PerfilInformacionUsuario informacionUsuario = new()
                {
                    DashBoard = true,
                    PerfilUsuario = infoUsuario,
                    Seguidores = seguidores
                };

                this.ViewData["informacionUsuario"] = informacionUsuario;

                if (!double.TryParse(infoUsuario.Result.Stats.Singles, out double singles))
                {
                    singles = 0;
                }

                if (!double.TryParse(infoUsuario.Result.Stats.Doubles, out double doubles))
                {
                    doubles = 0;
                }

                List<RatingPorFecha> ratingPorFechas = Rating.GenerarHistorialGrafica(ratingSingles, ratingDoubles, singles, doubles);
                this.ViewData["RatingPorMes"] = ratingPorFechas;

                //List<HistorialPorMapa> historial = await HistorialPartidos.GenerarLugaresPartidos(historialPartidos);
                //this.ViewData["HistorialLugaresPartidos"] = historial;
                this.ViewData["HistorialPartidos"] = historialPartidos;
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), token);
            }

            return this.View();
        }

        [TieneToken]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ObtenerTrofeos()
        {
            var resultado = new { Partidos = 0 };
            string? token = string.Empty;

            try
            {
                token = this.manejoSesion.Obtener<string>("token_Peticiones");
                Console.WriteLine(token);
                PerfilUsuario infoUsuario = new();

                infoUsuario = await API.ConsumirApiAsync<object, PerfilUsuario>(this.httpClient, RutasAPI.RutaPerfil, token ?? string.Empty, HttpMethod.Get);

                if (infoUsuario == null)
                {
                    Excepcion.BitacoraErrores("Información del usuario es nulo", RutasAPI.RutaPerfil);
                    return this.View();
                }

                long idUsuario = infoUsuario.Result.Id;

                int totalRegistros = 42; // Puedes traer este número de la API si lo tienes
                int pageSize = 25;
                int totalPaginas = (int)Math.Ceiling((double)totalRegistros / pageSize);

                var tareas = new List<Task<HistorialPartidosResponse>>();

                for (int page = 0; page < totalPaginas; page++)
                {
                    int offset = pageSize * page;

                    var tarea = API.ConsumirApiAsync<HistorialPartidosRequest, HistorialPartidosResponse>(
                        this.httpClient,
                        RutasAPI.RutaHistorialPartidosUsuario(idUsuario),
                        token ?? string.Empty,
                        HttpMethod.Post,
                        HistorialPartidos.LlenarParametrosHistorial(25, offset));

                    tareas.Add(tarea);
                }

                // Ejecutar todas las tareas en paralelo
                var resultados = await Task.WhenAll(tareas);

                // Combinar todos los partidos en una sola lista
                var todosLosPartidos = resultados
                    .Where(r => r != null && r.Result.Hits != null)
                    .SelectMany(r => r.Result.Hits)
                    .DistinctBy(p => p.DisplayIdentity)
                    .ToList();

                resultado = new { Partidos = todosLosPartidos.Count };
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), new { });
                throw;
            }

            return this.Json(resultado);
        }

        [TieneToken]
        public async Task<ActionResult> Perfil(long perfil)
        {
            try
            {
                string? token = this.manejoSesion.Obtener<string>("token_Peticiones");

                var informacionPerfilExterno = API.ConsumirApiAsync<object, PerilUsuarioExterno>(
                                    this.httpClient, RutasAPI.RutaPerfilUsuario(perfil), token ?? string.Empty, HttpMethod.Get);

                var estadisticasUsuario = API.ConsumirApiAsync<object, EstadisticasUsuarioCalculado>(
                                    this.httpClient, RutasAPI.RutaEstadisticasUsuario(perfil), token ?? string.Empty, HttpMethod.Get);

                var seguidoresUsuario = API.ConsumirApiAsync<object, SeguidoresUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaSeguidoresUsuario(perfil), token ?? string.Empty, HttpMethod.Get);

                var ratingSinglesUsuario = API.ConsumirApiAsync<RatingUsuarioRequest, RatingUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaHistorialRatingUsuario(perfil), token ?? string.Empty, HttpMethod.Post, Rating.LlenarRatingMensual(DateTime.Now, "SINGLES"));

                var ratingDoublesUsuario = API.ConsumirApiAsync<RatingUsuarioRequest, RatingUsuarioResponse>(
                    this.httpClient, RutasAPI.RutaHistorialRatingUsuario(perfil), token ?? string.Empty, HttpMethod.Post, Rating.LlenarRatingMensual(DateTime.Now, "DOUBLES"));

                var historialPartidosUsuario = API.ConsumirApiAsync<HistorialPartidosRequest, HistorialPartidosResponse>(
                    this.httpClient, RutasAPI.RutaHistorialPartidosUsuario(perfil), token ?? string.Empty, HttpMethod.Post, HistorialPartidos.LlenarParametrosHistorial());

                await Task.WhenAll(estadisticasUsuario, seguidoresUsuario, ratingSinglesUsuario, ratingDoublesUsuario, historialPartidosUsuario, informacionPerfilExterno);

                var estadisticas = await estadisticasUsuario;
                var seguidores = await seguidoresUsuario;
                var ratingSingles = await ratingSinglesUsuario;
                var ratingDoubles = await ratingDoublesUsuario;
                var historialPartidos = await historialPartidosUsuario;
                var infoUsuario = await informacionPerfilExterno;

                if (infoUsuario == null)
                {
                    Excepcion.BitacoraErrores("Información del usuario es nulo", RutasAPI.RutaPerfilUsuario(perfil));
                    return this.View();
                }

                this.ViewData["infoPerfil"] = infoUsuario;

                if (estadisticas == null)
                {
                    Excepcion.BitacoraErrores("Estadisticas del usuario es nulo", RutasAPI.RutaEstadisticasUsuario);
                    return this.View();
                }

                this.ViewData["estadisticasCalculadas"] = estadisticas;

                if (seguidores == null)
                {
                    Excepcion.BitacoraErrores("Seguidores del usuario es nulo", RutasAPI.RutaSeguidoresUsuario);
                    return this.View();
                }

                PerfilInformacionUsuario informacionUsuario = new()
                {
                    DashBoard = false,
                    PerfilUsuarioExterno = infoUsuario,
                    Seguidores = seguidores
                };

                this.ViewData["informacionUsuario"] = informacionUsuario;

                if (!double.TryParse(infoUsuario.Result.Ratings.Singles, out double singles))
                {
                    singles = 0;
                }

                if (!double.TryParse(infoUsuario.Result.Ratings.Doubles, out double doubles))
                {
                    doubles = 0;
                }

                List<RatingPorFecha> ratingPorFechas = Rating.GenerarHistorialGrafica(ratingSingles, ratingDoubles, singles, doubles);
                this.ViewData["RatingPorMes"] = ratingPorFechas;

                //List<HistorialPorMapa> historial = await HistorialPartidos.GenerarLugaresPartidos(historialPartidos);
                //this.ViewData["HistorialLugaresPartidos"] = historial;
                this.ViewData["HistorialPartidos"] = historialPartidos;
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), new { });
            }

            return this.View();
        }

        [TieneToken]
        public async Task<ActionResult> Mapa()
        {
            PerfilUsuario infoUsuario = new();
            string? token;
            try
            {
                token = this.manejoSesion.Obtener<string>("token_Peticiones");
                Console.WriteLine(token);

                infoUsuario = await API.ConsumirApiAsync<object, PerfilUsuario>(this.httpClient, RutasAPI.RutaPerfil, token ?? string.Empty, HttpMethod.Get);

                if (infoUsuario == null)
                {
                    Excepcion.BitacoraErrores("Información del usuario es nulo", RutasAPI.RutaPerfil);
                    return this.View();
                }
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), infoUsuario);
            }

            return this.View();
        }
    }
}
