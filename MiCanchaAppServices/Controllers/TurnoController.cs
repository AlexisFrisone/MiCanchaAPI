using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class TurnoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.Request.TurnoRequest model)
        {

            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var oTurno = new Models.TURNOS();
                oTurno.USUARIO = model.USUARIO;
                oTurno.CANCHA_ID = model.CANCHA_ID;
                oTurno.FECHA = model.FECHA;
                db.TURNOS.Add(oTurno);
                db.SaveChanges();
         
            }

            return Ok("Exito!");
        }
    }
}
