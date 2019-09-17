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
        [HttpPost]
        public IHttpActionResult Add(Models.Request.CanchaRequest model)
        {
            const string _OK = "OK";
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

        [HttpGet]
        public Models.Request.CanchaRequest GetId(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var result = new Models.Request.CanchaRequest();
                var listDBSet = db.CANCHA.ToList();
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

    }

}

