namespace PBAPP.Modelos
{
    public class DuprResult
    {
        public DuprResult()
        {
            this.Singles = new DuprModeStats();
            this.Doubles = new DuprModeStats();
            this.ResulOverview = new ResultOverview();
        }

        public DuprModeStats Singles { get; set; }

        public DuprModeStats Doubles { get; set; }

        public ResultOverview ResulOverview { get; set; }
    }
}
