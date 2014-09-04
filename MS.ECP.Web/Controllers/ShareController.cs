using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Common;
using MS.ECP.Model.CMS;
using MS.ECP.Utility;
using MS.ECP.Web.Models;
using MS.ECP.Web.WebHelp;

namespace MS.ECP.Web.Controllers
{
    public class ShareController : Controller
    {
        private readonly BLL.CMS.Category _categoryBLL = new BLL.CMS.Category();
        private readonly BLL.CMS.News _newsbll = new BLL.CMS.News();
        private const int Topsize = 6;
        private const string SelectedCssName = "menu_locked";

        [ChildActionOnly]
        public ActionResult FooterPartial()
        {
            var viewmodel = new FooterPartialViewModel
            {
                Categories =
                    _categoryBLL.GetList(String.Format(" ParentGuid ='0' and LanguageCode='{0}'",
                        LanageCommon.CurrenLanage)) ??
                    new List<Category>(),
                Newses =
                    _newsbll.GetList(Topsize, String.Format("  LanguageCode='{0}' ", LanageCommon.CurrenLanage)) ??
                    new List<News>(0)
            };
            return PartialView(viewmodel);
        }



        [ChildActionOnly]
        public ActionResult MenuPartial()
        {
            var viewmodel = new MenuPartialViewModel
            {
                Categories =
                    _categoryBLL.GetList(String.Format(" ParentGuid ='0' and LanguageCode='{0}'",
                        LanageCommon.CurrenLanage)) ??
                    new List<Category>()
            };

            var request = Request.Path;
            var controlname = request.Substring(request.LastIndexOf('/') + 1,
                request.Length - request.LastIndexOf('/') - 1);
            switch (controlname.ToLower())
            {

                case "en-us":
                    viewmodel.Title1Css = SelectedCssName;
                    break;
                case "zh-cn":
                    viewmodel.Title1Css = SelectedCssName;
                    break;
                case "":
                    viewmodel.Title1Css = SelectedCssName;
                    break;
                case "index":
                    viewmodel.Title1Css = SelectedCssName;
                    break;
                case "technologies":
                    viewmodel.Title2Css = SelectedCssName;
                    break;
                case "solutions":
                    viewmodel.Title3Css = SelectedCssName;
                    break;
                case "aboutus":
                    viewmodel.Title4Css = SelectedCssName;
                    break;
                case "workwithus":
                    viewmodel.Title5Css = SelectedCssName;
                    break;
            }
            return PartialView(viewmodel);
        }




        /// <summary>
        /// 切换到指定语言，跳转到来源页新的语言页面url
        /// </summary>
        public ActionResult ChangeLanguage(string language)
        {
           /* if (this.Request.UrlReferrer == null)
            {
                return this.Redirect("/" + language);
            }

            string langStr = "/" + (language.ToLower() != "zh-cn" ? language : "en-us");
            string referrerPath = General.Regions.Aggregate(this.Request.UrlReferrer.PathAndQuery,
                (current, c) => current.Replace(c + "", ""));
            string url;
            if ("/" == referrerPath)
                url = String.Format(@"/{0}/home_index_1.html", language);
            else
                url = "/" + language + referrerPath;
            url = string.IsNullOrWhiteSpace(url) ? "/" : url;
            return this.Redirect(url);*/
            if (this.Request.UrlReferrer == null)
            {
                return this.Redirect("/" + language);
            }

            string langStr = "/" + (language.ToLower() != "zh-cn" ? language : "en-us");
            string referrerPath = General.Regions.Aggregate(this.Request.UrlReferrer.PathAndQuery,
                (current, c) => current.Replace(c + "", ""));
            string url;
            if ("/" == referrerPath)
                url = String.Format(@"/{0}/", language);
            else
                url = "/" + language + referrerPath;
            url = string.IsNullOrWhiteSpace(url) ? "/" : url;
            return this.Redirect(url);
        }

    }
}
