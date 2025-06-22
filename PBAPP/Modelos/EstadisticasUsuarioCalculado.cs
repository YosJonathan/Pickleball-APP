namespace PBAPP.Modelos
{
    public class EstadisticasUsuarioCalculado
    {
        public EstadisticasUsuarioCalculado()
        {
            this.Status = string.Empty;
            this.Result = new DuprResult();
        }

        public string Status { get; set; }

        public DuprResult Result { get; set; }
    }
}
