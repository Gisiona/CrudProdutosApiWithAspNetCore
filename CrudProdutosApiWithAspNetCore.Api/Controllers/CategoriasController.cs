using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Route("api/v1/categories")]
    public class CategoriasController: ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriasController(ICategoriaRepositorio repositorio)
        {
            _categoriaRepositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _categoriaRepositorio.GetAllAsync();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var data = await _categoriaRepositorio.GetByIdAsync(id);
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = await _categoriaRepositorio.Add(categoria);
            return Ok(data);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategoria([FromBody] Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = await _categoriaRepositorio.Update(categoria);
            return Ok(data);
        }


        [HttpPut]
        public async Task<IActionResult> DeleteCategoria([FromBody] Categoria categoria)
        {
            _categoriaRepositorio.Delete(categoria);
            return Ok("Registro excluído com sucesso.");
        }
    }
}
