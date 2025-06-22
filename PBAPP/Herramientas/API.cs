// <copyright file="API.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using PBAPP.Valores;

namespace PBAPP.Herramientas
{
    /// <summary>
    /// Clase para APIs.
    /// </summary>
    public class API
    {
        /// <summary>
        /// Consumir API, asincrono.
        /// </summary>
        /// <typeparam name="TRequest">Modelo solicitud.</typeparam>
        /// <typeparam name="TResponse">Modelo respuesta.</typeparam>
        /// <param name="httpClient">httpClient</param>
        /// <param name="url">ruta url.</param>
        /// <param name="token">token.</param>
        /// <param name="metodo">metodo.</param>
        /// <param name="requestBody">Solicitud.</param>
        /// <returns>Objeto Respuesta.</returns>
        public static async Task<TResponse> ConsumirApiAsync<TRequest, TResponse>(
        HttpClient httpClient,
        string url,
        string token,
        HttpMethod metodo,
        TRequest? requestBody = default)
        {
            // Agregar token Bearer al header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage request = new(metodo, Constantes.Dominio + url);

            // Si es POST y hay body, serializarlo
            if (metodo == HttpMethod.Post && requestBody != null)
            {
                string jsonBody = JsonSerializer.Serialize(requestBody);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            try
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Lanza excepción si no es 2xx
                JsonSerializerOptions options = new()
                {
                    PropertyNameCaseInsensitive = true
                };

                string contenido = await response.Content.ReadAsStringAsync();
                TResponse resultado = JsonSerializer.Deserialize<TResponse>(contenido, options) ?? Activator.CreateInstance<TResponse>();

                return resultado;
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), new { solicitud = requestBody, token, ruta = url });
                Console.WriteLine($"Error al consumir la API: {ex.Message}");
                throw;
            }
        }
    }
}
