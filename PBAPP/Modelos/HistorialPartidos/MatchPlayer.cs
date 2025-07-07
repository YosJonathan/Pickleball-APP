using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class MatchPlayer
    {
        public MatchPlayer()
        {
            this.Id = 0;
            this.FullName = string.Empty;
            this.DuprId = string.Empty;
            this.ImageUrl = string.Empty;
            this.AllowSubstitution = false;
            this.PostMatchRating = new MatchPostRating();
            this.ValidatedMatch = false;
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("duprId")]
        public string DuprId { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("allowSubstitution")]
        public bool AllowSubstitution { get; set; }

        [JsonPropertyName("postMatchRating")]
        public MatchPostRating PostMatchRating { get; set; }

        [JsonPropertyName("validatedMatch")]
        public bool ValidatedMatch { get; set; }
    }
}
