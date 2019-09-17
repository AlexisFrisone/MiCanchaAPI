using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiCanchaAppServices.Models.Request
{
    public class CanchaRequest
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public int? COMPLEJO_ID { get; set; }
    }
}
