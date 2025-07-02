using System.Text.Json.Serialization;

namespace PBAPP.Modelos.HistorialPartidos
{
    public class HistorialPartidosResponse
    {
        public HistorialPartidosResponse()
        {
            this.Result = new MatchResult();
        }

        [JsonPropertyName("result")]
        public MatchResult Result { get; set; }
    }
}
