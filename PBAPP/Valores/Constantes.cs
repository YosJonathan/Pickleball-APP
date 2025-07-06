namespace PBAPP.Valores;

public static class Constantes
{
    /// <summary>
    /// Versión de la API.
    /// </summary>
    public const string VersionAPI = "V1.0";

    /// <summary>
    /// Versión de la API 1.1.
    /// </summary>
    public const string VersionAPIPuntoUno = "V1.1";

    /// <summary>
    /// Dominio.
    /// </summary>
    public const string Dominio = "https://api.dupr.gg";

    /// <summary>
    /// Key.
    /// </summary>
    public const string Key = "AIzaSyAFyRdwt9pF6sPZ4yzvV3iYXho84HQAFes";

    /// <summary>
    /// Archivo de bd.
    /// </summary>
    public const string BD = "Data Source=sitios.db";

    /// <summary>
    /// Radio de la tierra.
    /// </summary>
    public const double RadioDeLaTierra = 6371.0;

    /// <summary>
    /// Imagen por defecto.
    /// </summary>
    public static string ImagenPorDefecto(bool imagenPerfil = false) { 
        return imagenPerfil ? "https://cdn-icons-png.flaticon.com/256/3177/3177440.png" :
            "https://cdn-icons-png.flaticon.com/64/3177/3177440.png"; }
}
