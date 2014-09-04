using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MS.ECP.Web.WebHelp
{
    public static class WebUiHelp
    {
        public static string GetimagesbyLanager(string iamgefile)
        {
            return
                String.Format("/Content/{0}/images/{1}", LanageCommon.CurrenLanage, iamgefile);
        }


        public static IHtmlString GetCssbyLanager(HtmlHelper html, string cssfile)
        {
            return
                html.Raw(
                    String.Format(@"<link href=""/Content/Css/{0}_{1}.css""  rel=""stylesheet"" type=""text/css"" />",
                        cssfile, LanageCommon.CurrenLanage));
        }


        public static IHtmlString GetJavscriptbyLanager(HtmlHelper html, string jsfile)
        {
            return
                html.Raw(String.Format(@"<script type=""text/javascript""  src=""/Content/{0}/js/{1}"" ></script>",
                    LanageCommon.CurrenLanage, jsfile));
        }

        public static IHtmlString GetValidationJavascript(this HtmlHelper html)
        {
            return
                html.Raw(@"<script type=""text/javascript""  src=""/Scripts/jquery.validate.min.js"" ></script>
<script type=""text/javascript""  src=""/Scripts/jquery.validate.unobtrusive.js"" ></script>");
        }

        // Methods
        public static IHtmlString RegisterMvcPagerScriptResource(HtmlHelper html)
        {
            return html.Raw(@"<script  type=""text/javascript""  src=""/Scripts/jquery-1.7.2.min.js""></script>
                              <script  type=""text/javascript""  src=""/Scripts/webpager.js""></script>");
        }


        public static string RemoveSpaceHtmlTag(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return "";
            //去html标签
            input = Regex.Replace(input, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"-->", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"<!--.*", "", RegexOptions.IgnoreCase);

            input = Regex.Replace(input, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            input = input.Replace("<", "");
            input = input.Replace(">", "");
            input = input.Replace("\r\n", "");
            //去两端空格，中间多余空格
            input = Regex.Replace(input.Trim(), "\\s+", " ");
            return input;
        }
    }
}