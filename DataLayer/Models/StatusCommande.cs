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
    
    public partial class StatusCommande
    {
        public StatusCommande()
        {
            this.Commandes = new HashSet<Commandes>();
        }
    
        public int IdStatusCommande { get; set; }
        public string StatusCommande1 { get; set; }
    
        public virtual ICollection<Commandes> Commandes { get; set; }
    }
}