using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form113.Infrastructure.SearchArt.Option
{
    #region UsingReg
    using System.Collections.Generic;
    using System.Linq;
    using DataLayer.Models;
    using Form113.Infrastructure.SearchArt.Base;
    #endregion

    internal class SearchOptionSousCategories : SearchOption
    {
        private readonly int[] _SelectedSousCategories;

        public SearchOptionSousCategories(SearchBase sb,int[] listeSousCategories) : base(sb)
        {
            _SelectedSousCategories = listeSousCategories;
        }
        public override IEnumerable<Produits> GetResult()
        {
            if (_SelectedSousCategories==null || _SelectedSousCategories.Count() <=0)
            {
                return SearchBase.GetResult();
            }
            else
            {
                return SearchBase.GetResult().Where(x => _SelectedSousCategories.ToArray().Contains(x.SousCategories.IdSousCategorie)).OrderBy(x => x.Nom);
            }
        }

    }
}