using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form113.Infrastructure.SearchArt.Base
{
    #region UsingReg
    using System.Collections.Generic;
    using DataLayer.Models;
    #endregion

    internal abstract class SearchBase
    {
        protected IEnumerable<Produits> SearchAnnonces;

        public abstract IEnumerable<Produits> GetResult();

    }
}