namespace PBAPP.Modelos
{
    public class ResultOverview
    {
        public ResultOverview()
        {
            this.Wins = 0;
            this.Losses = 0;
            this.Pending = 0;
        }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Pending { get; set; }
    }
}
