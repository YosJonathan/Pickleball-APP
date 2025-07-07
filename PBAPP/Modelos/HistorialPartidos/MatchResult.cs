using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class MatchResult
    {
        public MatchResult()
        {
            this.Offset = 0;
            this.Limit = 0;
            this.Total = 0;
            this.Hits = new List<MatchHit>();
            this.TotalValueRelation = string.Empty;
            this.Empty = false;
            this.HasMore = false;
            this.HasPrevious = false;
        }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("hits")]
        public List<MatchHit> Hits { get; set; }

        [JsonPropertyName("totalValueRelation")]
        public string TotalValueRelation { get; set; }

        [JsonPropertyName("empty")]
        public bool Empty { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("hasPrevious")]
        public bool HasPrevious { get; set; }
    }
}
