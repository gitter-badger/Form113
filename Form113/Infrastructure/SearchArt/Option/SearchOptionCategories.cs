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

    internal class SearchOptionCategories : SearchOption
    {
        private readonly int [] _SelectedCategories;

        public SearchOptionCategories(SearchBase sb, int[] listCategories) : base(sb)
        {
            _SelectedCategories = listCategories;
        }

        public override IEnumerable<Produits> GetResult()
        {
            if (_SelectedCategories== null || _SelectedCategories.Count()<=0)
            {
                return SearchBase.GetResult();
            }
            else
            {
                return SearchBase.GetResult().Where(x => _SelectedCategories.ToArray().Contains(x.SousCategories.Categories.IdCategorie)).OrderBy(x => x.Nom);
            }
        }
    }
}