using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class UsuarioController : ApiController
    {
       
        [HttpPost]
        public IHttpActionResult Add(Models.Request.UsuarioRequest model)
        {

            using ( Models.MiCanchaDBContext db = new Models.MiCanchaDBContext() )
            {
                var oUsuario = new Models.USUARIO();
                oUsuario.NOMBRE = model.NOMBRE;
                oUsuario.APELLIDO = model.APELLIDO;
                oUsuario.PASS = model.PASS;
                oUsuario.TIPO_USUARIO = model.TIPO_USUARIO;
                db.USUARIO.Add(oUsuario);
                db.SaveChanges();

            }

            return Ok("Exito!");
        }
    }
}
