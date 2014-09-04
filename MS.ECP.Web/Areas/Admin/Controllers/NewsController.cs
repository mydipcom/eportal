using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Model.CMS;
using MS.ECP.Web.Areas.Admin.WebHelp;
using MS.ECP.Web.Filters;
using MS.ECP.Web.Models;
using MS.ECP.Web.WebHelp;
using MS.ECP.Web.WebPager;
using NewsViewModel = MS.ECP.Web.Areas.Admin.Models.NewsViewModel;

namespace MS.ECP.Web.Areas.Admin.Controllers
{
      [LoginAuthenticity]
    public class NewsController : Controller
    {
        private readonly BLL.CMS.News _newsBLL = new BLL.CMS.News();
        private const int Pagesize = 15;


        public ActionResult List(string keywords, int id = 1, string lantype = "en-us")
        {
            ViewBag.Lanage = LanageConfig.LanHash[lantype];

            var sqlwhere = String.Format("  LanguageCode='{0}' ", lantype);
            if (!String.IsNullOrWhiteSpace(keywords) && keywords != AdminConfig.SearKeyWord)
                sqlwhere += String.Format(" and Title like N'%{0}%' ", keywords);
            var dt = _newsBLL.GetListByPage(sqlwhere, id == 1 ? 0 : (id - 1) * Pagesize + 1, id * Pagesize);
            var listcount = _newsBLL.GetRecordCount(sqlwhere);
            var viewmodel = new PagedList<News>(dt, id, Pagesize, listcount);
            if (Request.IsAjaxRequest())
                return PartialView("_NewsPagingPartialPage", viewmodel);
            return View(viewmodel);
        }


        public ActionResult AddorUpdate(string lanid, string operation)
        {
            ViewBag.Operation = operation;

            var viewmodel = new NewsViewModel();
            if (!String.IsNullOrEmpty(lanid))
            {
                var elmodel = _newsBLL.GetModelByLangGuidAndLangCode(lanid, LanageConfig.EnLan);
                var zhmodel = _newsBLL.GetModelByLangGuidAndLangCode(lanid, LanageConfig.ZhLan);
                if (null != elmodel)
                {
                    viewmodel.EnTitle = elmodel.Title;
                    viewmodel.EnContent = elmodel.Content;
                    viewmodel.EnId = elmodel.ID;
                    viewmodel.EnTxtKeywords = elmodel.Keywords;
                    viewmodel.EnTxtDesc = elmodel.Description;
                    viewmodel.EnTxtHits = elmodel.SeoTitle;
                }
                if (null != zhmodel)
                {
                    viewmodel.ZhTitle = zhmodel.Title;
                    viewmodel.ZhContent = zhmodel.Content;
                    viewmodel.ZhId = zhmodel.ID;
                    viewmodel.TxtKeywords = zhmodel.Keywords;
                    viewmodel.TxtDesc = zhmodel.Description;
                    viewmodel.TxtHits = zhmodel.SeoTitle;
                }
            }
            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult AddorUpdate(NewsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var languguid = Guid.NewGuid().ToString();
            var elmodel = model.EnId != 0
                ? _newsBLL.GetModelByID(model.EnId)
                : new News();

            elmodel.Title = model.EnTitle;
            elmodel.Content = model.EnContent;
            elmodel.ModifyDate = DateTime.Now;
            elmodel.LanguageCode = LanageConfig.EnLan;
            elmodel.LangGuid = languguid;
            if (model.EnId == 0) elmodel.CreateDate = DateTime.Now;
            elmodel.Description = model.EnTxtDesc;
            elmodel.Keywords = model.EnTxtKeywords;
            elmodel.SeoTitle = model.EnTxtHits;


            var zhmodel = model.ZhId != 0
                ? _newsBLL.GetModelByID(model.ZhId)
                : new News();
            zhmodel.Title = model.ZhTitle ?? model.EnTitle;
            zhmodel.Content = model.ZhContent?? model.EnContent;
            zhmodel.ModifyDate = DateTime.Now;
            zhmodel.LanguageCode = LanageConfig.ZhLan;
            zhmodel.LangGuid = languguid;
            if (model.ZhId == 0) elmodel.CreateDate = DateTime.Now;
            zhmodel.Description = model.TxtDesc;
            zhmodel.Keywords = model.TxtKeywords;
            zhmodel.SeoTitle = model.TxtHits;


            _newsBLL.AddOrUpdate(elmodel);
            _newsBLL.AddOrUpdate(zhmodel);
            return RedirectToAction("List");
        }


        public ActionResult Del(int id = 0, string lan = "en-us")
        {
            _newsBLL.Delete(id);
            return RedirectToAction("List", new { lantype = lan });
        }

    

    }
}
