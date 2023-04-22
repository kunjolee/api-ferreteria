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
        public dynamic saveClient(requesClient model)
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
        [Route("deleteClient")]
        public dynamic deleteClient(requestDeleteCliente model)
        {
            return Ok(new csCliente().deleteClient(model.idClient));

        }

        [HttpGet]
        [Route("listClient")]
        public dynamic listClients()
        {
            return Ok(new csCliente().listClient());
        }

        [HttpGet]
        [Route("listClientById")]
        public dynamic listClientsById(string IdCliente)
        {

            return Ok(new csCliente().listArticlesById(Int32.Parse(IdCliente)));
        }


    }

    

}
