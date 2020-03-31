using ReservaSalaReuniones.En;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Bl.Iservices
{
    public interface ISala_ReunionesBl
    {
        Task<List<SalaReuniones>> ObtenerObjetosPorQueryAsync(Expression<Func<SalaReuniones, bool>> expression);
        Task<SalaReuniones> ObtenerObjetoPorQuery(Expression<Func<SalaReuniones, bool>> expression);
        Task<SalaReuniones> ObtenerObjetoIdAsync(int IdObj);
        Task<int> AgregarObjetoAsync(SalaReuniones Obj);
        Task<int> ModificarObjetoAsync(SalaReuniones Obj);
        Task<int> EliminarObjetoAsync(int IdObj);
    }
}
