using System;
//using System.Web.Http;
using static api_ferreteria.Models.User.csUserStructure;
using api_ferreteria.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using api_ferreteria.Models.article;

namespace api_ferreteria.Controllers
{

    //ruta
    [ ApiController ]
    [ Route("api") ]

    public class userController: ControllerBase
    {
        [ HttpPost ]
        [Route("saveUser")]
        public dynamic saveUser( requestUser model )
        {
            return Ok( new csUser().insertUser( model.idUsuario, model.correo, model.telefono, model.direccion, model.fechaNacimiento ) );
        }

        [ HttpPost ]
        [Route("updateUser")]
        public dynamic updateUser(requestUser model)
        {
            return Ok(new csUser().updateUser(model.idUsuario, model.correo, model.telefono, model.direccion, model.fechaNacimiento));
        }

        [HttpPost]
        [Route("deleteUser")]
        public dynamic deleteUser(requestDelteUser model)
        {
            return Ok(new csUser().deleteUser(model.idUsuario));
        }

        [HttpGet]
        [Route("listUsers")]
        public dynamic listUsers()
        {
            return Ok(new csUser().listUsers());
        }

        [HttpGet]
        [Route("listUsersById")]
        public dynamic listUsersById(string idUsuario)
        {

            return Ok(new csUser().listUsersById(Int32.Parse(idUsuario)));
        }
    }
}
