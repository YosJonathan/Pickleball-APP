using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class HistorialPartidosRequest
    {
        public HistorialPartidosRequest()
        {
            this.Filters = new();
            this.Limit = 0;
            this.Offset = 0;
            this.Sort = new MatchSort();
        }

        [JsonPropertyName("filters")]
        public MatchFilters? Filters { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("sort")]
        public MatchSort Sort { get; set; }
    }
}
