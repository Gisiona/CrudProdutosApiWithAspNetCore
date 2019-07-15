using Microsoft.AspNetCore.Mvc;

namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    public class TesteController: ControllerBase
    {
        [HttpGet]
        public ActionResult get()
        {
            return Ok("TUDO OK.");
        }
    }
}
