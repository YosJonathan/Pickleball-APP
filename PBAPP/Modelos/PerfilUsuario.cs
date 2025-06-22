namespace PBAPP.Modelos
{
    public class PerfilUsuario
    {
        public PerfilUsuario()
        {
            this.Status = string.Empty;
            this.Result = new Result();
        }

        public string Status { get; set; }

        public Result Result { get; set; }
    }
}
