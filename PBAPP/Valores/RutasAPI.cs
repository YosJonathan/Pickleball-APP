namespace PBAPP.Valores
{
    public static class RutasAPI
    {
        /// <summary>
        /// Login.
        /// </summary>
        public const string RutaLogin = $"/auth/{Constantes.VersionAPI}/login";

        /// <summary>
        /// Perfil de usuario.
        /// </summary>
        public const string RutaPerfil = $"/user/{Constantes.VersionAPI}/profile";

        /// <summary>
        /// Ruta de clubs propios.
        /// </summary>
        public const string RutaClubs = $"/club/roles/{Constantes.VersionAPI}/all";

        /// <summary>
        /// Generar ruta estadisticas de usuario.
        /// </summary>
        /// <param name="idUsuario">Id de usuario.</param>
        /// <returns>Ruta de estadisticas.</returns>
        public static string RutaEstadisticasUsuario(long idUsuario)
        {
            return $"/user/calculated/{Constantes.VersionAPI}/stats/{idUsuario}";
        }
    }
}
