using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservaSalaReuniones.Bl;
using ReservaSalaReuniones.Bl.Iservices;

namespace ReservaSalaReuniones.Api.Middleware
{
    public static class IoC
    {
        public static IServiceCollection DependecyInyection(this IServiceCollection services)
        {
            services.AddTransient<IReservaBl, ReservaBl>();
            services.AddTransient<ISala_ReunionesBl, Sala_ReunionesBl>();
            services.AddTransient<IUsuarioBl, UsuarioBl>();

            return services;
        }
    }
}
