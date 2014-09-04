using MS.ECP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MS.ECP.AAMAPrd.Controllers
{
    public class LangController : Controller
    {

        /// <summary>
        /// 切换到指定语言，跳转到来源页新的语言页面url
        /// </summary>
        public ActionResult ChangeLanguage(string language)
        {
            if (this.Request.UrlReferrer == null)
            {
                return this.Redirect("/" + language);
            }

            string langStr = language.ToLower() == "zh-cn" ? "/" + language : "";
            string referrerPath = General.Regions.Aggregate(this.Request.UrlReferrer.PathAndQuery, (current, c) => current.Replace(c + "", ""));
            string url = langStr + referrerPath;
            url = string.IsNullOrWhiteSpace(url) ? "/" : url;
            return this.Redirect(url);
        }
    }
}
