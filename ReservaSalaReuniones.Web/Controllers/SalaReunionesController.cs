using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReservaSalaReuniones.En;
using ReservaSalaReuniones.En.ModelView;
using ReservaSalaReuniones.Web.Extension;
using ReservaSalaReuniones.Web.Extension.ApiRest;
using ReservaSalaReuniones.Web.Herramientas.Diccionario;

namespace ReservaSalaReuniones.Web.Controllers
{
    [Authorize]
    public class SalaReunionesController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly string url;

        public SalaReunionesController(IConfiguration configuration)
        {
            this.configuration = configuration;
            url = string.Format("{0}{1}", configuration.GetSection("UrlApi").Get<string>(), "SalaReuniones");
        }

        // GET: SalaReuniones
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerSalas()
        {
            var Salas = new List<SalaReuniones>();
            Salas = HttpClientHelper.Request<List<SalaReuniones>>(url, HttpMethodEnum.Get, null, PrincipalExtensions.FindFirstValue(User, "Token"));
            return Json(new { data = Salas });

        }

        // GET: SalaReuniones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalaReuniones/Create
        public ActionResult Create()
        {
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

        // POST: SalaReuniones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalaReuniones DatosSala)
        {
            string _Titulo = Notificaciones.TituloDefault;
            string _Descripcion = Notificaciones.DescripcionDefault;
            string _Tipo = Notificaciones.TipoDefault.ToString();
            string Pantalla = Notificaciones.PantallaCrear;

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

            return RedirectToAction(Pantalla);
        }

        // GET: SalaReuniones/Edit/5
        public ActionResult Edit(int id)
        {
            NotificacionesHelper Notificacion = NotificacionesHelper.GetNotificacionesHelper(this);
            if (Notificacion != null)
            {
                ViewBag.NotificacionTipo = Notificacion._Tipo;
                ViewBag.NotificacionTitulo = Notificacion._Titulo;
                ViewBag.NotificacionMensaje = Notificacion._Mensaje;
                NotificacionesHelper.EliminarNotificacionesHelper(this);
            }

            var Salas = new SalaReuniones();
            Salas = HttpClientHelper.Request<SalaReuniones>(url + "/" + id, HttpMethodEnum.Get, null, PrincipalExtensions.FindFirstValue(User, "Token"));
            return View(Salas);
        }

        // POST: SalaReuniones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalaReuniones DatosSala)
        {
            string _Titulo = Notificaciones.TituloDefault;
            string _Descripcion = Notificaciones.DescripcionDefault;
            string _Tipo = Notificaciones.TipoDefault.ToString();
            string Pantalla = Notificaciones.PantallaModificar;

            var Salas = HttpClientHelper.Request<int>(url, HttpMethodEnum.PutJson, DatosSala, PrincipalExtensions.FindFirstValue(User, "Token"));
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

            return RedirectToAction(Pantalla, new { id = DatosSala.IdSala });
        }

        // GET: SalaReuniones/Delete/5
        public ActionResult Delete(int id)
        {
            string _Titulo = Notificaciones.TituloDefault;
            string _Descripcion = Notificaciones.DescripcionDefault;
            string _Tipo = Notificaciones.TipoDefault.ToString();
            string Pantalla = Notificaciones.PantallaIndex;

            var Salas = HttpClientHelper.Request<int>(url + "/" + id, HttpMethodEnum.Delete, null, PrincipalExtensions.FindFirstValue(User, "Token"));
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

            return RedirectToAction(Pantalla);
        }

    }
}