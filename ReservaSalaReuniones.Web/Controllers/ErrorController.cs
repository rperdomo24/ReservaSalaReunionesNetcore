using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReservaSalaReuniones.Web.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {

        [Route("Error")]
        public IActionResult Error()
        {
            return View("Default");
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpstatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("Error404");
                case 500:
                    return View("Error505");
                default:
                    return View("Default");

            }
        }

        public IActionResult SinPermisos()
        {
            return View();
        }

    }
}