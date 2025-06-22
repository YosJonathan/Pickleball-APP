namespace PBAPP.Modelos.Login
{
    public class RespuestaError
    {
        public RespuestaError()
        {
            this.status = string.Empty;
            this.message = string.Empty;
        }

        public string status { get; set; }

        public string message { get; set; }
    }
}
