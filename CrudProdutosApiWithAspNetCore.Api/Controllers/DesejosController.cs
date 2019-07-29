using CrudProdutosApiWithAspNetCore.Api.Models.SaidaRetorno;
using CrudProdutosApiWithAspNetCore.Dominio.Entidades;
using CrudProdutosApiWithAspNetCore.Dominio.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Authorize]
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

            if (data == null)
            {
                return NotFound(
                new ResultadoViewModel()
                {
                    StatusCode = NotFound().StatusCode,
                    Sucesso = false,
                    Mensagem = "Registro não encontrado.",
                    Data = data
                });
            }

            return Ok(new ResultadoViewModel()
            {
                StatusCode = 200,
                Sucesso = true,
                Mensagem = "Registro retornado com sucesso.",
                Data = data
            });            
        }


        [HttpGet("{userid}/users")]
        public async Task<IActionResult> GetAllDesejosByUserId(int userid)
        {
            var data = await _desejoRepositorio.GetDesejosByUserIdAsync(userid);

            if (data == null)
            {
                return NotFound(
                new ResultadoViewModel()
                {
                    StatusCode = NotFound().StatusCode,
                    Sucesso = false,
                    Mensagem = "Registro não encontrado.",
                    Data = data
                });
            }

            return Ok(new ResultadoViewModel()
            {
                StatusCode = 200,
                Sucesso = true,
                Mensagem = "Registro retornado com sucesso.",
                Data = data
            });
        }


        [HttpGet("{userid}/{pagesize}/{page}")]
        public async Task<IActionResult> GetAllDesejosByUserIdSearchPagination(int userid, int pageSize =5, int page =1 )
        {
            IList<Desejo> data = (IList<Desejo>) await _desejoRepositorio.GetDesejosByUserIdAsync(userid);
            int totalPaginas = data.Count / Convert.ToInt32(pageSize);            
           
            HttpContext.Response.HttpContext.Response.Headers.TryAdd("X-Pages-TotalPages", totalPaginas.ToString());

            if (data == null)
            {
                return NotFound(
                new ResultadoViewModel()
                    {
                       StatusCode = NotFound().StatusCode,
                       Sucesso = false,
                       Mensagem = "Registro não encontrado.",
                       Data = data
                });
            }

            return Ok(new ResultadoViewModel()
            {
                StatusCode = 200,
                Sucesso = true,
                Mensagem = "Registro retornado com sucesso.",
                Data = data
            });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesejoById(int id)
        {
            ResultadoViewModel resultado;
            Task<Desejo> data = _desejoRepositorio.GetDesejoByIdAsync(id);

            if (data.Result == null)
            {
                return NotFound(new ResultadoViewModel()
                {
                    StatusCode = NotFound().StatusCode,
                    Sucesso = false,
                    Mensagem = "Nenhum registro não encontrado.",
                    Data = data.Result
                });
            }
               
            return Ok(resultado = new ResultadoViewModel()
            {
                StatusCode = 200,
                Sucesso = true,
                Mensagem = "Registro retornado com sucesso.",
                Data = data.Result
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostDesejo([FromBody] Desejo desejo)
        {
            if (!ModelState.IsValid) { return BadRequest();  }
            var data = await _desejoRepositorio.Add(desejo);

            return Ok(new ResultadoViewModel()
            {
                StatusCode = 201,
                Sucesso = true,
                Mensagem = "Registro criado com sucesso.",
                Data = data
            });

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesejoByIdAndUserId([FromBody] Desejo desejo)
        {
            Task<Desejo> _desejo = _desejoRepositorio.GetDesejoByIdAndUserIdAndProductIdAsync(desejo.Id, desejo.UsuarioId, desejo.ProdutoId);

            if(_desejo.Result == null)
            {
                return NotFound(
                    new ResultadoViewModel()
                    {
                        StatusCode = NotFound().StatusCode,
                        Sucesso = false,
                        Mensagem = "Registro do desejo não encontrado.",
                        Data = _desejo.Result
                    });
            }

            var data = await _desejoRepositorio.UpdateDesejoAsync(_desejo.Result);

            return Ok(new ResultadoViewModel()
            {
                StatusCode = 200,
                Sucesso = true,
                Mensagem = "Registro atualizado com sucesso.",
                Data = _desejo.Result
            });
        }

        [HttpDelete("{wisheid}/{userid}/{productid}")]
        public async Task<IActionResult> DeleteDesejoDesejoByIdAndUserIdAndByProductId(int wisheid, int userid, int productid)
        {
            Task<Desejo> data = _desejoRepositorio.GetDesejoByIdAsync(wisheid);
            
            if (data.Result == null)
            {
                return NotFound(new ResultadoViewModel()
                {
                    StatusCode = NotFound().StatusCode,
                    Sucesso = false,
                    Mensagem = "Registro não encontrado.",
                    Data = data.Result
                });
            }      
            
            _desejoRepositorio.Delete(data.Result);

            return Ok(new ResultadoViewModel()
            {
                StatusCode = 200,
                Sucesso = true,
                Mensagem = "Wishe excluído com sucesso.",
                Data = null
            });
        }
    }
}


