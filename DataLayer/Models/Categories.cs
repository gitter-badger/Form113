//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categories
    {
        public Categories()
        {
            this.SousCategorie = new HashSet<SousCategorie>();
        }
    
        public int IdCategorie { get; set; }
        public string Libelle { get; set; }
    
        public virtual ICollection<SousCategorie> SousCategorie { get; set; }
    }
}
