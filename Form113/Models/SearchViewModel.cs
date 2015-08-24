using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Form113.Models
{
    public class SearchViewModel
    {
        public int PrixMini, PrixMaxi;
        public int[] idCategories;
        [XmlIgnore]
        public Dictionary<string, Dictionary<string, string>> CatSousCat { get; set; }




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
    }
}