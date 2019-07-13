using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[Controller]")]
    public class ProdutosController: ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutosController(IProdutoRepositorio repositorio)
        {
            _produtoRepositorio = repositorio;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _produtoRepositorio.GetAllAsync();
            return Ok(data);
        }
        
    }
}
