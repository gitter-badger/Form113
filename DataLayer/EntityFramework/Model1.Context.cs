﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Form113Entities : DbContext
    {
        public Form113Entities()
            : base("name=Form113Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrateurs> Administrateurs { get; set; }
        public virtual DbSet<Adresses> Adresses { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Departements> Departements { get; set; }
        public virtual DbSet<Identites> Identites { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Produits> Produits { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Utilisateurs> Utilisateurs { get; set; }
        public virtual DbSet<Villes> Villes { get; set; }
        public virtual DbSet<ZipCodes> ZipCodes { get; set; }
    }
}