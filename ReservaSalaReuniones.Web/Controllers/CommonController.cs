using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReservaSalaReuniones.En.ModelView;
using ReservaSalaReuniones.En.ModelView.Usuario;
using ReservaSalaReuniones.Web.Extension.ApiRest;

namespace ReservaSalaReuniones.Web.Controllers
{
    public class CommonController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly string url;

        public CommonController(IConfiguration configuration)
        {
            this.configuration = configuration;
            url = string.Format("{0}{1}", configuration.GetSection("UrlApi").Get<string>(), "Token");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Common(LoginModelView DatosUsuario, string returnUrl)
        {
            var result = HttpClientHelper.Request<ResultTokenModelView>(url, HttpMethodEnum.PostJson, DatosUsuario);

            if (result != null)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim("Id", result.DatosUsario.IdUsuario.ToString()),
                    new Claim("NickName", result.DatosUsario.NickName),
                    new Claim("Name", result.DatosUsario.NombreUsuario),
                    new Claim("Email", result.DatosUsario.Email),
                    new Claim(ClaimTypes.Role,result.DatosUsario.RolUsuario.FirstOrDefault().IdRolNavigation.NombreRol),
                    new Claim ("Token",result.Token )
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Reserva");
            }

            ModelState.AddModelError(string.Empty, "Inicio de sesión no válido");
            return View("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}