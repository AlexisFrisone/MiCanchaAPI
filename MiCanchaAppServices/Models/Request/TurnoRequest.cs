using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiCanchaAppServices.Models.Request
{
    public class TurnoRequest
    {
        public int ID { get; set; }
        public Nullable<int> CANCHA_ID { get; set; }
        public Nullable<int> USUARIO { get; set; }
        public System.DateTime FECHA { get; set; }
    }
}
