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
    public class UsuarioDal
    {
        public async Task<List<Usuario>> ListaObjeto()
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.Usuario.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Usuario>> ObtenerObjetosPorQuery(Expression<Func<Usuario, bool>> expression)
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.Usuario.Where(expression).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<Usuario> ObtenerObjetoPorQuery(Expression<Func<Usuario, bool>> expression)
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.Usuario
                    .AsNoTracking()
                    .Include(x => x.Reserva)
                    .Include(x => x.RolUsuario)
                    .ThenInclude(x => x.IdRolNavigation)
                    .FirstOrDefaultAsync(expression);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<bool> ValidarExistenciaObjeto(Expression<Func<Usuario, bool>> expression)
        {
            try
            {
                using var db = new ReservasalareunionesdbContext();
                return await db.Usuario
                    .AnyAsync(expression);
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
                var dataObj = Obj as Usuario;
                var Datos = await db.Usuario.AddAsync(dataObj);
                var a = db.SaveChanges();
                return dataObj.IdUsuario;
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
                var UsuarioA = Obj as Usuario;
                var data = await db.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == UsuarioA.IdUsuario);
                data.NickName = UsuarioA.NickName;
                data.NombreUsuario = UsuarioA.NombreUsuario;
                data.Email = UsuarioA.Email;
                data.Password = UsuarioA.Password;
                data.Estado = UsuarioA.Estado;
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
                var Data = await db.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == IdObj);
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
