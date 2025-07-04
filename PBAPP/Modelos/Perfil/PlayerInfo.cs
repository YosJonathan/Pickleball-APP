using System.Text.Json.Serialization;

namespace PBAPP.Modelos.Perfil
{

    public class PlayerInfo
    {
        public PlayerInfo()
        {
            this.Id = 0;
            this.FullName = string.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.ShortAddress = string.Empty;
            this.Gender = string.Empty;
            this.Age = 0;
            this.ImageUrl = string.Empty;
            this.Hand = string.Empty;
            this.Ratings = new PlayerRatings();
            this.EnablePrivacy = false;
            this.IsPlayer1 = false;
            this.VerifiedEmail = false;
            this.Registered = false;
            this.DuprId = string.Empty;
            this.ShowRatingBanner = false;
            this.Status = string.Empty;
            this.Sponsor = new object();
            this.LucraConnected = false;
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("shortAddress")]
        public string ShortAddress { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("hand")]
        public string Hand { get; set; }

        [JsonPropertyName("ratings")]
        public PlayerRatings Ratings { get; set; }

        [JsonPropertyName("enablePrivacy")]
        public bool EnablePrivacy { get; set; }

        [JsonPropertyName("isPlayer1")]
        public bool IsPlayer1 { get; set; }

        [JsonPropertyName("verifiedEmail")]
        public bool VerifiedEmail { get; set; }

        [JsonPropertyName("registered")]
        public bool Registered { get; set; }

        [JsonPropertyName("duprId")]
        public string DuprId { get; set; }

        [JsonPropertyName("showRatingBanner")]
        public bool ShowRatingBanner { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("sponsor")]
        public object Sponsor { get; set; }

        [JsonPropertyName("lucraConnected")]
        public bool LucraConnected { get; set; }
    }

}
