using api_ferreteria.Models.article;
using Microsoft.AspNetCore.Mvc;
//using static api_ferreteria.Models.article.csArticleStructure;

namespace api_ferreteria.Controllers
{
    [ApiController]
    [Route("api")]


    public class clienteController : ControllerBase
    {

        [HttpPost]
        [Route("saveClient")]
        public dynamic saveArticle()
        {
            return Ok(new csCliente().;

        }



    }

    

}
