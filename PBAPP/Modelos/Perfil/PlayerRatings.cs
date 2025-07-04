using System.Text.Json.Serialization;

namespace PBAPP.Modelos.Perfil
{
    public class PlayerRatings
    {
        public PlayerRatings()
        {
            this.Singles = string.Empty;
            this.Doubles = string.Empty;
        }

        [JsonPropertyName("singles")]
        public string Singles { get; set; }

        [JsonPropertyName("doubles")]
        public string Doubles { get; set; }
    }
}
