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
    
    public partial class CANCHA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CANCHA()
        {
            this.TURNOS = new HashSet<TURNOS>();
        }
    
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<int> COMPLEJO_ID { get; set; }
    
        public virtual COMPLEJO COMPLEJO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TURNOS> TURNOS { get; set; }
    }
}
