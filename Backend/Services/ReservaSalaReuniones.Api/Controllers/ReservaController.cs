using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaSalaReuniones.Bl.Iservices;
using ReservaSalaReuniones.En;
using ReservaSalaReuniones.En.ModelView.EventosCalendario;

namespace ReservaSalaReuniones.Api.Controllers
{
    [Authorize(Roles = "Administrador,Usuario Basico")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaBl _Reserva;

        public ReservaController(IReservaBl reserva)
        {
            _Reserva = reserva;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReserva([FromBody] Reserva Obj)
        {
            if (ModelState.IsValid)
            {
                var result = await _Reserva.AgregarObjetoAsync(Obj);
                if (result > 0) return Ok(result);

                else return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpGet]
        //public async Task<ActionResult> GetReserva()
        //{
        //    var Data = await _Reserva.ObtenerObjetosPorQueryAsync(x => x.Estado);
        //    if (Data != null) return Ok(Data);
        //    else return BadRequest();
        //}


        [HttpGet("{Id}", Name = "GetReservaCalendar")]
        public async Task<ActionResult> GetReservaCalendar(int Id)
        {
            var Data = await _Reserva.ObtenerObjetosPorQueryAsync(x => x.Estado && x.IdSala == Id);
            var parsedata = Data.Select(x => new Eventos()
            {
                Id = x.IdReserva,
                backgroundColor = x.ColorReserva,
                start = x.FechaInicio,
                end = x.FechaFin,
                title = x.DescripcionReserva
            }
            );
            if (Data != null) return Ok(parsedata);

            else return BadRequest();
        }

        //[HttpGet("{Id}", Name = "GetReserva")]
        //public async Task<IActionResult> GetReserva(int Id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var Data = await _Reserva.ObtenerObjetoPorQuery(x => x.IdReserva == Id);
        //        if (Data != null) return Ok(Data);
        //        else return BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest("Ususario no encontrado");
        //    }
        //}

        [HttpPut]
        public async Task<ActionResult> PutReserva([FromBody] Reserva Obj)
        {
            if (ModelState.IsValid)
            {
                if (await _Reserva.ModificarObjetoAsync(Obj) > 0) return Ok();
                else return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{Id}", Name = "DeleteReserva")]
        public async Task<ActionResult> DeleteReserva(int Id)
        {
            if (Id > 0)
            {
                var result = await _Reserva.EliminarObjetoAsync(Id);
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