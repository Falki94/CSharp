﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProjektCS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SklepEntities : DbContext
    {
        public SklepEntities()
            : base("name=SklepEntities")
        {
           Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adre> Adres { get; set; }
        public virtual DbSet<Dostawa> Dostawas { get; set; }
        public virtual DbSet<Klient> Klients { get; set; }
        public virtual DbSet<Kontakt> Kontakts { get; set; }
        public virtual DbSet<Pracownik> Pracowniks { get; set; }
        public virtual DbSet<Produkt> Produkts { get; set; }
        public virtual DbSet<Zamowienie> Zamowienies { get; set; }
    }
}
