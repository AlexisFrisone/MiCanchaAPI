using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class CanchaController : ApiController
    {
        const string _OK = "OK";
        const string _Error_Turnos = "Existen turnos asignados para esta cancha "; 

        [HttpPost]
        public IHttpActionResult Add(Models.Request.CanchaRequest model)
        {
            
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try { 
                    var oCancha= new Models.CANCHA();
                    oCancha.NOMBRE = model.NOMBRE;
                    oCancha.COMPLEJO_ID = model.COMPLEJO_ID;
                    oCancha.PRECIO = model.PRECIO;
                    db.CANCHA.Add(oCancha);
                    db.SaveChanges();
                 }
                catch (DbEntityValidationException e)
                {
                    return BadRequest(e.Message);
                }

        }

            return Ok(_OK);
        }


        //get de canchas by complejo ID
        [HttpGet]
        public IEnumerable<Models.Request.CanchaRequest> getCanchaByComplejo(string complejo)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                
                var listResult = new List<Models.Request.CanchaRequest>();
                var listDBSet = db.CANCHA.ToList();
                foreach (var element in listDBSet)
                {
                    if (element.COMPLEJO_ID == Int32.Parse(complejo))
                    {
                        var result = new Models.Request.CanchaRequest();
                        result.ID = element.ID;
                        result.NOMBRE = element.NOMBRE;
                        result.COMPLEJO_ID = element.COMPLEJO_ID;
                        result.PRECIO = element.PRECIO;

                        listResult.Add(result);
                    }

                }

                return listResult;
            }

        }

        [HttpGet]
        public Models.Request.CanchaRequest GetId(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var result = new Models.Request.CanchaRequest();
                var listDBSet = db.CANCHA.Where(x => x.ID == id);
                foreach (var element in listDBSet)
                {
                    if (element.ID == id)
                    {
                        result.ID = element.ID;
                        result.NOMBRE = element.NOMBRE;
                        result.PRECIO = element.PRECIO;
                        result.COMPLEJO_ID = element.COMPLEJO_ID;
                    }

                }

                return result;
            }
        }


        [HttpGet]
        public IEnumerable<Models.Request.CanchaRequest> GetAll()
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var listResult = new List<Models.Request.CanchaRequest>();
                var listDBSet = db.CANCHA.ToList();
                foreach (var element in listDBSet)
                {
                    var result = new Models.Request.CanchaRequest();
                    result.ID = element.ID;
                    result.NOMBRE = element.NOMBRE;
                    result.COMPLEJO_ID = element.COMPLEJO_ID;
                    result.PRECIO = element.PRECIO;

                    listResult.Add(result);
                }

                return listResult;
            }


        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var turnos = db.TURNOS.ToList().FirstOrDefault(c => c.CANCHA_ID == id);
                if (turnos is null)
                {
                    db.CANCHA.Remove(db.CANCHA.ToList().Find(c => c.ID == id));
                    db.SaveChanges();
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotImplemented, _Error_Turnos);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, _OK);
        }

        [HttpPut]
        public IHttpActionResult Update(Models.Request.CanchaRequest model)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try
                {
                    var oCanchaModel = db.CANCHA.ToList().FirstOrDefault(c => c.ID == model.ID);
                    if (oCanchaModel == null)
                    {
                        var oCancha = new Models.CANCHA();
                        oCancha.NOMBRE = model.NOMBRE;
                        oCancha.COMPLEJO_ID = model.COMPLEJO_ID;
                        oCancha.PRECIO = model.PRECIO;
                        db.CANCHA.Add(oCancha);
                    }
                    else
                    {
                        oCanchaModel.NOMBRE = model.NOMBRE;
                        oCanchaModel.PRECIO = model.PRECIO;
                        oCanchaModel.COMPLEJO_ID = model.COMPLEJO_ID;
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

