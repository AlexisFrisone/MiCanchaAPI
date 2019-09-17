using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class UsuarioController : ApiController
    {

         [HttpPost]
        public IHttpActionResult Add(Models.Request.UsuarioRequest model)
        {
            const string _OK = "OK";
            using ( Models.MiCanchaDBContext db = new Models.MiCanchaDBContext() )
            {
                try
                {
                    var oUsuario = new Models.USUARIO();
                    oUsuario.NOMBRE = model.NOMBRE;
                    oUsuario.APELLIDO = model.APELLIDO;
                    oUsuario.PASS = model.PASS;
                    oUsuario.TIPO_USUARIO = model.TIPO_USUARIO_ID;
                    oUsuario.EMAIL = model.EMAIL;
                    db.USUARIO.Add(oUsuario);                
                    db.SaveChanges();
                }
                catch(DbEntityValidationException e)
                {
                    return BadRequest(e.Message);
                }

            }

            return Ok(_OK);
        }

        [HttpGet]
        public IEnumerable<Models.Request.UsuarioRequest> GetAll()
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var listResult = new List<Models.Request.UsuarioRequest>();
                var listDBSet = db.USUARIO.ToList();
                foreach (var element in listDBSet)
                {
                    var result = new Models.Request.UsuarioRequest();
                    result.ID = element.ID;
                    result.APELLIDO = element.APELLIDO;
                    result.NOMBRE = element.NOMBRE;
                    result.EMAIL = element.EMAIL;
                    result.PASS = element.PASS;
                    result.TIPO_USUARIO_ID = element.TIPO_USUARIO;

                    listResult.Add(result);
                }

                return listResult;
            }


        }


        [HttpGet]
        public Models.Request.UsuarioRequest GetId(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var result = new Models.Request.UsuarioRequest();
                var listDBSet = db.USUARIO.ToList();
                foreach (var element in listDBSet)
                {
                    if (element.ID == id)
                    {
                        result.ID = element.ID;
                        result.APELLIDO = element.APELLIDO;
                        result.NOMBRE = element.NOMBRE;
                        result.EMAIL = element.EMAIL;
                        result.PASS = element.PASS;
                        result.TIPO_USUARIO_ID = element.TIPO_USUARIO;

                    }

                }

                return result;
            }


        }
    }
}
