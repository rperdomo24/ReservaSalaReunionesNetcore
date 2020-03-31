using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaSalaReuniones.Util.Identity
{
    /// <summary>
    /// Entidad que mapea los campos a recuperar de un token
    /// </summary>
    public class TokenData
    {
        private int _expiresIn;

        /// <summary>
        /// Strig de token de acceso
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Token de refresco (si aplica)
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// Recurso al que se tiene acceso
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// Segundos de expiracion del token
        /// </summary>
        public int ExpiresIn
        {
            get { return _expiresIn; }
            set
            {
                _expiresIn = value;
                ExpiryTime = DateTime.Now.AddSeconds(value);
            }
        }
        /// <summary>
        /// Fecha y hora de sistema de expiración del token (basado en ExpiresIn)
        /// </summary>
        public DateTime ExpiryTime { get; set; }
    }
}
