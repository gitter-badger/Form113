using DataLayer.Models;
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
        public bool BackToSearch { get; set; } //pour afficher ou non le bouton retour recherche

        #region Paginnation
        public int CurrentPage { get; set; }
        public int PageQty { get; set; }
        public int ItemsQty { get; set; }
        public int PageSize { get; set; }
        #endregion
        public ResultViewModels() { }
        public static ResultViewModels RvmCreate(SearchViewModel svm, List<Produits> result)
        {
            var pageSize = 30;
            var itemQty = result.Count();
            var temp = itemQty % pageSize;
            var pageQty = temp == 0 ? itemQty / pageSize : itemQty / pageSize + 1;

            ResultViewModels rvm = new ResultViewModels()
            {
                CurrentPage = 1,
                Result = result.Take(pageSize).ToList(),
                PageSize = pageSize,
                ItemsQty = itemQty,
                PageQty = pageQty,
                XmlSearchviewModel = svm.SerializeSearchViewModel(),
                BackToSearch=true,
            };
            return rvm;
        }
    }
}