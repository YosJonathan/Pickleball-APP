using Newtonsoft.Json.Linq;
using PBAPP.Modelos.HistorialPartidos;
using PBAPP.Valores;

namespace PBAPP.Servicios
{
    public class Geolocalizacion
    {
        private const string ApiKey = Constantes.Key; // Reemplaza con tu API Key

        public static async Task<HistorialPorMapa?> ObtenerCoordenadasAsync(string direccion)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(direccion)}&key={ApiKey}";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var contenido = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(contenido);

                var status = json["status"]?.ToString();

                if (json["status"]?.ToString() == "OK")
                {
                    var location = json["results"]?[0]?["geometry"]?["location"];

                    if (location == null)
                    {
                        return null;
                    }

                    return new HistorialPorMapa
                    {
                        Latencia = location?["lat"]?.Value<double>() ?? 0,
                        Longitud = location?["lng"]?.Value<double>() ?? 0,
                        Lugar = direccion
                    };
                }
            }

            return null;
        }
    }
}
