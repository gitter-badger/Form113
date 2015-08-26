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

    internal class SearchOptionPrixMin : SearchOption
    {

        private readonly int _PrixMin;

        public SearchOptionPrixMin(SearchBase sb, int prixmin)
            : base(sb)
        {
            _PrixMin = prixmin;
        }

        public override IEnumerable<Produits> GetResult()
        {
            return SearchBase.GetResult().Where(x => x.Prix >= _PrixMin).OrderBy(x => x.Prix);
        }
    }
}