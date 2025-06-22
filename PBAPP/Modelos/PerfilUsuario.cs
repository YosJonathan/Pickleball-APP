namespace PBAPP.Modelos
{
    public class PerfilUsuario
    {
        public string Status { get; set; }
        public Result Result { get; set; }

        public PerfilUsuario()
        {
            Status = string.Empty;
            Result = new Result();
        }
    }

    public class Result
    {
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

        public Result()
        {
            Id = 0;
            FullName = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            DisplayUsername = false;
            imageUrl = string.Empty;
            IsoCode = string.Empty;
            Phone = string.Empty;
            IsValidPhone = false;
            Email = string.Empty;
            IsValidEmail = false;
            ReferralCode = string.Empty;
            Birthdate = string.Empty;
            Gender = string.Empty;
            Role = new Role();
            Stats = new Stats();
            Addresses = new List<Address>();
            Active = false;
            UserPreferences = new UserPreferences();
            Restricted = false;
            LucraConnected = false;
        }
    }

    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public Role()
        {
            Id = 0;
            RoleName = string.Empty;
        }
    }

    public class Stats
    {
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

        public Stats()
        {
            Singles = string.Empty;
            SinglesVerified = string.Empty;
            SinglesProvisional = false;
            SinglesReliabilityScore = 0;
            Doubles = string.Empty;
            DoublesVerified = string.Empty;
            DoublesProvisional = false;
            DoublesReliabilityScore = 0;
            DefaultRating = string.Empty;
            ProvisionalRatings = new ProvisionalRatings();
        }
    }

    public class ProvisionalRatings
    {
        public object SinglesRating { get; set; }
        public object DoublesRating { get; set; }
        public object Coach { get; set; }

        public ProvisionalRatings()
        {
            SinglesRating = null;
            DoublesRating = null;
            Coach = null;
        }
    }

    public class Address
    {
        public long Id { get; set; }
        public string ShortAddress { get; set; }
        public string FormattedAddress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PlaceId { get; set; }
        public string Precision { get; set; }
        public string Status { get; set; }
        public string Types { get; set; }
        public DateTime Create { get; set; }

        public Address()
        {
            Id = 0;
            ShortAddress = string.Empty;
            FormattedAddress = string.Empty;
            Latitude = 0.0;
            Longitude = 0.0;
            PlaceId = string.Empty;
            Precision = string.Empty;
            Status = string.Empty;
            Types = string.Empty;
            Create = DateTime.MinValue;
        }
    }

    public class UserPreferences
    {
        public bool EnableSms { get; set; }
        public bool EnableEmail { get; set; }
        public bool EnablePush { get; set; }
        public bool EnablePrivacy { get; set; }
        public bool EnableNewsletter { get; set; }

        public UserPreferences()
        {
            EnableSms = false;
            EnableEmail = false;
            EnablePush = false;
            EnablePrivacy = false;
            EnableNewsletter = false;
        }
    }

}
