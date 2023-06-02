using System;
//using System.Web.Http;
using static api_ferreteria.Models.article.csArticleStructure;
using api_ferreteria.Models.article;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace api_ferreteria.Controllers
{
    [ApiController]
    [Route("api")]

    public class articleController: ControllerBase
	{
		[HttpPost]
		[Route("saveArticle")]
		public dynamic saveArticle(requestArticle model) {
            return Ok(new csArticle().insertArticle(model.nombre, model.stock, model.precio));

        }

        [HttpPost]
        [Route("updateArticle")]
        public dynamic updateArticle(requestArticle model) {
            return Ok(new csArticle().updateArticle(model.idArticulo, model.nombre, model.stock, model.precio));

        }
        [HttpPost]
        [Route("deleteArticle")]
        public dynamic deleteArticle(requestDeleteArticle model) {
            return Ok(new csArticle().deleteArticle(model.idArticulo));

        }

        [HttpGet]
        [Route("listArticles")]
        public dynamic listArticles() {
            return Ok(new csArticle().listArticles());
        }

        [HttpGet]
        [Route("listArticlesById")]
        public dynamic listArticlesById(string idArticulo) {
            
            return Ok(new csArticle().listArticlesById(Int32.Parse(idArticulo)));
        }

    }
}

//declara un metodo de tipo post que puede recibir un JSON

//para poder recibir el JSON en mi metodo, necesito crearme una clase en los modelos,
//y mandarlo como argumento