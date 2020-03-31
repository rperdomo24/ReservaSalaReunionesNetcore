using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReservaSalaReuniones.Bl.Iservices;
using ReservaSalaReuniones.En;
using ReservaSalaReuniones.En.ModelView;
using ReservaSalaReuniones.En.ModelView.Usuario;

namespace ReservaSalaReuniones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUsuarioBl _usuario;

        public TokenController(IConfiguration config, IUsuarioBl Usuario)
        {
            _configuration = config;
            _usuario = Usuario;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModelView _userData)
        {

            if (ModelState.IsValid)
            {
                var user = await _usuario.ValidarUsuario(new Usuario() { NickName = _userData.NickName, Password = _userData.Password });

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.IdUsuario.ToString()),
                    new Claim("NickName", user.NickName),
                    new Claim("Name", user.NombreUsuario),
                    new Claim("Email", user.Email),
                    new Claim(ClaimTypes.Role,user.RolUsuario.FirstOrDefault().IdRolNavigation.NombreRol)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    var tokenresult = new JwtSecurityTokenHandler().WriteToken(token);


                    return Ok(
                        new ResultTokenModelView()
                        {
                            DatosUsario = user,
                            Token = tokenresult
                        });

                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}