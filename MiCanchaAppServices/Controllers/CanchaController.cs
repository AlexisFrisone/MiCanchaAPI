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
        [HttpPost]
        public IHttpActionResult Add(Models.Request.CanchaRequest model)
        {
            
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try { 
                    var oCancha= new Models.CANCHA();
                    oCancha.NOMBRE = model.NOMBRE;
                    oCancha.COMPLEJO = model.COMPLEJO_ID;
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
                var result = new Models.Request.CanchaRequest();
                var listResult = new List<Models.Request.CanchaRequest>();
                var listDBSet = db.CANCHA.ToList();
                foreach (var element in listDBSet)
                {
                    if (element.COMPLEJO == Int32.Parse(complejo))
                    {
                        result.ID = element.ID;
                        result.NOMBRE = element.NOMBRE;
                        result.COMPLEJO_ID = element.COMPLEJO;

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
                        result.COMPLEJO_ID = element.COMPLEJO;
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
                    result.COMPLEJO_ID = element.COMPLEJO;

                    listResult.Add(result);
                }

                return listResult;
            }


        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                db.CANCHA.Remove(db.CANCHA.ToList().Find(c => c.ID == id));
                db.SaveChanges();
            }

                return Ok(_OK);
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
                        oCancha.COMPLEJO = model.COMPLEJO_ID;
                        db.CANCHA.Add(oCancha);
                    }
                    else
                    {
                        oCanchaModel.NOMBRE = model.NOMBRE;
                        oCanchaModel.COMPLEJO = model.COMPLEJO_ID;
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

