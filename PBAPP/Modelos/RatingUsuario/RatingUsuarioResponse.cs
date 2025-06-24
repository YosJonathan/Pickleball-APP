using System.Text.Json.Serialization;

namespace PBAPP.Modelos.RatingUsuario
{
    public class RatingUsuarioResponse
    {
        public RatingUsuarioResponse()
        {
            this.Status = string.Empty;
            this.Result = new RatingResult();
        }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("result")]
        public RatingResult Result { get; set; }
    }
}
