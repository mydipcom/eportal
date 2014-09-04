using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MS.ECP.Web.Areas.Admin.WebHelp
{
    public static class HtmlHelp
    {



        public static IHtmlString GetJqueryInAdmin(this HtmlHelper html) 
        {
            return
                html.Raw(
                    @"<script type=""text/javascript""  src=""/Areas/Admin/Content/Scripts/jquery-1.7.2.min.js"" ></script>");
        }

        public static IHtmlString GetValidationJavascriptInAdmin(this HtmlHelper html)
        { 
            return
                html.Raw(
                    @"<script type=""text/javascript""  src=""/Areas/Admin/Content/Scripts/jquery.validate.min.js"" ></script>
<script type=""text/javascript""  src=""/Areas/Admin/Content/Scripts/jquery.validate.unobtrusive.js"" ></script>");
        }
    }
}