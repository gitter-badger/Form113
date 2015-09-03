using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Form113.Models
{
    public class CommandeViewModels
    {
        public string ListeProduitCommande { get; set; }

        // INFO POUR ADRESSE A AJOUTER ICI !

        public Dictionary<string, Dictionary<string, string>> RegionsDepartements { get; set; }

        public string CodeVille { get; set; }
        [DisplayName("numero de voie :")]
        public string Adresse1 { get; set; }

        [DisplayName("Voie :")]
        public string Adresse2 { get; set; }

        [DisplayName("Complément d'adresse :")]
        public string Adresse3 { get; set; }
    }
}