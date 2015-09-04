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

        #region Spec
        [XmlAttribute]
        [DisplayName("Choissiez le niveau de promotion")]
        #endregion Spec
        public int Promotion { get; set; }
        [XmlIgnore]
        public List<SelectListItem> ListeCategorie { get; set; }

        [XmlIgnore]
        public List<SelectListItem> ListeContinents { get; set; }

        [XmlIgnore]
        public List<Produits> ListeProduit { get; set; }

        public static SearchViewModel InitializeSVM()
        {
            var db = new BestArtEntities();
            SearchViewModel svm = new SearchViewModel();

            svm.ListeCategorie = new List<SelectListItem>();
            var liste = db.Categories.OrderBy(x => x.Libelle).ToList();
            foreach (var item in liste)
            {
                svm.ListeCategorie.Add(new SelectListItem() { Text = item.Libelle, Value = item.IdCategorie.ToString() });
            }

            svm.ListeContinents = new List<SelectListItem>();
            var listeCont = db.Continents.OrderBy(x => x.name).ToList();
            foreach (var cont in listeCont)
            {
                svm.ListeContinents.Add(new SelectListItem() { Text = cont.name, Value = cont.idContinent.ToString() });
            }
            return svm;
        }

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