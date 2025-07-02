namespace PBAPP.Modelos.HistorialPartidos
{
    public class HistorialPorMapa
    {
        public HistorialPorMapa()
        {
            this.Lugar = string.Empty;
            this.Evento = [];
            this.Partidos = 0;
            this.Latencia = 0;
            this.Longitud = 0;
        }

        public string Lugar { get; set; }

        public List<string> Evento { get; set; }

        public int Partidos { get; set; }

        public double Latencia { get; set; }

        public double Longitud { get; set; }
    }
}
