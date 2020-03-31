using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Web.ModelView.BreadCrums
{
    /// <summary>
    /// Representa un breadcrum en el header del layout.
    /// </summary>
    public class BreadCrum
    {
        /// <summary>
        /// Representa un breadcrum en el header del layout.<br />
        /// Inicializa una nueva instancia de la clase <see cref="BreadCrum" />
        /// </summary>
        /// <param name="name">Nombre a mostrar en el breadcrum (requerido).</param>
        public BreadCrum(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Representa un breadcrum en el header del layout.<br />
        /// Inicializa una nueva instancia de la clase <see cref="BreadCrum" />
        /// </summary>
        /// <param name="name">Nombre a mostrar en el breadcrum (requerido).</param>
        /// <param name="action">Acción de la ruta de redirección.</param>
        public BreadCrum(string name, string action)
        {
            this.Name = name;
            this.Action = action;
        }

        /// <summary>
        /// Representa un breadcrum en el header del layout.<br />
        /// Inicializa una nueva instancia de la clase <see cref="BreadCrum" />
        /// </summary>
        /// <param name="name">Nombre a mostrar en el breadcrum (requerido).</param>
        /// <param name="action">Acción de la ruta de redirección.</param>
        /// <param name="controller">Controllador de la ruta de redirección.</param>
        public BreadCrum(string name, string action, string controller)
        {
            this.Name = name;
            this.Action = action;
            this.Controller = controller;
        }

        /// <summary>
        /// Representa un breadcrum en el header del layout.<br />
        /// Inicializa una nueva instancia de la clase <see cref="BreadCrum" />
        /// </summary>
        /// <param name="name">Nombre a mostrar en el breadcrum (requerido).</param>
        /// <param name="action">Acción de la ruta de redirección.</param>
        /// <param name="controller">Controllador de la ruta de redirección.</param>
        /// <param name="values">Values de la ruta de redirección.</param>
        public BreadCrum(string name, string action, string controller, object values)
        {
            this.Name = name;
            this.Action = action;
            this.Controller = controller;
            this.Values = values;
        }

        /// <summary>
        /// Nombre a mostrar en el breadcrum (requerido).
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Valor para el redireccionamiento.
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Valor para el redireccionamiento.
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Valor para el redireccionamiento.
        /// </summary>
        public object Values { get; set; }
    }
}
