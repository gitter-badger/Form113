using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form113.Infrastructure.SearchArt.Base
{
    internal abstract class SearchOption : SearchBase
    {
        protected SearchBase SearchBase;

        protected SearchOption(SearchBase sb)
        {
            SearchBase = sb;
        }
    }
}