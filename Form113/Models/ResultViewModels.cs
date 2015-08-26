using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form113.Models
{
    public class ResultViewModels
    {
        public IEnumerable<DataLayer.Models.Produits> Result { get; set; }
        public int[] ListeAComparer { get; set; }

        public string XmlSearchviewModel { get; set; }

        #region Paginnation
        public int CurrentPage { get; set; }
        public int PageQty { get; set; }
        public int ItemsQty { get; set; }
        public int PageSize { get; set; }
        #endregion
    }
}