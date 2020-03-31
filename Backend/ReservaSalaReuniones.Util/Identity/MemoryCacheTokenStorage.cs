using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaSalaReuniones.Util.Identity
{
    /// <summary>
    /// Implementación de almacenamiento de Token de acceso utilizando Memory Cache de ASP.NET Core
    /// </summary>
    public class MemoryCacheTokenStorage : ITokenStorage
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheTokenStorage(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Recupera el token de autenticación al recurso especificado
        /// </summary>
        /// <param name="recurso">Nombre del recurso</param>
        /// <returns>Datos del token de autenticación</returns>
        public TokenData ObtenerToken(string recurso)
        {
            TokenData token;
            _cache.TryGetValue<TokenData>(recurso, out token);
            return token;
        }

        /// <summary>
        /// Asigna/actualiza el token de autenticación para el recurso especificado
        /// </summary>
        /// <param name="recurso">Nombre del recurso</param>
        /// <param name="token">Datos del token de autenticación a guardar/actualizar</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        public bool AsignarActualizarToken(string recurso, TokenData token)
        {
            return _cache.Set<TokenData>(recurso, token) != null;
        }
    }
}
