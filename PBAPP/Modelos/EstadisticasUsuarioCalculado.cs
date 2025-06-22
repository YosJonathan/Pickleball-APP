namespace PBAPP.Modelos
{
    public class EstadisticasUsuarioCalculado
    {
        public string Status { get; set; }
        public DuprResult Result { get; set; }

        public EstadisticasUsuarioCalculado()
        {
            Status = string.Empty;
            Result = new DuprResult();
        }
    }

    public class DuprResult
    {
        public DuprModeStats Singles { get; set; }
        public DuprModeStats Doubles { get; set; }
        public ResultOverview ResulOverview { get; set; }

        public DuprResult()
        {
            Singles = new DuprModeStats();
            Doubles = new DuprModeStats();
            ResulOverview = new ResultOverview();
        }
    }

    public class DuprModeStats
    {
        public string AveragePartnerDupr { get; set; }
        public string AverageOpponentDupr { get; set; }
        public string AveragePointsWonPercent { get; set; }
        public string HalfLife { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public DuprModeStats()
        {
            AveragePartnerDupr = string.Empty;
            AverageOpponentDupr = string.Empty;
            AveragePointsWonPercent = string.Empty;
            HalfLife = string.Empty;
            Wins = 0;
            Losses = 0;
        }
    }

    public class ResultOverview
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Pending { get; set; }

        public ResultOverview()
        {
            Wins = 0;
            Losses = 0;
            Pending = 0;
        }
    }
}
