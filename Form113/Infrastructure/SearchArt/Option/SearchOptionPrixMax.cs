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

    internal class SearchOptionPrixMax : SearchOption
    {

        private readonly int _PrixMax;

        public SearchOptionPrixMax(SearchBase sb, int prixmax)
            : base(sb)
        {
            _PrixMax = prixmax;
        }

        public override IEnumerable<Produits> GetResult()
        {
            return SearchBase.GetResult().Where(x => x.Prix <= _PrixMax).OrderBy(x => x.Prix);
        }
    }
}