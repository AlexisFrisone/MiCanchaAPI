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
        const string _OK = "OK";

        [HttpPost]
        public IHttpActionResult Add(Models.Request.UsuarioRequest model)
        {
            
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
                var listDBSet = db.USUARIO.Where(x => x.ID == id);
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
             [HttpGet]
        public Models.Request.UsuarioRequest GetUserByEmail(string email)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var result = new Models.Request.UsuarioRequest();
                var listDBSet = db.USUARIO.ToList();
                foreach (var element in listDBSet)
                {
                    if (element.EMAIL == email)
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

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                db.USUARIO.Remove(db.USUARIO.ToList().Find(u => u.ID == id));
                db.SaveChanges();
            }

            return Ok(_OK);
        }


        [HttpPut]
        public IHttpActionResult Update(Models.Request.UsuarioRequest model)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try
                {
                    var oUsuarioModel = db.USUARIO.ToList().FirstOrDefault(u => u.ID == model.ID);
                    if (oUsuarioModel == null)
                    {
                        var oUsuario = new Models.USUARIO();
                        oUsuario.APELLIDO = model.APELLIDO;
                        oUsuario.NOMBRE = model.NOMBRE;
                        oUsuario.EMAIL = model.EMAIL;
                        oUsuario.PASS = model.PASS;
                        oUsuario.TIPO_USUARIO = model.TIPO_USUARIO_ID;
                        db.USUARIO.Add(oUsuario);
                    }
                    else
                    {
                        oUsuarioModel.APELLIDO = model.APELLIDO;
                        oUsuarioModel.NOMBRE = model.NOMBRE;
                        oUsuarioModel.EMAIL = model.EMAIL;
                        oUsuarioModel.PASS = model.PASS;
                        oUsuarioModel.TIPO_USUARIO = model.TIPO_USUARIO_ID;
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
