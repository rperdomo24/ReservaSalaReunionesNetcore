using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReservaSalaReuniones.Util.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaSalaReuniones.Dal.DataContext
{
    public partial class ReservasalareunionesdbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().FromAppSettings();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
