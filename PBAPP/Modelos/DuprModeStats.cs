namespace PBAPP.Modelos
{
    public class DuprModeStats
    {
        public DuprModeStats()
        {
            this.AveragePartnerDupr = string.Empty;
            this.AverageOpponentDupr = string.Empty;
            this.AveragePointsWonPercent = string.Empty;
            this.HalfLife = string.Empty;
            this.Wins = 0;
            this.Losses = 0;
        }

        public string AveragePartnerDupr { get; set; }

        public string AverageOpponentDupr { get; set; }

        public string AveragePointsWonPercent { get; set; }

        public string HalfLife { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }
    }
}
