using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS.ECP.AAMAPrd.Areas.Admin.WebHelp
{
    public static class HtmlHelp
    {
        public static IHtmlString HtmlSubstring(this System.Web.Mvc.HtmlHelper help,string input)
        {
            return help.Raw(input.Length < 200 ? input : input.Substring(0, 199));
        }
    }
}