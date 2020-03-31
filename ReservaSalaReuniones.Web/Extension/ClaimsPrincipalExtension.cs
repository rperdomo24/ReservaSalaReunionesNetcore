using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Web.Extension
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Recupera el valor de un claim si el usuario esta autenticado
        /// </summary>
        /// <typeparam name="TDataType">Tipo de dato esperado</typeparam>
        /// <param name="User">Contexto a utilizar</param>
        /// <param name="claim">Claim a buscar</param>
        /// <returns>Valor del claim buscado</returns>
        public static TDataType ObtenerClaim<TDataType>(this ClaimsPrincipal User, string claim)
        {
            if (User.Identity.IsAuthenticated)
            {
                var resultado = User.Claims.Where(x => x.Type == claim).FirstOrDefault();
                if (resultado != null)
                {
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(TDataType));
                    return (TDataType)tc.ConvertFrom(resultado.Value);
                }
                else
                {
                    return default(TDataType);
                }
            }
            else
            {
                return default(TDataType);
            }
        }
    }
}
