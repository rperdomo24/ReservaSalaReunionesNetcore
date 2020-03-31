using ReservaSalaReuniones.Bl.Iservices;
using ReservaSalaReuniones.Dal;
using ReservaSalaReuniones.En;
using SalaReunionesSalaReuniones.Dal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Bl
{
    public class Sala_ReunionesBl : ISala_ReunionesBl
    {
        Sala_ReunionesDal Sala_ReunionesDal = new Sala_ReunionesDal();

        public async Task<int> AgregarObjetoAsync(SalaReuniones Obj)
        {
            bool _Estado = true;
            Obj.Estado = _Estado;
            return await Sala_ReunionesDal.AgregarObjeto(Obj);
        }

        public async Task<int> EliminarObjetoAsync(int IdObj)
        {
            return await Sala_ReunionesDal.EliminarObjeto(IdObj);
        }

        public async Task<List<SalaReuniones>> ListaObjetoAsync()
        {
            return await Sala_ReunionesDal.ListaObjeto();
        }

        public async Task<int> ModificarObjetoAsync(SalaReuniones Obj)
        {
            return await Sala_ReunionesDal.ModificarObjeto(Obj);
        }


        public async Task<SalaReuniones> ObtenerObjetoIdAsync(int IdObj)
        {
            var data = new SalaReuniones();
            if (IdObj != 0)
            {
                data = await Sala_ReunionesDal.ObtenerObjetoPorQuery(x => x.IdSala == IdObj && x.Estado);
            }
            return data;
        }

        public async Task<SalaReuniones> ObtenerObjetoPorQuery(Expression<Func<SalaReuniones, bool>> expression)
        {
            return await Sala_ReunionesDal.ObtenerObjetoPorQuery(expression);
        }

        public async Task<List<SalaReuniones>> ObtenerObjetosPorQueryAsync(Expression<Func<SalaReuniones, bool>> expression)
        {
            return await Sala_ReunionesDal.ObtenerObjetosPorQuery(expression);
        }
    }
}
