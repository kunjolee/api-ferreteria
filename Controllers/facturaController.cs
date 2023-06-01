using System;
using static api_ferreteria.Models.Factura.csFacturaStructure;
using api_ferreteria.Models.Factura;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace api_ferreteria.Controllers
{
    [ApiController]
    [Route("api")]

    public class facturaController : ControllerBase
    {
        [HttpPost]
        [Route("saveFactura")]
        public dynamic saveFactura(requestFactura model)
        {
            return Ok(new csFactura().insertFactura(model.nombre, model.idEmpleado, model.idPago, model.nit, model.fecha, model.total));

        }

        [HttpPost]
        [Route("updateFactura")]
        public dynamic updateFactura(requestFactura model)
        {
            return Ok(new csFactura().updateFactura(model.idFactura, model.nombre, model.idEmpleado, model.idPago, model.nit, model.fecha, model.total));

        }
        [HttpPost]
        [Route("deleteFactura")]
        public dynamic deleteFactura(requestDeleteFactura model)
        {
            return Ok(new csFactura().deleteFactura(model.idFactura));

        }

        [HttpGet]
        [Route("listFactura")]
        public dynamic listFactura()
        {
            return Ok(new csFactura().listFactura());
        }

        [HttpGet]
        [Route("listFacturaById")]
        public dynamic listFacturaById(string idFactura)
        {

            return Ok(new csFactura().listFacturaById(Int32.Parse(idFactura)));
        }

        [HttpGet]
        [Route("listFacturaDetails")]
        public dynamic listFacturaDetails(string idFactura)
        {

            return Ok(new csFactura().listFacturaDetails(Int32.Parse(idFactura)));
        }


    }
}

