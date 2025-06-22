namespace PBAPP.Modelos.Login
{
    public class Root
    {
        public Root()
        {
            this.Status = string.Empty;
            this.Message = string.Empty;
            this.Result = new Result();
        }

        public string Status { get; set; }

        public string Message { get; set; }

        public Result Result { get; set; }
    }
}
