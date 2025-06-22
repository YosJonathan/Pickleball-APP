namespace PBAPP.Modelos
{
    public class InicioSesionRequest
    {
        public InicioSesionRequest()
        {
            this.email = string.Empty;
            this.password = string.Empty;
        }

        public string email { get; set; }
        public string password { get; set; }
    }
}
