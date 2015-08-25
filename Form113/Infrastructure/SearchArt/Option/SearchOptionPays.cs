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

    public class SearchOptionPays : SearchOption
    {
        private readonly string[] _SelectedPays;

        public SearchOptionPays(SearchBase sb, string[] listepays)
            : base(sb)
        {
            _SelectedPays = listepays;
        }

        public override IEnumerable<Produits> GetResult()
        {
            if (_SelectedPays == null)
            {
                return SearchBase.GetResult();
            }
            else
            {
                return SearchBase.GetResult().Where(x => _SelectedPays.ToArray().Contains(x.Pays.CodeIso3)).OrderBy(x => x.Prix);
            }
        }
    }
}