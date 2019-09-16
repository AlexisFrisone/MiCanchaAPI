using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiCanchaAppServices.Models.Request
{
    public class UsuarioRequest
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string EMAIL { get; set; }
        public string PASS { get; set; }
        public Nullable<int> TIPO_USUARIO { get; set; }

    }
}
