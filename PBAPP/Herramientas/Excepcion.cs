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
        /// Bitacora de errores.
        /// </summary>
        /// <typeparam name="T">Tipo de modelo.</typeparam>
        /// <param name="excepcion">excepción.</param>
        /// <param name="parametros">parametros de la función.</param>
        /// <param name="nombreMetodo">Nombre de método.</param>
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
