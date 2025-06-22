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
        public static int CalcularEdad(string nacimiento)
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
    }
}
