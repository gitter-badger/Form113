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
    
    public partial class Identites
    {
        public Identites()
        {
            this.Utilisateurs = new HashSet<Utilisateurs>();
        }
    
        public int IdIdentite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Identifiant { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    
        public virtual Administrateurs Administrateurs { get; set; }
        public virtual ICollection<Utilisateurs> Utilisateurs { get; set; }
    }
}
