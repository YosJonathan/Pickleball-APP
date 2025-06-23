namespace PBAPP.Modelos
{
    public class Address
    {
        public Address()
        {
            this.Id = 0;
            this.ShortAddress = string.Empty;
            this.FormattedAddress = string.Empty;
            this.Latitude = 0.0;
            this.Longitude = 0.0;
            this.Status = string.Empty;
            this.Create = DateTime.MinValue;
        }

        public long Id { get; set; }

        public string ShortAddress { get; set; }

        public string FormattedAddress { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Status { get; set; }

        public DateTime Create { get; set; }
    }
}
