using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class TipoUsuarioController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.Request.TipoUsuarioRequest model)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var oTipoUsuario = new Models.TIPO_USUARIO();
                oTipoUsuario.TIPO_USUARIO1 = model.TIPO_USUARIO;
                oTipoUsuario.ID = model.ID;
                db.TIPO_USUARIO.Add(oTipoUsuario);
                db.SaveChanges();

            }

            return Ok("Exito!");
        }
    }
}
