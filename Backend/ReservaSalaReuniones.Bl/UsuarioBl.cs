using ReservaSalaReuniones.Bl.Iservices;
using ReservaSalaReuniones.Dal;
using ReservaSalaReuniones.En;
using ReservaSalaReuniones.Util.Cripto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaSalaReuniones.Bl.Utilidades;

namespace ReservaSalaReuniones.Bl
{
    public class UsuarioBl : IUsuarioBl
    {
        UsuarioDal UsuarioDal = new UsuarioDal();

        public async Task<int> AgregarObjetoAsync(Usuario Obj)
        {

            bool _Estado = true;
            Obj.Estado = _Estado;
            Obj.Password = EncriptadoPassword.HashPassword(Obj.Password);
            return await UsuarioDal.AgregarObjeto(Obj);
        }

        public async Task<int> EliminarObjetoAsync(int IdObj)
        {
            return await UsuarioDal.EliminarObjeto(IdObj);
        }

        public async Task<List<Usuario>> ListaObjetoAsync()
        {
            return await UsuarioDal.ListaObjeto();
        }

        public async Task<int> ModificarObjetoAsync(Usuario Obj)
        {
            return await UsuarioDal.ModificarObjeto(Obj);
        }

        public async Task<Usuario> ObtenerObjetoIdAsync(int IdObj)
        {
            var data = new Usuario();
            if (IdObj != 0)
            {
                data = await UsuarioDal.ObtenerObjetoPorQuery(x => x.IdUsuario == IdObj && x.Estado);
            }
            return data;
        }

        public async Task<Usuario> ObtenerObjetoPorQuery(Expression<Func<Usuario, bool>> expression)
        {
            var data = await UsuarioDal.ObtenerObjetoPorQuery(expression);
            return data.WithoutPassword();
        }

        public async Task<List<Usuario>> ObtenerObjetosPorQueryAsync(Expression<Func<Usuario, bool>> expression)
        {
            var Datos = await UsuarioDal.ObtenerObjetosPorQuery(expression);
            return Datos.WithoutPasswords();
        }

        public async Task<Usuario> ValidarUsuario(Usuario Obj)
        {
            var Datauser = new Usuario();
            Datauser = await UsuarioDal.ObtenerObjetoPorQuery(
                x => x.NickName == Obj.NickName && x.Estado
                );

            if (EncriptadoPassword.VerifyPassword(Datauser.Password, Obj.Password))
                return Datauser.WithoutPassword();
            else
                return null;
        }
    }
}
