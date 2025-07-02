using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class MatchSort
    {
        public MatchSort()
        {
            this.Order = string.Empty;
            this.Parameter = string.Empty;
        }

        [JsonPropertyName("order")]
        public string Order { get; set; }

        [JsonPropertyName("parameter")]
        public string Parameter { get; set; }
    }
}
