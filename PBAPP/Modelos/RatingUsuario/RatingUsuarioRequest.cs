using System.Text.Json.Serialization;

namespace PBAPP.Modelos.RatingUsuario
{
    public class RatingUsuarioRequest
    {
        public RatingUsuarioRequest()
        {
            this.EndDate = string.Empty;
            this.Limit = 0;
            this.Offset = 0;
            this.StartDate = string.Empty;
            this.SortBy = string.Empty;
            this.Type = string.Empty;
        }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("sortBy")]
        public string SortBy { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
