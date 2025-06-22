namespace PBAPP.Modelos.Login
{
    public class Root
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Result Result { get; set; }

        public Root()
        {
            Status = string.Empty;
            Message = string.Empty;
            Result = new Result();
        }
    }
}
