using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class ComplejoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.Request.ComplejoRequest model)
        {
        
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var oComplejo = new Models.COMPLEJO();
                oComplejo.NOMBRE = model.NOMBRE;
                oComplejo.DUEÑO = model.DUEÑO;
                db.COMPLEJO.Add(oComplejo);
                db.SaveChanges();

            }

            return Ok("Exito!");
        }
    }
}

