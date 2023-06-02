using System;
//using System.Web.Http;
using static api_ferreteria.Models.Empleado.csEmpleadoStructure;
using api_ferreteria.Models.Empleado;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace api_ferreteria.Controllers
{
    [ApiController]
    [Route("api")]

    public class empleadoController : ControllerBase
    {
        [HttpPost]
        [Route("saveEmpleado")]
        public dynamic saveEmpleado(requestEmpleado model)
        {
            return Ok(new csEmpleado().insertEmpleado(model.nombre, model.apellido, model.idUsuario));

        }

        [HttpPost]
        [Route("updateEmpleado")]
        public dynamic updateEmpleado(requestEmpleado model)
        {
            return Ok(new csEmpleado().updateEmpleado(model.idEmpleado, model.nombre, model.apellido, model.idUsuario));

        }
        [HttpPost]
        [Route("deleteEmpleado")]
        public dynamic deleteEmpleado(requestDeleteEmpleado model)
        {
            return Ok(new csEmpleado().deleteEmpleado(model.idEmpleado));

        }

        [HttpGet]
        [Route("listEmpleados")]
        public dynamic listEmpleados()
        {
            return Ok(new csEmpleado().listEmpleados());
        }

        [HttpGet]
        [Route("listEmpleadosById")]
        public dynamic listEmpleadosById(string idArticulo)
        {

            return Ok(new csEmpleado().listEmpleadosById(Int32.Parse(idArticulo)));
        }

    }
}

//declara un metodo de tipo post que puede recibir un JSON

//para poder recibir el JSON en mi metodo, necesito crearme una clase en los modelos,
//y mandarlo como argumento