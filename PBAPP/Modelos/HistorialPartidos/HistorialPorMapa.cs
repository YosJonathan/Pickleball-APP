namespace PBAPP.Modelos.HistorialPartidos
{
    public class HistorialPorMapa
    {
        public HistorialPorMapa()
        {
            this.Id = 0;
            this.Lugar = string.Empty;
            this.Latencia = 0;
            this.Longitud = 0;
        }

        public int Id { get; set; }

        public string Lugar { get; set; }

        public double Latencia { get; set; }

        public double Longitud { get; set; }
    }
}
