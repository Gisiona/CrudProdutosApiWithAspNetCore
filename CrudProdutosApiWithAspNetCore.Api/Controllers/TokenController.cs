using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Route("api/v1/token")]
    public class TokenController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public TokenController(IConfiguration configuration, IUsuarioRepositorio usuarioRepositorio)
        {
            _configuration = configuration;
            _usuarioRepositorio = usuarioRepositorio;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody] Usuario usuario)
        {
            Usuario _usuario = await _usuarioRepositorio.GetUserByEmailAsync(usuario.Email);
            var _token = string.Empty;
            if (_usuario !=null)
            {
                if(_usuario.Email.Equals(usuario.Email) && _usuario.Senha.Equals(usuario.Senha))
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, _usuario.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                    var assinatura = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken
                        (
                            issuer: _configuration["IssuerToken"],
                            audience: _configuration["IssuerToken"],
                            claims: claims,
                            expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["ExpiredToken"])),
                            signingCredentials: assinatura
                        );

                    return Ok(
                        _token = new JwtSecurityTokenHandler().WriteToken(token)
                        );                   

                }
            }
            return BadRequest("Credenciais inválidas.");
        }
    }
}
