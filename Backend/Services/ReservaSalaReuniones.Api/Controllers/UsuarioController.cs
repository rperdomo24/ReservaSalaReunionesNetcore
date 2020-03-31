using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaSalaReuniones.Bl.Iservices;
using ReservaSalaReuniones.En;

namespace ReservaSalaReuniones.Api.Controllers
{
    [Authorize(Roles = "Administrador,Usuario Basico")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBl _usuario;

        public UsuarioController(IUsuarioBl Usuario)
        {
            _usuario = Usuario;
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Usuario Obj)
        {
            if (ModelState.IsValid)
            {
                if (await _usuario.AgregarObjetoAsync(Obj) > 0) return Ok("Usuario agregado correctamente");

                else return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            var DataUser = await _usuario.ObtenerObjetosPorQueryAsync(x => x.Estado);
            if (DataUser != null) return Ok(DataUser);
            else return BadRequest();
        }

        [HttpGet("{NickName}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string NickName)
        {
            if (!ModelState.IsValid)
            {
                var DataUser = await _usuario.ObtenerObjetoPorQuery(x => x.NickName == NickName && x.Estado);
                if (DataUser != null) return Ok(DataUser);
                else return BadRequest();
            }
            else
            {
                return BadRequest("Ususario no encontrado");
            }
        }

    }
}