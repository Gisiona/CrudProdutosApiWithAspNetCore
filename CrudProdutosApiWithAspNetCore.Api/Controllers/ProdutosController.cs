using CrudProdutosApiWithAspNetCore.Api.Models.Produtos;
using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Authorize]
    [Route("api/v1/products")]
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
            var data = (await _produtoRepositorio.GetAllWithCategoriaAsync())
                .Select(p => p.ToProdutoGet());

            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            var data = await _produtoRepositorio.GetByIdWithCategoriaAsync(id);
            if (data != null) { return Ok(data.ToProdutoGet()); }
            return NotFound("Registro não encontrado.");
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] Produto produto)
        {
            var data = await _produtoRepositorio.Add(produto);            
            return Ok(data.ToProdutoGet());
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduto([FromBody] Produto produto)
        {
            var prod =await _produtoRepositorio.GetByIdAsync(produto.Id);

            if (prod == null) { return NotFound("Registro não encontrado."); }
            var data = await _produtoRepositorio.Update(produto);
            return Ok(data.ToProdutoGet()); 
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduto([FromBody] Produto produto)
        {
            _produtoRepositorio.Delete(produto);
            return Ok("Registro excluído com sucesso.");
        }
    }
}
