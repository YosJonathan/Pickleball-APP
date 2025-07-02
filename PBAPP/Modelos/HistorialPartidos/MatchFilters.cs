using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{

    public class MatchFilters
    {
        public MatchFilters()
        {
            this.EventFormat = null;
            this.MatchStatus = null;
            this.EventDate = null;
            this.EventName = string.Empty;
            this.PlayerId = string.Empty;
        }

        [JsonPropertyName("eventFormat")]
        public string? EventFormat { get; set; }

        [JsonPropertyName("matchStatus")]
        public string? MatchStatus { get; set; }

        [JsonPropertyName("eventDate")]
        public string? EventDate { get; set; }

        [JsonPropertyName("eventName")]
        public string EventName { get; set; }

        [JsonPropertyName("playerId")]
        public string PlayerId { get; set; }
    }
}
