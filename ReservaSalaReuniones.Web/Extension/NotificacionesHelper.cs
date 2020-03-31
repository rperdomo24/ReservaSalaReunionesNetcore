using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Web.Extension
{
    public class NotificacionesHelper
    {
        public string _Tipo { get; set; }
        public string _Mensaje { get; set; }
        public string _Titulo { get; set; }

        /// <summary>
        /// Establece un tempdata con la infor que se mostrar en la alerta
        /// </summary>
        /// <param name="controller">Nombre controlador donde se usuará</param>
        /// <param name="Tipo">Tipo de notificación</param>
        /// <param name="Titulo">Titulo de notificación</param>
        /// <param name="Mensaje">Mensaje de notificación</param>
        public static void SetNotificacionesHelper(Controller controller, string Tipo, string Titulo, string Mensaje)
        {
            NotificacionesHelper Notificacion = new NotificacionesHelper
            {
                _Tipo = Tipo,
                _Titulo = Titulo,
                _Mensaje = Mensaje
            };
            controller.TempData["TempNotificacion"] = JsonConvert.SerializeObject(Notificacion);
        }

        /// <summary>
        /// Obtiene Tempdata con la información necesaria
        /// </summary>
        /// <param name="controller">Nombre controlador</param>
        /// <returns>Retorna la información guardada en un temp data</returns>
        public static NotificacionesHelper GetNotificacionesHelper(Controller controller)
        {
            try
            {
                NotificacionesHelper Notificacion = JsonConvert.DeserializeObject<NotificacionesHelper>(controller.TempData["TempNotificacion"] as string)
                    as NotificacionesHelper;
                return Notificacion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Elimina la información de un Temp data
        /// </summary>
        /// <param name="controller">Elimina información de un tempdara</param>
        public static void EliminarNotificacionesHelper(Controller controller)
        {
            controller.TempData.Remove("TempNotificacion");
        }
    }
}
