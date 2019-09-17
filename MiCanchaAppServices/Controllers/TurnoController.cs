using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            const string _OK = "OK";
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try
                {
                    var oTurno = new Models.TURNOS();
                    oTurno.USUARIO = model.USUARIO_ID;
                    oTurno.CANCHA_ID = model.CANCHA_ID;
                    oTurno.FECHA = model.FECHA;
                    db.TURNOS.Add(oTurno);
                    db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

            return Ok(_OK);
        }


        [HttpGet]
        public IEnumerable<Models.Request.TurnoRequest> GetAll()
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var listResult = new List<Models.Request.TurnoRequest>();
                var listDBSet = db.TURNOS.ToList();
                foreach (var element in listDBSet)
                {
                    var result = new Models.Request.TurnoRequest();
                    result.ID = element.ID;
                    result.CANCHA_ID = element.CANCHA_ID;
                    result.USUARIO_ID = element.USUARIO;

                    listResult.Add(result);
                }

                return listResult;
            }


        }

        
        [HttpGet]
        public Models.Request.TurnoRequest GetId(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var result = new Models.Request.TurnoRequest();
                var listDBSet = db.TURNOS.ToList();
                foreach(var element in listDBSet)
                {
                    if(element.ID == id)
                    {
                        result.ID = element.ID;
                        result.CANCHA_ID = element.CANCHA_ID;
                        result.USUARIO_ID = element.USUARIO;
                    }

                }

                return result;
            }
        }

    }
}
