namespace PBAPP.Modelos
{
    public class UserPreferences
    {
        public UserPreferences()
        {
            this.EnableSms = false;
            this.EnableEmail = false;
            this.EnablePush = false;
            this.EnablePrivacy = false;
            this.EnableNewsletter = false;
        }

        public bool EnableSms { get; set; }

        public bool EnableEmail { get; set; }

        public bool EnablePush { get; set; }

        public bool EnablePrivacy { get; set; }

        public bool EnableNewsletter { get; set; }
    }
}
