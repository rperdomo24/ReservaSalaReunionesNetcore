using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReservaSalaReuniones.En;
using ReservaSalaReuniones.En.ModelView.EventosCalendario;
using ReservaSalaReuniones.Web.Extension;
using ReservaSalaReuniones.Web.Extension.ApiRest;
using ReservaSalaReuniones.Web.Herramientas.Diccionario;

namespace ReservaSalaReuniones.Web.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly string url;

        public ReservaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            url = string.Format("{0}{1}", configuration.GetSection("UrlApi").Get<string>(), "Reserva");
        }

        public ActionResult Index(string Id = null)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                ViewBag.Tipe = Id;
            }
            NotificacionesHelper Notificacion = NotificacionesHelper.GetNotificacionesHelper(this);
            if (Notificacion != null)
            {
                ViewBag.NotificacionTipo = Notificacion._Tipo;
                ViewBag.NotificacionTitulo = Notificacion._Titulo;
                ViewBag.NotificacionMensaje = Notificacion._Mensaje;
                NotificacionesHelper.EliminarNotificacionesHelper(this);
            }
            return View();
        }

        public JsonResult ObtenerReservas(int id)
        {
            var Salas = new List<Eventos>();
            Salas = HttpClientHelper.Request<List<Eventos>>(url + "/" + id, HttpMethodEnum.Get, null, PrincipalExtensions.FindFirstValue(User, "Token"));
            return Json(new { data = Salas });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reserva DatosSala)
        {
            DatosSala.IdUsuario = Convert.ToInt32(PrincipalExtensions.FindFirstValue(User, "Id"));

            string _Titulo = Notificaciones.TituloDefault;
            string _Descripcion = Notificaciones.DescripcionDefault;
            string _Tipo = Notificaciones.TipoDefault.ToString();
            string Pantalla = Notificaciones.PantallaIndex;

            var Salas = HttpClientHelper.Request<int>(url, HttpMethodEnum.PostJson, DatosSala, PrincipalExtensions.FindFirstValue(User, "Token"));
            if (Salas > 0)
            {
                _Titulo = Notificaciones.TituloDefaultExito;
                _Tipo = Notificaciones.TipoDefaultExito.ToString();
                _Descripcion = Notificaciones.DescripcionAgregar;
            }

            NotificacionesHelper.SetNotificacionesHelper(this,
                  _Tipo,
                  _Titulo,
                  _Descripcion);

            return RedirectToAction(Pantalla, new { Id = DatosSala.IdSala });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: SalaReuniones/Delete/5
        public ActionResult Delete(Reserva DatosSala)
        {
            string _Titulo = Notificaciones.TituloDefault;
            string _Descripcion = Notificaciones.DescripcionDefault;
            string _Tipo = Notificaciones.TipoDefault.ToString();
            string Pantalla = Notificaciones.PantallaIndex;

            var Salas = HttpClientHelper.Request<int>(url + "/" + DatosSala.IdReserva, HttpMethodEnum.Delete, null, PrincipalExtensions.FindFirstValue(User, "Token"));
            if (Salas > 0)
            {
                _Titulo = Notificaciones.TituloDefaultExito;
                _Tipo = Notificaciones.TipoDefaultExito.ToString();
                _Descripcion = Notificaciones.DescripcionModificar;
            }

            NotificacionesHelper.SetNotificacionesHelper(this,
                  _Tipo,
                  _Titulo,
                  _Descripcion);

            return RedirectToAction(Pantalla, new { Id = DatosSala.IdSala });
        }

    }
}