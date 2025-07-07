using Microsoft.Data.Sqlite;
using PBAPP.Modelos.HistorialPartidos;
using PBAPP.Valores;

namespace PBAPP.Herramientas
{
    public class SitioCercanos
    {
        private const double RadioTierraKm = 6371.0;

        public static List<HistorialPorMapa> ObtenerSitiosCercanos(double latitudReferencia, double longitudReferencia, double radioKm = 40)
        {
            var sitiosCercanos = new List<HistorialPorMapa>();

            using (var connection = new SqliteConnection(Constantes.BD))
            {
                connection.Open();

                string query = "SELECT Id, Lugar, Latencia, Longitud FROM Sitios";
                using (var command = new SqliteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["Id"]);
                        string? lugar = reader["Lugar"].ToString();
                        var lat = Convert.ToDouble(reader["Latencia"]);
                        var lon = Convert.ToDouble(reader["Longitud"]);

                        double distancia = CalcularDistancia(latitudReferencia, longitudReferencia, lat, lon);

                        if (distancia <= radioKm)
                        {
                            sitiosCercanos.Add(new HistorialPorMapa
                            {
                                Id = id,
                                Lugar = string.IsNullOrEmpty(lugar) ? string.Empty : lugar,
                                Latencia = lat,
                                Longitud = lon
                            });
                        }
                    }
                }
            }

            return sitiosCercanos;
        }

        private static double CalcularDistancia(double lat1, double lon1, double lat2, double lon2)
        {
            double radLat1 = GradosARadianes(lat1);
            double radLat2 = GradosARadianes(lat2);
            double deltaLat = GradosARadianes(lat2 - lat1);
            double deltaLon = GradosARadianes(lon2 - lon1);

            double a =
    (Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2)) +
    ((Math.Cos(radLat1) * Math.Cos(radLat2)) *
     (Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2)));

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return RadioTierraKm * c;
        }

        private static double GradosARadianes(double grados)
        {
            return grados * (Math.PI / 180);
        }
    }
}
