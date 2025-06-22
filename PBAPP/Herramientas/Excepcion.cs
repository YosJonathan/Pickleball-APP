using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PBAPP.Herramientas
{
    /// <summary>
    /// Clase de excepción.
    /// </summary>
    public class Excepcion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excepcion"></param>
        /// <param name="parametros"></param>
        /// <param name="nombreMetodo"></param>
        public static void BitacoraErrores<T>(string excepcion, T parametros, [CallerMemberName] string nombreMetodo = "")
        {
            Console.WriteLine($"Metodo: {nombreMetodo} - Parametros: {ConvertirAJson(parametros)} - Excepción: {excepcion}");
        }

        /// <summary>
        /// Convertir modelo a json.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="modelo">modelo.</param>
        /// <returns>modelo en json.</returns>
        private static string ConvertirAJson<T>(T modelo)
        {
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true // para que el JSON sea legible
            };
            return JsonSerializer.Serialize(modelo, opciones);
        }
    }
}
