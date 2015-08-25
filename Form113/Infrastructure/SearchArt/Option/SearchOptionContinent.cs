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

    internal class SearchOptionContinent : SearchOption
    {
        private readonly int[] _SelectedContinent;

        public SearchOptionContinent(SearchBase sb, int[] listecont)
            : base(sb)
        {
            _SelectedContinent = listecont;
        }

        public override IEnumerable<Produits> GetResult()
        {
            if (_SelectedContinent == null || _SelectedContinent.Count() <= 0)
            {
                return SearchBase.GetResult();
            }
            else
            {
                return SearchBase.GetResult().Where(x => _SelectedContinent.ToArray().Contains(x.Pays.Regions.Continents.idContinent)).OrderBy(x => x.Prix);
            }
        }
    }
}