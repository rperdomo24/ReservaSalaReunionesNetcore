using ReservaSalaReuniones.Bl.Iservices;
using ReservaSalaReuniones.Dal;
using ReservaSalaReuniones.En;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Bl
{
    public class ReservaBl : IReservaBl
    {
        ReservaDal ReservaDal = new ReservaDal();

        public async Task<int> AgregarObjetoAsync(Reserva Obj)
        {
            bool _Estado = true;
            Obj.Estado = _Estado;
            if (string.IsNullOrEmpty(Obj.ColorReserva))
            {
                //color default
                Obj.ColorReserva = "rgb(25, 105, 44)";
            }
            return await ReservaDal.AgregarObjeto(Obj);
        }

        public async Task<int> EliminarObjetoAsync(int IdObj)
        {
            return await ReservaDal.EliminarObjeto(IdObj);
        }

        public async Task<List<Reserva>> ListaObjetoAsync()
        {
            return await ReservaDal.ListaObjeto();
        }

        public async Task<int> ModificarObjetoAsync(Reserva Obj)
        {
            return await ReservaDal.ModificarObjeto(Obj);
        }


        public async Task<Reserva> ObtenerObjetoIdAsync(int IdObj)
        {
            var data = new Reserva();
            if (IdObj != 0)
            {
                data = await ReservaDal.ObtenerObjetoPorQuery(x => x.IdReserva == IdObj && x.Estado);
            }
            return data;
        }

        public async Task<Reserva> ObtenerObjetoPorQuery(Expression<Func<Reserva, bool>> expression)
        {
            return await ReservaDal.ObtenerObjetoPorQuery(expression);
        }

        public async Task<List<Reserva>> ObtenerObjetosPorQueryAsync(Expression<Func<Reserva, bool>> expression)
        {
            return await ReservaDal.ObtenerObjetosPorQuery(expression);
        }
    }
}
