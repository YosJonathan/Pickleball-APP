using System.Text.Json.Serialization;

namespace PBAPP.Modelos.RatingUsuario
{
    public class RatingResult
    {
        public RatingResult()
        {
            this.PlayerId = 0;
            this.Type = string.Empty;
            this.RatingHistory = new List<RatingEntry>();
        }

        [JsonPropertyName("playerId")]
        public long PlayerId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("ratingHistory")]
        public List<RatingEntry> RatingHistory { get; set; }
    }
}
