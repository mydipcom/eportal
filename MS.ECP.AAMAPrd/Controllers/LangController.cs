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
        public ActionResult ChangeLanguage(string language)
        {
            if (base.Request.UrlReferrer == null)
            {
                return this.Redirect("/" + language);
            }
            string str = (language.ToLower() == "zh-cn") ? ("/" + language) : "";
            string str2 = General.Regions.Aggregate<string, string>(base.Request.UrlReferrer.PathAndQuery, (current, c) => current.Replace(c ?? "", ""));
            string str3 = str + str2;
            str3 = string.IsNullOrWhiteSpace(str3) ? "/" : str3;
            return this.Redirect(str3);
        }
    }
}
