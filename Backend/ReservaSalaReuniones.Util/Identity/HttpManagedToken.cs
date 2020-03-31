using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReservaSalaReuniones.Util.Identity
{
    //public class HttpManagedToken : HttpClient
    //{
    //    private readonly ITokenStorage _tstorage;
    //    private readonly IIdentityConfiguration _configuracion;

    //    /// <summary>
    //    /// Inicializa una instancia de HttpClient con gestión automática de token de autenticación
    //    /// </summary>
    //    /// <param name="configuracion">Parámetros de configuración del proveedor de identidad</param>
    //    /// <param name="tstorage">Servicio de almacén de tokens</param>
    //    public HttpManagedToken(IIdentityConfiguration configuracion, ITokenStorage tstorage) : base()
    //    {
    //        _tstorage = tstorage;
    //        _configuracion = configuracion;
    //    }

    //    /// <summary>
    //    /// Devuelve una nueva instancia de esta clase
    //    /// </summary>
    //    public HttpManagedToken NewInstance
    //    {
    //        get
    //        {
    //            return new HttpManagedToken(_configuracion, _tstorage);
    //        }
    //    }

    //    /// <summary>
    //    /// Solicita el token de autenticación al Identity Server
    //    /// </summary>
    //    /// <param name="recurso">Nombre de la API a solicitar autorización</param>
    //    /// <returns>Datos de token</returns>
    //    private async Task<TokenData> SolicitarToken(string recurso)
    //    {
    //        TokenData tokenResultado = null;
    //        HttpClient http = new HttpClient();
    //        TokenResponse resultado = await http.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
    //        {
    //            Address = _configuracion.TokenEndpoint,
    //            ClientId = _configuracion.ClientId,
    //            ClientSecret = _configuracion.ClientSecret,
    //            Scope = recurso
    //        });
    //        if (!resultado.IsError)
    //        {
    //            tokenResultado = new TokenData()
    //            {
    //                Scope = recurso,
    //                AccessToken = resultado.AccessToken,
    //                RefreshToken = resultado.RefreshToken,
    //                ExpiresIn = resultado.ExpiresIn
    //            };
    //        }
    //        return tokenResultado;
    //    }

    //    /// <summary>
    //    /// Refresca los datos del token
    //    /// </summary>
    //    /// <param name="token">Datos del token</param>
    //    /// <returns>Token actualizado</returns>
    //    private async Task<TokenData> RefrescarToken(TokenData token, string recurso)
    //    {
    //        TokenData tokenResultado = null;
    //        HttpClient http = new HttpClient();
    //        TokenResponse resultado = await http.RequestRefreshTokenAsync(new RefreshTokenRequest()
    //        {
    //            Address = _configuracion.TokenEndpoint,
    //            RefreshToken = token.RefreshToken
    //        });
    //        if (!resultado.IsError)
    //        {
    //            tokenResultado = new TokenData()
    //            {
    //                Scope = recurso,
    //                AccessToken = resultado.AccessToken,
    //                RefreshToken = resultado.RefreshToken,
    //                ExpiresIn = resultado.ExpiresIn
    //            };
    //        }
    //        return tokenResultado;
    //    }

    //    /// <summary>
    //    /// Agrega el token de Identity Server en la instancia actual
    //    /// </summary>
    //    public void AutoAdministrarToken(string recurso)
    //    {
    //        // Recuperando token de acceso (si existe)
    //        TokenData token = _tstorage.ObtenerToken(recurso);
    //        if (token == null)
    //        {
    //            token = SolicitarToken(recurso).GetAwaiter().GetResult();
    //            if (token != null)
    //            {
    //                _tstorage.AsignarActualizarToken(recurso, token);
    //            }
    //        }
    //        if (token != null)
    //        {
    //            // Verificando si el token esta expirado o por expirar
    //            TimeSpan diferencia = token.ExpiryTime.Subtract(DateTime.Now);
    //            if (diferencia.TotalSeconds <= _configuracion.SegundosTolerancia)
    //            {
    //                // Verificando si hay que renovar o volver a solicitar el token
    //                if (!string.IsNullOrWhiteSpace(token.RefreshToken))
    //                {
    //                    token = RefrescarToken(token, recurso).GetAwaiter().GetResult();
    //                }
    //                else
    //                {
    //                    token = SolicitarToken(recurso).GetAwaiter().GetResult();
    //                }
    //                // Guardando en el almacen de tokens
    //                if (token != null)
    //                {
    //                    _tstorage.AsignarActualizarToken(recurso, token);
    //                }
    //            }
    //        }
    //        // Agregando encabezado. Si token es nulo al hacer asignacion nula quita el encabezado
    //        if (!string.IsNullOrWhiteSpace(token.AccessToken))
    //        {
    //            this.SetBearerToken(token.AccessToken);
    //        }
    //    }
    //}
}
