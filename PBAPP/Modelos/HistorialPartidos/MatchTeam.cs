using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class MatchTeam
    {
        public MatchTeam()
        {
            this.Id = 0;
            this.Serial = 0;
            this.Player1 = new MatchPlayer();
            this.Player2 = new MatchPlayer();
            this.Game1 = 0;
            this.Game2 = 0;
            this.Game3 = 0;
            this.Game4 = 0;
            this.Game5 = 0;
            this.Winner = false;
            this.Delta = string.Empty;
            this.TeamRating = string.Empty;
            this.PrePartidos = new();
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("serial")]
        public int Serial { get; set; }

        [JsonPropertyName("player1")]
        public MatchPlayer Player1 { get; set; }

        [JsonPropertyName("player2")]
        public MatchPlayer Player2 { get; set; }

        [JsonPropertyName("game1")]
        public int Game1 { get; set; }

        [JsonPropertyName("game2")]
        public int Game2 { get; set; }

        [JsonPropertyName("game3")]
        public int Game3 { get; set; }

        [JsonPropertyName("game4")]
        public int Game4 { get; set; }

        [JsonPropertyName("game5")]
        public int Game5 { get; set; }

        [JsonPropertyName("winner")]
        public bool Winner { get; set; }

        [JsonPropertyName("delta")]
        public string Delta { get; set; }

        [JsonPropertyName("teamRating")]
        public string TeamRating { get; set; }

        [JsonPropertyName("preMatchRatingAndImpact")]
        public PrePartido PrePartidos { get; set; }
    }
}
