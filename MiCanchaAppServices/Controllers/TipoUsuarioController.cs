﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCanchaAppServices.Controllers
{
    public class TipoUsuarioController : ApiController
    {
        const string _OK = "OK";

        [HttpPost]
        public IHttpActionResult Add(Models.Request.TipoUsuarioRequest model)
        {
            
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
              
                try
                {
                    var oTipoUsuario = new Models.TIPO_USUARIO();
                    oTipoUsuario.TIPO_USUARIO1 = model.TIPO_USUARIO;
                    oTipoUsuario.ID = model.ID;
                    db.TIPO_USUARIO.Add(oTipoUsuario);
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
                db.TIPO_USUARIO.Remove(db.TIPO_USUARIO.ToList().Find(tu => tu.ID == id));
                db.SaveChanges();
            }

            return Ok(_OK);
        }

        [HttpGet]
        public IEnumerable<Models.Request.TipoUsuarioRequest> GetAll()
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var listResult = new List<Models.Request.TipoUsuarioRequest>();
                var listDBSet = db.TIPO_USUARIO.ToList();
                foreach( var element in listDBSet)
                {
                    var result = new Models.Request.TipoUsuarioRequest();
                    result.ID = element.ID;
                    result.TIPO_USUARIO = element.TIPO_USUARIO1;

                    listResult.Add(result);
                }

                return listResult;
            }


        }


        [HttpGet]
        public Models.Request.TipoUsuarioRequest GetId(int id)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                var result = new Models.Request.TipoUsuarioRequest();
                var listDBSet = db.TIPO_USUARIO.Where(x => x.ID == id);
                foreach (var element in listDBSet)
                {
                    if (element.ID == id)
                        result.ID = element.ID;
                    result.TIPO_USUARIO = element.TIPO_USUARIO1;

                }

                return result;
            }
        }

       [HttpPut]
        public IHttpActionResult Update(Models.Request.TipoUsuarioRequest model)
        {
            using (Models.MiCanchaDBContext db = new Models.MiCanchaDBContext())
            {
                try
                {
                    var oTipoUserModel = db.TIPO_USUARIO.ToList().FirstOrDefault(t => t.ID == model.ID);
                    if (oTipoUserModel == null)
                    {
                        var oTipoUsuario = new Models.TIPO_USUARIO();
                        oTipoUsuario.TIPO_USUARIO1 = model.TIPO_USUARIO;
                        oTipoUsuario.ID = model.ID;
                        db.TIPO_USUARIO.Add(oTipoUsuario);
                    }
                    else {
                        oTipoUserModel.TIPO_USUARIO1 = model.TIPO_USUARIO;
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
