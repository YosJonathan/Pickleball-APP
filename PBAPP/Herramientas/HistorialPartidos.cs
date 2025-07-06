using PBAPP.Modelos.HistorialPartidos;
using PBAPP.Repositorio;
using PBAPP.Servicios;
using System.Threading.Tasks;

namespace PBAPP.Herramientas
{
    public class HistorialPartidos
    {
        /// <summary>
        /// Llenar parametros para obtener el historial.
        /// </summary>
        /// <param name="limite">Limite de registros.</param>
        /// <returns>Lista de historial.</returns>
        public static HistorialPartidosRequest LlenarParametrosHistorial(int limite = 25, int offset = 0)
        {
            limite = limite > 25 ? 25 : limite;
            HistorialPartidosRequest respuesta = new()
            {
                Filters = null,
                Limit = limite,
                Offset = offset
            };

            respuesta.Sort.Order = "DESC";
            respuesta.Sort.Parameter = "MATCH_DATE";

            return respuesta;
        }

        internal static async Task<List<HistorialPorMapa>> GenerarLugaresPartidos(HistorialPartidosResponse historialPartidos)
        {
            List<HistorialPorMapa> historial = [.. historialPartidos.Result.Hits
            .GroupBy(hit => hit.Location)
            .Select(grupo => new HistorialPorMapa
            {
                Lugar = grupo.Key,
                Latencia = 0, // puedes dejarlo así por ahora
                Longitud = 0
            })];

            foreach (var item in historial)
            {
                var resultado = SitioRepositorio.BuscarSitiosPorLugar(item.Lugar);

                if (string.IsNullOrEmpty(item.Lugar))
                {
                    Console.WriteLine($"Lugar vacio: {item.Lugar}");
                }
                else
                {
                    if (resultado.Count == 0)
                    {
                        Console.WriteLine($"No existe registro para: {item.Lugar}");
                        HistorialPorMapa? geolocalizacion = await Geolocalizacion.ObtenerCoordenadasAsync(item.Lugar);
                        if (geolocalizacion != null)
                        {
                            SitioRepositorio.AgregarSitio(geolocalizacion);

                            Console.WriteLine($"Registro encontrado y guardado para: {item.Lugar}");
                        }
                        else
                        {
                            Console.WriteLine($"Geolocalizacion es nula: {item.Lugar}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Existe registro para: {item.Lugar}");
                    }

                }
            }

            return historial;
        }
    }
}
