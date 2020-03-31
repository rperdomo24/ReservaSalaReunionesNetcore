using ReservaSalaReuniones.En;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Bl.Iservices
{
    public interface IUsuarioBl
    {
        Task<List<Usuario>> ObtenerObjetosPorQueryAsync(Expression<Func<Usuario, bool>> expression);
        Task<Usuario> ObtenerObjetoPorQuery(Expression<Func<Usuario, bool>> expression);

        Task<Usuario> ValidarUsuario(Usuario Obj);

        Task<Usuario> ObtenerObjetoIdAsync(int IdObj);
        Task<int> AgregarObjetoAsync(Usuario Obj);
        Task<int> ModificarObjetoAsync(Usuario Obj);
        Task<int> EliminarObjetoAsync(int IdObj);
    }
}
