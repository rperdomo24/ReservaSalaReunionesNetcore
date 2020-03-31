using Microsoft.EntityFrameworkCore;
using ReservaSalaReuniones.Dal.DataContext;
using ReservaSalaReuniones.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalaReunionesSalaReuniones.Dal
{
    public class Sala_ReunionesDal
    {
        public async Task<List<SalaReuniones>> ListaObjeto()
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.SalaReuniones.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<SalaReuniones>> ObtenerObjetosPorQuery(Expression<Func<SalaReuniones, bool>> expression)
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.SalaReuniones.Where(expression).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<SalaReuniones> ObtenerObjetoPorQuery(Expression<Func<SalaReuniones, bool>> expression)
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.SalaReuniones
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
                var dataObj = Obj as SalaReuniones;
                var Datos = await db.SalaReuniones.AddAsync(dataObj);
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
                var SalaReunionesA = Obj as SalaReuniones;
                var data = await db.SalaReuniones.FirstOrDefaultAsync(x => x.IdSala == SalaReunionesA.IdSala);
                data.NombreSala= SalaReunionesA.NombreSala;
                data.Descripcion = SalaReunionesA.Descripcion;
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
                var Data = await db.SalaReuniones.FirstOrDefaultAsync(x => x.IdSala == IdObj);
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
