using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Web.ModelView.BreadCrums
{
    /// <summary>
    /// Encapsula lista de breadcrums para el header del layout.
    /// </summary>
    public class BreadCrums
    {
        /// <summary>
        /// Encapsula lista de breadcrums para el header del layout.
        /// Inicializa una nueva instancia de la clase <see cref="BreadCrum"/>
        /// </summary>
        /// <param name="breadCrums">Lista de breadcrums.</param>
        public BreadCrums(params BreadCrum[] breadCrums)
        {
            this.ListBreadCrums = new List<BreadCrum>();
            //{
            //    new BreadCrum("Inicio", nameof(HomeController.Index), typeof(HomeController).ControllerName())
            //};
            this.ListBreadCrums.AddRange(breadCrums?.ToList() ?? new List<BreadCrum>());
        }

        /// <summary>
        /// Lista de breadcrums.
        /// </summary>
        public List<BreadCrum> ListBreadCrums { get; set; }
    }
}
