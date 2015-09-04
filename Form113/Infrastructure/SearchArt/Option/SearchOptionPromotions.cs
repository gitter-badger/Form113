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

    internal class SearchOptionPromotions : SearchOption
    {
        private readonly int _Promotion;

            public SearchOptionPromotions (SearchBase sb,int promotion) : base(sb)
        {
            _Promotion = promotion;
        }
            public override IEnumerable<Produits> GetResult()
            {
                return SearchBase.GetResult().Where(x => (1- x.Promotion)*100 >= _Promotion);
            }
    }
}