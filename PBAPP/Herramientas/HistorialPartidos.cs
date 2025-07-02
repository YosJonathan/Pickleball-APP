using PBAPP.Modelos.HistorialPartidos;

namespace PBAPP.Herramientas
{
    public class HistorialPartidos
    {
        /// <summary>
        /// Llenar parametros para obtener el historial.
        /// </summary>
        /// <param name="limite">Limite de registros.</param>
        /// <returns>Lista de historial.</returns>
        public static HistorialPartidosRequest LlenarParametrosHistorial(int limite = 25)
        {
            limite = limite > 25 ? 25 : limite;
            HistorialPartidosRequest respuesta = new()
            {
                Filters = null,
                Limit = limite,
                Offset = 0
            };

            respuesta.Sort.Order = "DESC";
            respuesta.Sort.Parameter = "MATCH_DATE";

            return respuesta;
        }

        internal static List<HistorialPorMapa> GenerarLugaresPartidos(HistorialPartidosResponse historialPartidos)
        {
            List<HistorialPorMapa> historial = [.. historialPartidos.Result.Hits
            .GroupBy(hit => hit.Location)
            .Select(grupo => new HistorialPorMapa
            {
                Lugar = grupo.Key,
                Evento = [.. grupo
                    .Select(x => x.EventName)
                    .Where(e => !string.IsNullOrWhiteSpace(e))
                    .Distinct()],
                Partidos = grupo.Count(),
                Latencia = 0, // puedes dejarlo así por ahora
                Longitud = 0
            })];

            return historial;
        }
    }
}
