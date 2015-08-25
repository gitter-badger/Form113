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

    internal class SearchOptionRegion : SearchOption
    {
        private readonly int[] _SelectedRegion;

        public SearchOptionRegion(SearchBase sb, int[] listeregion)
            : base(sb)
        {
            _SelectedRegion = listeregion;
        }

        public override IEnumerable<Produits> GetResult()
        {
            if (_SelectedRegion == null ||_SelectedRegion.Count() <= 0)
            {
                return SearchBase.GetResult();
            }
            else
            {
                return SearchBase.GetResult().Where(x => _SelectedRegion.ToArray().Contains(x.Pays.Regions.idRegion)).OrderBy(x => x.Prix);
            }
        }
    }
}