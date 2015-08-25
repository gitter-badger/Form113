using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form113.Infrastructure.SearchArt
{
    #region UsingReg
    using System.Collections.Generic;
    using DataLayer.Models;
    using Form113.Infrastructure.SearchArt.Base;
    #endregion

    internal class Search : SearchBase 
    {
        public Search()
        {
            SearchAnnonces = new BestArtEntities().Produits;
        }


        public Search(IEnumerable<Produits> result)
        {
            SearchAnnonces = result;
        }

        public override IEnumerable<Produits> GetResult()
        {
            return SearchAnnonces;
        }
    }
}