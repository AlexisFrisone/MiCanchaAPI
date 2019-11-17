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
        const string _Error_Turno = "Error , Turno reservado ";

        [HttpPost]
        public IHttpActionResult Add(Models.Request.TurnoRequest model)
        {

            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try
                {
                    var oTurno = new Models.TURNOS();
                    oTurno.USUARIO_ID = model.USUARIO_ID;
                    oTurno.CANCHA_ID = model.CANCHA_ID;
                    oTurno.HORA_INGRESO = model.HORA_INGRESO;
                    oTurno.RESERVADO = model.RESERVADO;
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
        public HttpResponseMessage Delete(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                /* Solo se borran los turnos no reservados*/
                var turno  = db.TURNOS.ToList().Find(t => t.ID == id && t.RESERVADO == true );
                if (turno is null)
                {
                    db.TURNOS.Remove(db.TURNOS.ToList().Find(t => t.ID == id));
                    db.SaveChanges();
                }else
                {
                   return  Request.CreateResponse(HttpStatusCode.NotImplemented, _Error_Turno);
                }
               
            }

            return Request.CreateResponse(HttpStatusCode.OK, _OK);
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
                    result.USUARIO_ID = element.USUARIO_ID;
                    result.HORA_INGRESO = element.HORA_INGRESO;
                    result.RESERVADO = element.RESERVADO;

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
                var listDBSet = db.TURNOS.Where(x => x.ID == id);
                foreach (var element in listDBSet)
                {
                    if (element.ID == id)
                    {
                        var result = new Models.Request.TurnoRequest();
                        result.ID = element.ID;
                        result.CANCHA_ID = element.CANCHA_ID;
                        result.USUARIO_ID = element.USUARIO_ID;
                        result.HORA_INGRESO = element.HORA_INGRESO;
                        result.RESERVADO = element.RESERVADO;
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
                        oTurno.USUARIO_ID = model.USUARIO_ID;
                        oTurno.CANCHA_ID = model.CANCHA_ID;
                        oTurno.HORA_INGRESO = model.HORA_INGRESO;
                        db.TURNOS.Add(oTurno);

                    }
                    else
                    {
                        oTurnoModel.CANCHA_ID = model.CANCHA_ID;
                        oTurnoModel.USUARIO_ID = model.USUARIO_ID;
                        oTurnoModel.HORA_INGRESO = model.HORA_INGRESO;
                        oTurnoModel.RESERVADO = model.RESERVADO;
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
                    if (element.USUARIO_ID == Int32.Parse(userId))
                    {
                        var result = new Models.Request.TurnoRequest();
                        result.ID = element.ID;                 
                        result.CANCHA_ID = element.CANCHA_ID;
                        result.USUARIO_ID = element.USUARIO_ID;

                        listResult.Add(result);
                    }
                }

                return listResult;
            }


        }


        [HttpGet]
        public IEnumerable<Models.Request.TurnoRequest> GetTurnoByCancha(string canchaId)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var listResult = new List<Models.Request.TurnoRequest>();
                var listDBSet = db.TURNOS.ToList();

                foreach (var element in listDBSet)
                {
                    if (element.CANCHA_ID == Int32.Parse(canchaId))
                    {
                        var result = new Models.Request.TurnoRequest();
                        result.ID = element.ID;
                        result.CANCHA_ID = element.CANCHA_ID;
                        result.USUARIO_ID = element.USUARIO_ID;
                        result.HORA_INGRESO = element.HORA_INGRESO;
                        result.RESERVADO = element.RESERVADO;
                        
                        listResult.Add(result);
                    }
                }

                return listResult;
            }


        }
    }


}


