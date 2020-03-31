using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaSalaReuniones.Util.Identity
{
    /// <summary>
    /// Definiciones de almacenamiento de Token de acceso
    /// </summary>
    public interface ITokenStorage
    {
        /// <summary>
        /// Recupera el token de autenticación al recurso especificado
        /// </summary>
        /// <param name="recurso">Nombre del recurso</param>
        /// <returns>Datos del token de autenticación</returns>
        TokenData ObtenerToken(string recurso);

        /// <summary>
        /// Asigna/actualiza el token de autenticación para el recurso especificado
        /// </summary>
        /// <param name="recurso">Nombre del recurso</param>
        /// <param name="token">Datos del token de autenticación a guardar/actualizar</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        bool AsignarActualizarToken(string recurso, TokenData token);
    }
}
