using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiCanchaAppServices.Models.Request
{
    public class TurnoRequest
    {
        public int ID { get; set; }
        public int? CANCHA_ID { get; set; }
        public int? USUARIO_ID { get; set; }
        public System.DateTime HORA_INGRESO { get; set; }
        public Boolean? RESERVADO { get; set; }
    }
}
