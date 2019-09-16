using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class CanchaController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.Request.CanchaRequest model)
        {
        
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var oCancha= new Models.CANCHA();
                oCancha.NOMBRE = model.NOMBRE;
                oCancha.COMPLEJO = model.COMPLEJO;
                db.CANCHA.Add(oCancha);
                db.SaveChanges();

            }

            return Ok("Exito!");
        }
    }

}

