﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MiCanchaDBContext : DbContext
    {
        public MiCanchaDBContext()
            : base("name=MiCanchaDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CANCHA> CANCHA { get; set; }
        public virtual DbSet<COMPLEJO> COMPLEJO { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
        public virtual DbSet<TURNOS> TURNOS { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    }
}
