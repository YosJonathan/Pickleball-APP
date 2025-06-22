namespace PBAPP.Modelos
{
    public class Result
    {
        public Result()
        {
            this.Id = 0;
            this.FullName = string.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.DisplayUsername = false;
            this.imageUrl = string.Empty;
            this.IsoCode = string.Empty;
            this.Phone = string.Empty;
            this.IsValidPhone = false;
            this.Email = string.Empty;
            this.IsValidEmail = false;
            this.ReferralCode = string.Empty;
            this.Birthdate = string.Empty;
            this.Gender = string.Empty;
            this.Role = new Role();
            this.Stats = new Stats();
            this.Addresses = new List<Address>();
            this.Active = false;
            this.UserPreferences = new UserPreferences();
            this.Restricted = false;
            this.LucraConnected = false;
        }

        public long Id { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool DisplayUsername { get; set; }

        public string IsoCode { get; set; }

        public string Phone { get; set; }

        public bool IsValidPhone { get; set; }

        public string Email { get; set; }

        public string imageUrl { get; set; }

        public bool IsValidEmail { get; set; }

        public string ReferralCode { get; set; }

        public string Birthdate { get; set; }

        public string Gender { get; set; }

        public Role Role { get; set; }

        public Stats Stats { get; set; }

        public List<Address> Addresses { get; set; }

        public bool Active { get; set; }

        public UserPreferences UserPreferences { get; set; }

        public bool Restricted { get; set; }

        public bool LucraConnected { get; set; }
    }
}
