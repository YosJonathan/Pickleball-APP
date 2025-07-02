using System.Text.Json.Serialization;
using PBAPP.Herramientas;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class PrePartido
    {
        public PrePartido()
        {
            this.RatingPlayer1 = 0;
            this.RatingPlayer2 = 0;
            this.RatingImpatcPlayer1 = 0;
            this.RatingImpatcPlayer2 = 0;
        }

        [JsonPropertyName("preMatchDoubleRatingPlayer1")]
        public double? RatingPlayer1 { get; set; }

        [JsonPropertyName("preMatchDoubleRatingPlayer2")]
        public double? RatingPlayer2 { get; set; }

        [JsonPropertyName("matchDoubleRatingImpactPlayer1")]
        public double? RatingImpatcPlayer1 { get; set; }

        [JsonPropertyName("matchDoubleRatingImpactPlayer2")]
        public double? RatingImpatcPlayer2 { get; set; }
    }
}
