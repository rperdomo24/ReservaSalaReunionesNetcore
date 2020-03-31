using ReservaSalaReuniones.En;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Bl.Iservices
{
    public interface IReservaBl
    {
        Task<List<Reserva>> ObtenerObjetosPorQueryAsync(Expression<Func<Reserva, bool>> expression);
        Task<Reserva> ObtenerObjetoPorQuery(Expression<Func<Reserva, bool>> expression);
        Task<Reserva> ObtenerObjetoIdAsync(int IdObj);
        Task<int> AgregarObjetoAsync(Reserva Obj);
        Task<int> ModificarObjetoAsync(Reserva Obj);
        Task<int> EliminarObjetoAsync(int IdObj);
    }
}
