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
    public class SalaReunionesController : ControllerBase
    {
        private readonly ISala_ReunionesBl _salaReuniones;

        public SalaReunionesController(ISala_ReunionesBl SalaReuniones)
        {
            _salaReuniones = SalaReuniones;
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult> CreateSala([FromBody] SalaReuniones Obj)
        {
            if (ModelState.IsValid)
            {
                var result = await _salaReuniones.AgregarObjetoAsync(Obj);
                if (result > 0) return Ok(result);

                else return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}", Name = "GetSala")]
        public async Task<ActionResult> GetSala(int Id)
        {
            if (Id > 0)
            {
                var Data = await _salaReuniones.ObtenerObjetoIdAsync(Id);
                if (Data != null) return Ok(Data);
                else return BadRequest();
            }
            else
            {
                return BadRequest("Sala no encontrada");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetSala()
        {
            var Data = await _salaReuniones.ObtenerObjetosPorQueryAsync(x => x.Estado);
            if (Data != null) return Ok(Data);
            else return BadRequest();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public async Task<ActionResult> PutSala([FromBody] SalaReuniones Obj)
        {
            if (ModelState.IsValid)
            {
                var result = await _salaReuniones.ModificarObjetoAsync(Obj);
                if (result > 0) return Ok(result);
                else return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{Id}", Name = "DeleteSala")]
        public async Task<ActionResult> DeleteSala(int Id)
        {
            if (Id > 0)
            {
                var result = await _salaReuniones.EliminarObjetoAsync(Id);
                if (result > 0) return Ok(result);

                else return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}