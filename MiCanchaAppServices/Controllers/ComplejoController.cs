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
        [HttpPost]
        public IHttpActionResult Add(Models.Request.ComplejoRequest model)
        {
            const string _OK = "OK";
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
               
                try
                {
                    var oComplejo = new Models.COMPLEJO();
                    oComplejo.NOMBRE = model.NOMBRE;
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

        [HttpGet]
        public Models.Request.ComplejoRequest GetId(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var result = new Models.Request.ComplejoRequest();
                var listDBSet = db.COMPLEJO.ToList();
                foreach (var element in listDBSet)
                {
                    if (element.ID == id)
                    {
                        result.ID = element.ID;
                        result.NOMBRE = element.NOMBRE;
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

                    listResult.Add(result);
                }

                return listResult;
            }


        }


    }
}

