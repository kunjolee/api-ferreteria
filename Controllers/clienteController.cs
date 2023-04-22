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
        [Route("saveClients")]
        public dynamic saveClient(requesClient model)
        {
            return Ok(new csCliente().insertClient(model.nombre, model.apellido, model.DPI));

        }


        [HttpPost]
        [Route("updateClients")]
        public dynamic updateClient(requesClient model)
        {
            return Ok(new csCliente().updateClient(model.idCliente, model.nombre, model.apellido, model.DPI));
        }


        [HttpPost]
        [Route("deleteClients")]
        public dynamic deleteClient(requestDeleteCliente model)
        {

            return Ok(new csCliente().deleteClient(model.idCliente));

        }

        [HttpGet]
        [Route("listClients")]
        public dynamic listClients()
        {
            return Ok(new csCliente().listClient());
        }

        [HttpGet]
        [Route("listClientsById")]
        public dynamic listClientsById(string IdCliente)
        {

            return Ok(new csCliente().listArticlesById(Int32.Parse(IdCliente)));
        }


    }

    

}
