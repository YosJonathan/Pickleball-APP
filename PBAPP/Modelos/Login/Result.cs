namespace PBAPP.Modelos.Login
{
    public class Result
    {
        public Result()
        {
            this.AccessToken = string.Empty;
            this.RefreshToken = string.Empty;
        }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
