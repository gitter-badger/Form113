using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form113.Helper
{
    public class FormFieldset : IDisposable
    {
        private HtmlHelper _helper;

        public FormFieldset(HtmlHelper helper, string legend)
        {
            _helper = helper;
            _helper.ViewContext.Writer.Write("<fieldset>");
            _helper.ViewContext.Writer.Write("<legend>{0}</legend>", legend);
        }
        public void Dispose()
        {
            _helper.ViewContext.Writer.Write("</fieldset>");
        }
    }
}