using Microsoft.VisualBasic;

namespace PBAPP.Herramientas
{
    /// <summary>
    /// Clase de fechas.
    /// </summary>
    public class Fechas
    {
        /// <summary>
        /// Calcular la edad.
        /// </summary>
        /// <param name="nacimiento">Nacimiento.</param>
        /// <returns>Edad.</returns>
        public static int CalcularEdad(string? nacimiento)
        {
            int edad = 0;
            if (DateTime.TryParse(nacimiento, out DateTime fechaNacimiento))
            {
                DateTime hoy = DateTime.Today;
                edad = hoy.Year - fechaNacimiento.Year;

                // Si aún no ha cumplido años este año, restamos 1
                if (fechaNacimiento.Date > hoy.AddYears(-edad))
                {
                    edad--;
                }

                return edad;
            }
            else
            {
                Excepcion.BitacoraErrores("La fecha no tiene un formato válido.", nacimiento);
            }

            return edad;
        }

        /// <summary>
        /// Obtener año.
        /// </summary>
        /// <param name="fecha">fecha.</param>
        /// <returns>Años de la fecha.</returns>
        public static int ObtenerAño(string fecha)
        {
            int añoFecha = 0;
            if (DateTime.TryParse(fecha, out DateTime fechaConvertida))
            {
                añoFecha = fechaConvertida.Year;

                return añoFecha;
            }
            else
            {
                Excepcion.BitacoraErrores("La fecha no tiene un formato válido.", fecha);
            }

            return añoFecha;
        }

        /// <summary>
        /// Obtener el mes de la fecha.
        /// </summary>
        /// <param name="fecha">fecha.</param>
        /// <returns>Mes escrito de la fecha.</returns>
        public static string ObtenerNombreMes(DateTime fecha)
        {
            var mes = fecha.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));
            return char.ToUpper(mes[0]) + mes[1..];
        }

        public static string ObtenerFechaTexto(DateTime? fecha)
        {
            string respuesta = string.Empty;
            if (fecha == null)
            {
                return respuesta;
            }

            DateTime nuevaFecha = (DateTime)fecha;

            string diaSemana = nuevaFecha.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));
            string dia = nuevaFecha.Day.ToString();
            string mes = nuevaFecha.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));

            // Verificamos si es hoy
            respuesta = nuevaFecha.Date == DateTime.Today
                ? $"Hoy, {diaSemana} {dia} de {mes}"
                : $"{diaSemana} {dia} de {mes}";

            return respuesta;
        }
    }
}
