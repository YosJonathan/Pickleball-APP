using System.Text.Json.Serialization;

namespace PBAPP.Modelos.Perfil
{
    public class PerilUsuarioExterno
    {
        public PerilUsuarioExterno()
        {
            this.Status = string.Empty;
            this.Result = new PlayerInfo();
        }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("result")]
        public PlayerInfo Result { get; set; }
    }
}
