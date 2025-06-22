namespace PBAPP.Modelos
{
    public class Role
    {
        public Role()
        {
            this.Id = 0;
            this.RoleName = string.Empty;
        }

        public int Id { get; set; }

        public string RoleName { get; set; }
    }
}
