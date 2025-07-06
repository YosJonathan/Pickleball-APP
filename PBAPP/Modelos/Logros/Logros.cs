namespace PBAPP.Modelos.Logros
{
    public class Logros
    {
        public Logros()
        {
            this.Icono = string.Empty;
            this.Descripcion = string.Empty;
            this.CategoriaLogro = 0;
        }

        public string Icono { get; set; }

        public string Descripcion { get; set; }

        public int CategoriaLogro { get; set; }
    }
}
