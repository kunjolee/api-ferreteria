using api_ferreteria.Models.article;
using api_ferreteria.Models.Client;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static api_ferreteria.Models.Client.csClienteStructure;

namespace api_ferreteria.Controllers
{
    [ApiController]
    [Route("api")]


    public class clienteController : ControllerBase
    {

        [HttpPost]
        [Route("saveCliente")]
        public dynamic saveArticle(requesClient model)
        {
            return Ok(new csCliente().insertClient(model.nombre, model.apellido, model.DPI));

        }


        [HttpPost]
        [Route("updateClient")]
        public dynamic updateClient(requesClient model)
        {
            return Ok(new csCliente().updateClient(model.idCliente, model.nombre, model.apellido, model.DPI));
        }


        [HttpPost]
        [Route("deleteArticle")]
        public dynamic deleteArticle(requestDeleteCliente model)
        {
            return Ok(new csArticle().deleteArticle(model.idArticulo));

        }

        [HttpGet]
        [Route("listClient")]
        public dynamic listArticles()
        {
            return Ok(new csCliente().listClient());
        }

        [HttpGet]
        [Route("listClientById")]
        public dynamic listArticlesById(string IdCliente)
        {

            return Ok(new csArticle().listArticlesById(Int32.Parse(IdCliente)));
        }


    }

    

}
