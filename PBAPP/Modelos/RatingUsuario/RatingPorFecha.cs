namespace PBAPP.Modelos.RatingUsuario
{
    public class RatingPorFecha
    {
        public RatingPorFecha()
        {
            this.Fecha = default;
            this.Doubles = 0.0;
            this.Singles = 0.0;
        }

        public DateTime Fecha { get; set; }

        public double Singles { get; set; }

        public double Doubles { get; set; }
    }
}
