using PBAPP.Modelos.HistorialPartidos;
using PBAPP.Valores;

namespace PBAPP.Herramientas
{
    public class Estilos
    {
        public static string ObtenerColorEtiqueta(List<MatchTeam>? equipos, int numeroJuego = 1, bool esPrimero = true)
        {
            string respuesta = string.Empty;

            try
            {
                if (equipos == null)
                {
                    return respuesta;
                }

                int equipo1 = -1;
                int equipo2 = -1;
                switch (numeroJuego)
                {
                    case 1:
                        equipo1 = equipos[0].Game1;
                        equipo2 = equipos[1].Game1;
                        break;
                    case 2:
                        equipo1 = equipos[0].Game2;
                        equipo2 = equipos[1].Game2;
                        break;
                    case 3:
                        equipo1 = equipos[0].Game3;
                        equipo2 = equipos[1].Game3;
                        break;
                    case 4:
                        equipo1 = equipos[0].Game4;
                        equipo2 = equipos[1].Game4;
                        break;
                    case 5:
                        equipo1 = equipos[0].Game5;
                        equipo2 = equipos[1].Game5;
                        break;
                    default:
                        break;
                }

                respuesta = (equipo1 > equipo2 && esPrimero) || (equipo2 > equipo1 && !esPrimero) ? "text-green-400" : "text-red-400";
            }
            catch (Exception ex)
            {
                Excepcion.BitacoraErrores(ex.ToString(), equipos);
            }

            return respuesta;
        }

        public static string ObtenerImagen(string? url)
        {
            return string.IsNullOrEmpty(url) ? Constantes.ImagenPorDefecto : url;
        }
    }
}
