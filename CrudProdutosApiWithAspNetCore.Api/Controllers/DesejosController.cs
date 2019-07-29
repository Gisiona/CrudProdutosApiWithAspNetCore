using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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


        [HttpGet("{userid}/{pagesize}/{page}")]
        public async Task<IActionResult> GetAllDesejosByUserIdSearchPagination(int userid, int pageSize =5, int page =1 )
        {
            IList<Desejo> data = (IList<Desejo>) await _desejoRepositorio.GetDesejosByUserIdAsync(userid);
            int totalPaginas = data.Count / Convert.ToInt32(pageSize);            
           
            HttpContext.Response.HttpContext.Response.Headers.TryAdd("X-Pages-TotalPages", totalPaginas.ToString());

            if (data == null) { return NotFound("Registro não encontrado."); }
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesejoById(int id)
        {
            var data = await _desejoRepositorio.GetDesejosByIdAsync(id);

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
            if (desejo.UsuarioId <= 0)
            {

            }
            else if (desejo.ProdutoId <= 0)
            {

            }
            else if (desejo.Id <= 0)
            {

            }
            else if (string.IsNullOrEmpty(desejo.Descricao))
            {

            }

            Task<Desejo> _desejo = _desejoRepositorio.GetDesejoByIdAndUserIdAndProductIdAsync(desejo.Id, desejo.UsuarioId, desejo.ProdutoId);

            if(_desejo.Result == null) { return NotFound("Registro do desejo não encontrado."); }

            var data = await _desejoRepositorio.UpdateDesejoAsync(_desejo.Result);

            return Ok(data);
        }

        [HttpDelete("{wisheid}/{userid}/{productid}")]
        public async Task<IActionResult> DeleteDesejoDesejoByIdAndUserIdAndByProductId(int wisheid, int userid, int productid)
        {
            Task<Desejo> data = _desejoRepositorio.GetDesejoByIdAsync(wisheid);
            
            if (data.Result == null) { return NotFound("Registro não encontrado."); }            
            
            _desejoRepositorio.Delete(data.Result);

            return Ok("Wishe excluído com sucesso.");
        }
    }
}


