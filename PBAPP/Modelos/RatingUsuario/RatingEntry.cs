using System.Text.Json.Serialization;
using PBAPP.Herramientas;

namespace PBAPP.Modelos.RatingUsuario
{
    public class RatingEntry
    {
        public RatingEntry()
        {
            this.Date = string.Empty;
            this.MatchDate = string.Empty;
            this.Rating = 0.0;
            this.ChangedByAdmin = false;
        }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("matchDate")]
        public string MatchDate { get; set; }

        [JsonPropertyName("rating")]
        [JsonConverter(typeof(SafeDoubleConverter))]
        public double Rating { get; set; }

        [JsonPropertyName("changedByAdmin")]
        public bool ChangedByAdmin { get; set; }
    }
}
