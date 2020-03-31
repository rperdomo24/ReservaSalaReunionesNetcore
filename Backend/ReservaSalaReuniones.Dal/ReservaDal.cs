using Microsoft.EntityFrameworkCore;
using ReservaSalaReuniones.Dal.DataContext;
using ReservaSalaReuniones.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Dal
{
    public class ReservaDal
    {
        public async Task<List<Reserva>> ListaObjeto()
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.Reserva.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Reserva>> ObtenerObjetosPorQuery(Expression<Func<Reserva, bool>> expression)
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.Reserva.Where(expression).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public Task<Reserva> ObtenerObjetoPorQuery(Expression<Func<Reserva, bool>> expression)
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return db.Reserva
                    .AsNoTracking()
                    //.Include(x => x.Paquete)
                    .FirstAsync(expression);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<int> AgregarObjeto(object Obj)
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                var dataObj = Obj as Reserva;
                var Datos = await db.Reserva.AddAsync(dataObj);
                var a = db.SaveChanges();
                return dataObj.IdSala;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<int> ModificarObjeto(object Obj)
        {
            try
            {
                var Resultado = 0;
                using var db = new ReservasalareunionesdbContext();
                var SalaReunionesA = Obj as Reserva;
                var data = await db.Reserva.FirstOrDefaultAsync(x => x.IdReserva == SalaReunionesA.IdReserva);
                data.IdUsuario = SalaReunionesA.IdUsuario;
                data.IdSala = SalaReunionesA.IdSala;
                data.FechaInicio = SalaReunionesA.FechaInicio;
                data.FechaFin = SalaReunionesA.FechaFin;
                data.ColorReserva = data.ColorReserva;
                Resultado = db.SaveChanges();
                return Resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<int> EliminarObjeto(int IdObj)
        {
            bool _EliminadoLogico = false;
            try
            {
                using var db = new ReservasalareunionesdbContext();
                var Data = await db.Reserva.FirstOrDefaultAsync(x => x.IdReserva == IdObj);
                Data.Estado = _EliminadoLogico;
                return db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
