using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Route("api/v1/wishes")]
    public class DesejosController : ControllerBase
    {
        private readonly IDesejoRepositorio _desejoRepositorio;

        public DesejosController(IDesejoRepositorio repositorio)
        {
            _desejoRepositorio = repositorio;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDesejos()
        {
            var data = await _desejoRepositorio.GetAllAsync();
            return Ok(data);
        }


        [HttpGet("{userid}/users")]
        public async Task<IActionResult> GetAllDesejosByUserId(int userid)
        {
            var data = await _desejoRepositorio.GetDesejosByUserIdAsync(userid);

            if(data == null) { return NotFound("Registro não encontrado.");}
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesejoById(int id)
        {
            var data = await _desejoRepositorio.GetDesejosByIdWithProdutosAsync(id);

            if (data == null) { return NotFound("Registro não encontrado."); }
            return Ok(data);
        }



        [HttpPost]
        public async Task<IActionResult> PostDesejo([FromBody] Desejo desejo)
        {
            if (!ModelState.IsValid) { return BadRequest();  }
            var data = await _desejoRepositorio.Add(desejo);
            return Ok(data);
            //return CreatedAtRoute("id", new { data.Id }, data);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDesejoByIdAndUserId(int id, [FromBody] Desejo desejo)
        {
            var dese = await _desejoRepositorio.GetByIdAsync(id);
            if (dese == null) { return NotFound("Registro não encontrado."); }
            
            var data = await _desejoRepositorio.Update(dese);

            return Ok(data);
        }

        [HttpDelete("{userid}/{productid}")]
        public async Task<IActionResult> DeleteDesejoByUserIdAndByProductId(int userid, int productid, [FromBody] Desejo _desejo)
        {
            var data = await _desejoRepositorio.GetDesejoByUserIdAndProductIdAsync(userid, productid);


            if (data == null) { return NotFound("Registro não encontrado."); }            
            
            _desejoRepositorio.Delete(_desejo);

            return Ok("Wishe excluído com sucesso.");
        }
    }
}


