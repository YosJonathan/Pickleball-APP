using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{

    public class MatchUser
    {
        public MatchUser()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.ReferralCode = string.Empty;
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("referralCode")]
        public string ReferralCode { get; set; }
    }

}
