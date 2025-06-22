namespace PBAPP.Modelos
{
    public class ProvisionalRatings
    {
        public ProvisionalRatings()
        {
            this.SinglesRating = null;
            this.DoublesRating = null;
            this.Coach = null;
        }

        public object? SinglesRating { get; set; }

        public object? DoublesRating { get; set; }

        public object? Coach { get; set; }
    }
}
