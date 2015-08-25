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

        [XmlArray("Categories")]
        [XmlArrayItem("Categorie", typeof(int))]
        [DisplayName("Choisissez vos Catégories : ")]
        public int[] idCategories { get; set; }

        [XmlArray("SousCategories")]
        [XmlArrayItem("SousCategorie", typeof(int))]
        [DisplayName("Choisissez vos Sous Catégories : ")]
        public int[] idSousCategories { get; set; }

        public List<SelectListItem> ListeCategorie;

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