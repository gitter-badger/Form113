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
    
    public partial class ZipCodes
    {
        public ZipCodes()
        {
            this.Adresses = new HashSet<Adresses>();
        }
    
        public string CodePostal { get; set; }
        public string CodeINSEE { get; set; }
    
        public virtual ICollection<Adresses> Adresses { get; set; }
        public virtual Villes Villes { get; set; }
    }
}
