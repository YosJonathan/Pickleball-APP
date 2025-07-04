using PBAPP.Modelos.RatingUsuario;

namespace PBAPP.Herramientas
{
    public class Rating
    {
        /// <summary>
        /// Llenar rating mensual.
        /// </summary>
        /// <param name="fecha">fecha.</param>
        /// <param name="tipo">tipo.</param>
        /// <returns>Parametros para consultar rating.</returns>
        public static RatingUsuarioRequest LlenarRatingMensual(DateTime fecha, string tipo)
        {
            RatingUsuarioRequest respuesta = new();
            if (fecha > DateTime.Now)
            {
                Excepcion.BitacoraErrores("Fecha mayor a la actual", new { fechaAgregada = fecha, TipoRating = tipo });
                throw new Exception("Fecha mayor a la actual");
            }

            respuesta.Offset = 0;
            respuesta.StartDate = $"{fecha:yyyy}-{fecha:MM}-01";
            respuesta.SortBy = "asc";
            respuesta.Limit = 100;
            respuesta.EndDate = fecha.ToString("yyyy-MM-dd");
            respuesta.Type = tipo;

            return respuesta;
        }

        public static List<RatingPorFecha> GenerarHistorialGrafica(
    RatingUsuarioResponse singlesResponse,
    RatingUsuarioResponse doublesResponse,
    double ratingInicialSingles,
    double ratingInicialDoubles)
        {
            var resultado = new List<RatingPorFecha>();

            var singles = singlesResponse?.Result?.RatingHistory?
                .Where(x => DateTime.TryParse(x.Date, out _))
                .GroupBy(x => DateTime.Parse(x.Date).Date)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(x => DateTime.Parse(x.Date)).First().Rating) ?? [];

            var doubles = doublesResponse?.Result?.RatingHistory?
                .Where(x => DateTime.TryParse(x.Date, out _))
                .GroupBy(x => DateTime.Parse(x.Date).Date)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(x => DateTime.Parse(x.Date)).First().Rating) ?? [];

            // Si ambos vienen vacíos
            if (singles.Count == 0 && doubles.Count == 0)
            {
                resultado.Add(new RatingPorFecha
                {
                    Fecha = DateTime.Today,
                    Singles = ratingInicialSingles,
                    Doubles = ratingInicialDoubles
                });

                return resultado;
            }

            var fechasUnicas = singles.Keys
                .Union(doubles.Keys)
                .Distinct()
                .OrderBy(f => f)
                .ToList();

            double ultimoSingles = ratingInicialSingles;
            double ultimoDoubles = ratingInicialDoubles;

            foreach (var fecha in fechasUnicas)
            {
                if (singles.ContainsKey(fecha))
                {
                    ultimoSingles = singles[fecha];
                }

                if (doubles.ContainsKey(fecha))
                {
                    ultimoDoubles = doubles[fecha];
                }

                resultado.Add(new RatingPorFecha
                {
                    Fecha = fecha,
                    Singles = ultimoSingles,
                    Doubles = ultimoDoubles
                });
            }

            return resultado;
        }
    }
}
