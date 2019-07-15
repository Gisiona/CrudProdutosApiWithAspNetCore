using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Authorize]
    [Route("api/v1/users")]
    public class UsuariosController: ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsuarioAll()
        {
            var data = await _usuarioRepositorio.GetAllAsync();
            if(data != null)
            {
                return Ok(data);
            }
            return Ok("Nenhum registro encontrado.");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var data = await _usuarioRepositorio.GetByIdAsync(id);
            if (data != null)
            {
                return Ok(data);
            }
            return Ok("Registro não encontrado.");
        }


        [HttpPost()]        
        public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            var data =  _usuarioRepositorio.Add(usuario);
            return Ok(data);
        }



        [HttpPut()]
        public async Task<IActionResult> PutUsuario([FromBody] Usuario usuario)
        {
            var data = _usuarioRepositorio.Update(usuario);
            return Ok(data);
        }



        [HttpDelete()]
        public async Task<IActionResult> DeleteUsuario([FromBody] Usuario usuario)
        {
            _usuarioRepositorio.Delete(usuario);
            return Ok("Registro excluído com sucesso.");
        }
    }
}
