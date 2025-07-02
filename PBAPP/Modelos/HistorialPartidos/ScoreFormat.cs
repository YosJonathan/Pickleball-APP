using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{

    public class ScoreFormat
    {
        public ScoreFormat()
        {
            this.Id = 0;
            this.Format = string.Empty;
            this.Variant = string.Empty;
            this.Games = 0;
            this.WinningScore = 0;
            this.Priority = 0;
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("variant")]
        public string Variant { get; set; }

        [JsonPropertyName("games")]
        public int Games { get; set; }

        [JsonPropertyName("winningScore")]
        public int WinningScore { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }
    }

}
