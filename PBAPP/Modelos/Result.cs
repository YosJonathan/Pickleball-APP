namespace PBAPP.Modelos
{
    public class Result
    {
        public Result()
        {
            this.Id = 0;
            this.FullName = string.Empty;
            this.imageUrl = string.Empty;
            this.IsoCode = string.Empty;
            this.ReferralCode = string.Empty;
            this.Birthdate = string.Empty;
            this.Gender = string.Empty;
            this.Stats = new Stats();
            this.Addresses = [];
        }

        public long Id { get; set; }

        public string FullName { get; set; }

        public string IsoCode { get; set; }

        public string imageUrl { get; set; }

        public string ReferralCode { get; set; }

        public string Birthdate { get; set; }

        public string Gender { get; set; }

        public Stats Stats { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
