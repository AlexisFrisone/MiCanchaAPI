using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiCanchaAppServices.Models.Request
{
    public class ComplejoRequest
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public int DUENIO_ID { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO_COMPLEJO { get; set; }

    }
}
