using PBAPP.Modelos.SeguidoresUsuario;

namespace PBAPP.Modelos.Perfil
{
    public class PerfilInformacionUsuario
    {
        public PerfilInformacionUsuario()
        {
            this.PerfilUsuario = new();
            this.Seguidores = new();
            this.PerfilUsuarioExterno = new();
            this.DashBoard = false;
        }

        public PerfilUsuario PerfilUsuario { get; set; }

        public SeguidoresUsuarioResponse Seguidores { get; set; }

        public PerilUsuarioExterno PerfilUsuarioExterno { get; set; }

        public bool DashBoard { get; set; }
    }
}
