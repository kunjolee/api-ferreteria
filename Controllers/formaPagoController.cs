using System;
using api_ferreteria.Models.FormaPago;
using static api_ferreteria.Models.FormaPago.csFormaPagoStructure;

using Microsoft.AspNetCore.Mvc;
using api_ferreteria.Models.article;

namespace api_ferreteria.Controllers
{

    [ApiController]
    [Route("api")]

    public class formaPagoController : ControllerBase
    {
        [HttpPost]
        [Route("saveFormaPago")]
        public dynamic saveFormaPago(requestFormaPago model)
        {
            return Ok(new csFormaPago().insertFormaPago(model.idPago, model.tipo));
        }

        [HttpPost]
        [Route("updateFormaPago")]
        public dynamic updateFormaPago(requestFormaPago model)
        {
            return Ok(new csFormaPago().updateFormaPago(model.idPago, model.tipo));
        }

        [HttpPost]
        [Route("deleteFormaPago")]
        public dynamic deleteFormaPago(requestDeleteFormaPago model)
        {
            return Ok(new csFormaPago().deleteFormaPago(model.idPago));
        }

        [HttpGet]
        [Route("listFormaPagos")]
        public dynamic listArticles()
        {
            return Ok(new csFormaPago().listFormaPago());
        }

        [HttpGet]
        [Route("listFormaPagosById")]
        public dynamic listArticlesById(string idPago)
        {

            return Ok(new csFormaPago().listFormaPagoById(Int32.Parse(idPago)));
        }
    }



}

