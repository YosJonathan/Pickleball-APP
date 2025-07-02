using PBAPP.Modelos.HistorialPartidos;

namespace PBAPP.Herramientas
{
    public class CodigoHTML
    {
        public static string RetornarEtiquetaRating(double? rating, double? antes, MatchPostRating? actuales, string tipo)
        {
            string resultado = string.Empty;
            double? ahora;

            try
            {
                ahora = tipo.Contains("DOUBLES", StringComparison.CurrentCultureIgnoreCase) ? actuales?.Doubles : actuales?.Singles;
                resultado = rating > 0 ? $"<p class='text-green-400' title='Antes: {Decimales.Ultimos3Decimales(antes)} → Ahora: {Decimales.Ultimos3Decimales(ahora)}'>{Decimales.Ultimos3Decimales(rating)} <span class=\"material-symbols-outlined\">arrow_drop_up</span></p>" :
                            rating == 0 ? $"<p class='text-gray-400'>{Decimales.Ultimos3Decimales(rating)} <span class=\"material-symbols-outlined\">check_indeterminate_small</span></p>" :
                            $"<p class='text-red-400' title='Antes: {Decimales.Ultimos3Decimales(antes)} → Ahora: {Decimales.Ultimos3Decimales(ahora)}'>{Decimales.Ultimos3Decimales(rating)} <span class=\"material-symbols-outlined\">arrow_drop_down</span></p>";
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), rating);
            }

            return resultado;
        }

        public static string ObtenerNombres(string? nombre1, string? nombre2)
        {
            string respuesta;

            nombre1 = string.IsNullOrEmpty(nombre1) ? string.Empty : nombre1;

            respuesta = !string.IsNullOrEmpty(nombre2) ? $"<p title='{nombre1}'>{PrimerNombre(nombre1)}</p> & <p title='{nombre2}'>{PrimerNombre(nombre2)}</p>" :
                $"<p title='{nombre1}'>{PrimerNombre(nombre1)}</p>";

            return respuesta;
        }

        private static string PrimerNombre(string nombre)
        {
            string respuesta;
            respuesta = nombre;
            if (nombre.Contains(' '))
            {
                string[] nombreSeparado = nombre.Split(' ');
                respuesta = nombreSeparado[0];
            }

            return respuesta;
        }
    }
}
