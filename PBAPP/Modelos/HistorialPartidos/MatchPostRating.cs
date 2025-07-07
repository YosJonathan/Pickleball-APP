using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class MatchPostRating
    {
        public MatchPostRating()
        {
            this.Singles = 0;
            this.Doubles = 0;
        }

        [JsonPropertyName("singles")]
        public double? Singles { get; set; }

        [JsonPropertyName("doubles")]
        public double? Doubles { get; set; }
    }
}
