using System;
using static api_ferreteria.Models.FacturaDetalle.csFacturaDetalleStructure;
using api_ferreteria.Models.FacturaDetalle;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace api_ferreteria.Controllers
{
    [ApiController]
    [Route("api")]

    public class FacturaDetalleController : ControllerBase
    {
        [HttpPost]
        [Route("saveFacturaDetalle")]
        public dynamic saveFacturaDetalle(requestFacturaDetalle model)
        {
            return Ok(new csFacturaDetalle().insertFacturaDetalle(model.idFactura, model.idArticulo, model.cantidad, model.subtotal));

        }

        [HttpPost]
        [Route("updateFacturaDetalle")]
        public dynamic updateFacturaDetalle(requestFacturaDetalle model)
        {
            return Ok(new csFacturaDetalle().updateFacturaDetalle(model.idFacturaDetalle, model.idFactura, model.idArticulo, model.cantidad, model.subtotal));

        }
        [HttpPost]
        [Route("deleteFacturaDetalle")]
        public dynamic deleteFacturaDetalle(requestDeleteFacturaDetalle model)
        {
            return Ok(new csFacturaDetalle().deleteFacturaDetalle(model.idFacturaDetalle));

        }

        [HttpGet]
        [Route("listFacturaDetalle")]
        public dynamic listFacturaDetalle()
        {
            return Ok(new csFacturaDetalle().listFacturaDetalle());
        }

        [HttpGet]
        [Route("listFacturaDetalleById")]
        public dynamic listFacturaDetalleById(string idArticulo)
        {

            return Ok(new csFacturaDetalle().listFacturaDetalleById(Int32.Parse(idArticulo)));
        }

    }
}

