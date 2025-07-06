using Microsoft.Data.Sqlite;
using PBAPP.Modelos.HistorialPartidos;
using PBAPP.Valores;

namespace PBAPP.Repositorio
{
    public class SitioRepositorio
    {
        private const string ConnectionString = Constantes.BD;

        static SitioRepositorio()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Sitios (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Lugar TEXT NOT NULL,
                        Latencia REAL NOT NULL,
                        Longitud REAL NOT NULL
                    )";
                cmd.ExecuteNonQuery();
            }
        }

        public static void AgregarSitio(HistorialPorMapa sitio)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Sitios (Lugar, Latencia, Longitud)
                    VALUES (@lugar, @latencia, @longitud)";
                cmd.Parameters.AddWithValue("@lugar", sitio.Lugar);
                cmd.Parameters.AddWithValue("@latencia", sitio.Latencia);
                cmd.Parameters.AddWithValue("@longitud", sitio.Longitud);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<HistorialPorMapa> ObtenerSitios()
        {
            var sitios = new List<HistorialPorMapa>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Sitios";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sitios.Add(new HistorialPorMapa
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Lugar = reader["Lugar"].ToString(),
                            Latencia = Convert.ToDouble(reader["Latencia"]),
                            Longitud = Convert.ToDouble(reader["Longitud"])
                        });
                    }
                }
            }

            return sitios;
        }

        public static List<HistorialPorMapa> BuscarSitiosPorLugar(string termino)
        {
            var sitios = new List<HistorialPorMapa>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Sitios WHERE Lugar = @termino";
                cmd.Parameters.AddWithValue("@termino", termino);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sitios.Add(new HistorialPorMapa
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Lugar = reader["Lugar"].ToString(),
                            Latencia = Convert.ToDouble(reader["Latencia"]),
                            Longitud = Convert.ToDouble(reader["Longitud"])
                        });
                    }
                }
            }

            return sitios;
        }

        public static bool ExisteSitioPorLugar(string lugar)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Sitios WHERE Lugar = @lugar";
                cmd.Parameters.AddWithValue("@lugar", lugar);

                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
