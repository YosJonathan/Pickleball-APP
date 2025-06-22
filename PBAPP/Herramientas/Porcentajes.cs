namespace PBAPP.Herramientas
{
    public class Porcentajes
    {
        /// <summary>
        /// Redondear porcentaje.
        /// </summary>
        /// <param name="porcentaje">Porcentaje.</param>
        /// <returns>porcentaje redondeado.</returns>
        public static string RedondearPorcentaje(string porcentaje)
        {
            if (string.IsNullOrWhiteSpace(porcentaje) || porcentaje.Trim() == "-")
                return "0%";

            // Quitar el símbolo %
            porcentaje = porcentaje.Replace("%", "").Trim();

            // Reemplazar coma por punto en caso de formatos con coma decimal
            porcentaje = porcentaje.Replace(',', '.');

            if (double.TryParse(porcentaje, out double valorNumerico))
            {
                int redondeado = (int)Math.Round(valorNumerico);
                return $"{redondeado}%";
            }

            return "0%";
        }
    }
}
