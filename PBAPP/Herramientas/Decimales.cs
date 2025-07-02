namespace PBAPP.Herramientas
{
    public class Decimales
    {
        public static string Ultimos3Decimales(double? numero)
        {
            if (numero == null)
            {
                return string.Empty;
            }

            double valor = (double)numero;
            return valor.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
