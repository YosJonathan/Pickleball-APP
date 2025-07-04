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

        /// <summary>
        /// Genera ruta seguidores usuario.
        /// </summary>
        /// <param name="idUsuario">Id de usuario.</param>
        /// <returns>Ruta de seguidores.</returns>
        public static string RutaSeguidoresUsuario(long idUsuario)
        {
            return $"/activity/{Constantes.VersionAPIPuntoUno}/user/{idUsuario}/followingInfo";
        }

        /// <summary>
        /// Obtener rating usuario.
        /// </summary>
        /// <param name="idUsuario">Id de usuario.</param>
        /// <returns>Historial rating.</returns>
        public static string RutaHistorialRatingUsuario(long idUsuario)
        {
            return $"/player/{Constantes.VersionAPI}/{idUsuario}/rating-history";
        }

        /// <summary>
        /// Obtener historial de partidos del usuario.
        /// </summary>
        /// <param name="idUsuario">Id de usuario.</param>
        /// <returns>Ruta de historial de partidos.</returns>
        public static string RutaHistorialPartidosUsuario(long idUsuario)
        {
            return $"/player/{Constantes.VersionAPI}/{idUsuario}/history";
        }

        /// <summary>
        /// Obtener ruta de perfil de usuario.
        /// </summary>
        /// <param name="idUsuario">Id de usuario.</param>
        /// <returns>Ruta de perfil de usuario.</returns>
        public static string RutaPerfilUsuario(long idUsuario)
        {
            return $"/player/{Constantes.VersionAPI}/{idUsuario}";
        }
    }
}
