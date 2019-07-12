using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutosApiWithAspNetCore.Api.Controllers
{
    [Route("api/[Controller]")]
    public class TesteController: ControllerBase
    {
        public ActionResult get()
        {
            return Ok("passei e retornei");
        }
    }
}
