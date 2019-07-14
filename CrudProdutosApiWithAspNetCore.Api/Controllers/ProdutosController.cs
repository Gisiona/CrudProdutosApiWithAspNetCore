using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutosById(int id)
        {
            var data = await _produtoRepositorio.GetByIdAsync(id);
            if (data != null) { return Ok(data); }
            var data1 = "Registro não encontrado.";
            return Ok(data1);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProdutos([FromBody] Produto produto)
        {
            var data = await _produtoRepositorio.Add(produto);            
            return Ok(data);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProdutos([FromBody] Produto produto)
        {
            var data = await _produtoRepositorio.Update(produto);
            return Ok(data);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProdutos([FromBody] Produto produto)
        {
            _produtoRepositorio.Delete(produto);
            return Ok("Registro excluído com sucesso.");
        }
    }
}
