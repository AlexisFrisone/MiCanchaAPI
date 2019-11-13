using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class ComplejoController : ApiController
    {
        const string _OK = "OK";
        const string _Error_Canchas = "Existen canchas asociadas al complejo";


        [HttpPost]
        public IHttpActionResult Add(Models.Request.ComplejoRequest model)
        {

            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {


                try
                {
                    var oComplejo = new Models.COMPLEJO();
                    oComplejo.NOMBRE = model.NOMBRE;
                    oComplejo.DUENIO_ID = model.DUENIO_ID;
                    oComplejo.DIRECCION = model.DIRECCION;
                    oComplejo.TELEFONO_COMPLEJO = model.TELEFONO_COMPLEJO;
                    oComplejo.EMAIL_COMPLEJO = model.EMAIL_COMPLEJO;
                    db.COMPLEJO.Add(oComplejo);
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

                var cancha = db.CANCHA.ToList().Find(c => c.COMPLEJO_ID == id);
                if (cancha is null)
                {
                    db.COMPLEJO.Remove(db.COMPLEJO.ToList().Find(c => c.ID == id));
                    db.SaveChanges();
                } else
                {
                    return Request.CreateResponse(HttpStatusCode.NotImplemented, _Error_Canchas);
                }                
            }

            return Request.CreateResponse(HttpStatusCode.OK, _OK );

        }

        [HttpGet]
        public Models.Request.ComplejoRequest GetId(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var result = new Models.Request.ComplejoRequest();
                var listDBSet = db.COMPLEJO.Where(x => x.ID == id);
          
                 foreach (var element in listDBSet)
                {
                    if (element.ID == id)
                    {
                        result.ID = element.ID;
                        result.NOMBRE = element.NOMBRE;
                        result.DUENIO_ID = element.DUENIO_ID;
                        result.DIRECCION = element.DIRECCION;
                        result.TELEFONO_COMPLEJO = element.TELEFONO_COMPLEJO;
                        result.EMAIL_COMPLEJO = element.EMAIL_COMPLEJO;
                    }

                }

                return result;
            }
        }


        [HttpGet]
        public IEnumerable<Models.Request.ComplejoRequest> GetAll()
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {

                var listResult = new List<Models.Request.ComplejoRequest>();
                var listDBSet = db.COMPLEJO.ToList();
                foreach (var element in listDBSet)
                {
                    var result = new Models.Request.ComplejoRequest();
                    result.ID = element.ID;
                    result.NOMBRE = element.NOMBRE;
                    result.DUENIO_ID = element.DUENIO_ID;
                    result.DIRECCION = element.DIRECCION;
                    result.TELEFONO_COMPLEJO = element.TELEFONO_COMPLEJO;
                    result.EMAIL_COMPLEJO = element.EMAIL_COMPLEJO;

                    listResult.Add(result);
                }

                return listResult;
            }

        }

        [HttpPut]
        public IHttpActionResult Update(Models.Request.ComplejoRequest model)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try
                {
                    var oComplejoModel = db.CANCHA.ToList().FirstOrDefault(c => c.ID == model.ID);
                    if (oComplejoModel == null)
                    {
                        var oComplejo = new Models.COMPLEJO();
                        oComplejo.NOMBRE = model.NOMBRE;
                        oComplejo.DUENIO_ID = model.DUENIO_ID;
                        oComplejo.DIRECCION = model.DIRECCION;
                        oComplejo.TELEFONO_COMPLEJO = model.TELEFONO_COMPLEJO;
                        oComplejo.EMAIL_COMPLEJO = model.EMAIL_COMPLEJO;
                        db.COMPLEJO.Add(oComplejo);

                    }
                    else
                    {
                        oComplejoModel.NOMBRE = model.NOMBRE;
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
    }
}

