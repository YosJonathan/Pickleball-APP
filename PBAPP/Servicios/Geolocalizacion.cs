using Newtonsoft.Json.Linq;
using PBAPP.Herramientas;
using PBAPP.Modelos.HistorialPartidos;
using PBAPP.Valores;

namespace PBAPP.Servicios
{
    public class Geolocalizacion
    {
        public static async Task<HistorialPorMapa?> ObtenerCoordenadasAsync(string direccion)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(direccion)}&key={ObtenerApiKey()}";
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

        private static string ObtenerApiKey()
        {
            var ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apikeys.secret.json");

            if (!File.Exists(ruta))
            {
                Excepcion.BitacoraErrores("No se encontró el archivo de clave", ruta);
            }

            var json = File.ReadAllText(ruta);
            var obj = JObject.Parse(json);
            return obj["ApiKey"]?.ToString() ?? string.Empty;
        }
    }
}
