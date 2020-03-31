using ReservaSalaReuniones.Web.Herramientas.Enums.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Web.Herramientas.Diccionario
{
    public class Notificaciones
    {
        public const string TituloDefault = "Error";
        public const string TituloDefaultExito = "Exito!";
        public const string TituloDefaultAdvertencia = "Advertencia!";


        public const string DescripcionDefault = "Ha ocurrido un error, por favor vuelva a intentarlo";
        public const string DescripcionExitoDefault = "Acción realizada correctamente.";
        public const string DescripcionAgregar = "Elemento Guardado correctamente";
        public const string DescripcionModificar = "Elemento modificado correctamente";
        public const string DescripcionEliminar = "Elemento eliminado correctamente";

        public const string PantallaIndex = "Index";
        public const string PantallaCrear = "Create";
        public const string PantallaModificar = "Edit";

        public const TipoNotificaciones TipoDefaultExito = TipoNotificaciones.success;
        public const TipoNotificaciones TipoDefaultadvertencia = TipoNotificaciones.warning;
        public const TipoNotificaciones TipoDefault = TipoNotificaciones.error;
    }
}
