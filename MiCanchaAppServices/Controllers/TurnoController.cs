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
        const string _OK = "OK";

        [HttpPost]
        public IHttpActionResult Add(Models.Request.TurnoRequest model)
        {

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

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                db.TURNOS.Remove(db.TURNOS.ToList().Find(t => t.ID == id));
                db.SaveChanges();
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
                var listDBSet = db.TURNOS.Where(x => x.ID == id);
                foreach (var element in listDBSet)
                {
                    if (element.ID == id)
                    {
                        result.ID = element.ID;
                        result.CANCHA_ID = element.CANCHA_ID;
                        result.USUARIO_ID = element.USUARIO;
                    }

                }

                return result;
            }
        }



        [HttpPut]
        public IHttpActionResult Update(Models.Request.TurnoRequest model)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try
                {
                    var oTurnoModel = db.TURNOS.ToList().FirstOrDefault(t => t.ID == model.ID);
                    if (oTurnoModel == null)
                    {
                        var oTurno = new Models.TURNOS();
                        oTurno.USUARIO = model.USUARIO_ID;
                        oTurno.CANCHA_ID = model.CANCHA_ID;
                        oTurno.FECHA = model.FECHA;
                        db.TURNOS.Add(oTurno);

                    }
                    else
                    {
                        oTurnoModel.CANCHA_ID = model.CANCHA_ID;
                        oTurnoModel.USUARIO = model.USUARIO_ID;
                        oTurnoModel.FECHA = model.FECHA;
                    }

                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    return BadRequest(e.Message);
                }
                return Ok(_OK);
            }



        }

        [HttpGet]
        public IEnumerable<Models.Request.TurnoRequest> GetTurnoByUser(string userId)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var listResult = new List<Models.Request.TurnoRequest>();
                var listDBSet = db.TURNOS.ToList();

                foreach (var element in listDBSet)
                {
                    if (element.USUARIO == Int32.Parse(userId))
                    {
                        var result = new Models.Request.TurnoRequest();
                        result.ID = element.ID;
                 
                        result.CANCHA_ID = element.CANCHA_ID;
                        result.USUARIO_ID = element.USUARIO;

                        listResult.Add(result);
                    }
                }

                return listResult;
            }


        }
    }


}


