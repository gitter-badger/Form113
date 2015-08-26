using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Form113.Models
{
    public class SearchViewModel
    {
        public int Prixmin { get; set; }
        public int Prixmax { get; set; }

        #region Spec
        [XmlArray("Categories")]
        [XmlArrayItem("Categorie", typeof(int))]
        [DisplayName("Choisissez vos Catégories : ")]
        #endregion
        public int[] idCategories { get; set; }

        #region Spec
        [XmlArray("SousCategories")]
        [XmlArrayItem("SousCategorie", typeof(int))]
        [DisplayName("Choisissez vos Sous Catégories : ")]
        #endregion
        public int[] idSousCategories { get; set; }

        #region Spec
        [XmlArray("Continents")]
        [XmlArrayItem("Continent", typeof(int))]
        [DisplayName("Choisissez votre Continent : ")]
        #endregion
        public int[] idContinent { get; set; }

        #region Spec
        [XmlArray("Regions")]
        [XmlArrayItem("Region", typeof(int))]
        [DisplayName("Choisissez votre Region : ")]
        #endregion
        public int[] idRegions { get; set; }

        #region Spec
        [XmlArray("ListePays")]
        [XmlArrayItem("Pays", typeof(string))]
        [DisplayName("Choisissez votre Pays : ")]
        #endregion
        public string[] idPays { get; set; }


        [XmlIgnore]
        public List<SelectListItem> ListeCategorie { get; set; }

        [XmlIgnore]
        public List<SelectListItem> ListeContinents { get; set; }

        [XmlIgnore]
        public List<Produits> ListeProduit { get; set; }

        #region XMLSerializerUnserialize
        public string SerializeSearchViewModel()
        {
            var xmlSerializer = new XmlSerializer(typeof(SearchViewModel));
            var writer = new StringWriter();
            xmlSerializer.Serialize(writer, this);
            return writer.ToString();
        }

        public static SearchViewModel UnserializeSearchViewModel(string svms)
        {
            var xmlSerializer = new XmlSerializer(typeof(SearchViewModel));
            var reader = new StringReader(svms);
            return (SearchViewModel)xmlSerializer.Deserialize(reader);
        }
        #endregion
    }
}