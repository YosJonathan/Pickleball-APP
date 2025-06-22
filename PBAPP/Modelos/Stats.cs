namespace PBAPP.Modelos
{
    public class Stats
    {
        public Stats()
        {
            this.Singles = string.Empty;
            this.SinglesVerified = string.Empty;
            this.SinglesProvisional = false;
            this.SinglesReliabilityScore = 0;
            this.Doubles = string.Empty;
            this.DoublesVerified = string.Empty;
            this.DoublesProvisional = false;
            this.DoublesReliabilityScore = 0;
            this.DefaultRating = string.Empty;
            this.ProvisionalRatings = new ProvisionalRatings();
        }

        public string Singles { get; set; }

        public string SinglesVerified { get; set; }

        public bool SinglesProvisional { get; set; }

        public int SinglesReliabilityScore { get; set; }

        public string Doubles { get; set; }

        public string DoublesVerified { get; set; }

        public bool DoublesProvisional { get; set; }

        public int DoublesReliabilityScore { get; set; }

        public string DefaultRating { get; set; }

        public ProvisionalRatings ProvisionalRatings { get; set; }
    }
}
