//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiCanchaAppServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TURNOS
    {
        public int ID { get; set; }
        public int CANCHA_ID { get; set; }
        public Nullable<int> USUARIO_ID { get; set; }
        public System.DateTime HORA_INGRESO { get; set; }
        public Nullable<bool> RESERVADO { get; set; }
    
        public virtual CANCHA CANCHA { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
