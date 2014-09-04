using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

using MS.ECP.BLL;
using MS.ECP.Model;
using MS.ECP.Web.Areas.Admin.Models;
using MS.ECP.Web.Areas.Admin.WebHelp;
using MS.ECP.Web.Filters;
using MS.ECP.Web.Models;
using MS.ECP.Web.WebHelp;
using MS.ECP.Web.WebPager;
using PageContent = MS.ECP.BLL.CMS.PageContent;

namespace MS.ECP.Web.Areas.Admin.Controllers
{
    [LoginAuthenticity]
    public class ContentController : Controller
    {
        private readonly BLL.CMS.Category _categoryBLL = new BLL.CMS.Category();
        private readonly PageContent _pageContentBLL = new PageContent();
        private const int Pagesize = 15;


        public ActionResult List(string keywords, int id = 1, string lantype = "en-us")
        {
             ViewBag.Lanage = LanageConfig.LanHash[lantype];

            var sqlwhere = String.Format("  LanguageCode='{0}' ", lantype);
            if (!String.IsNullOrWhiteSpace(keywords) && keywords != AdminConfig.SearKeyWord)
                sqlwhere += String.Format("and Item like N'%{0}%' ", keywords);
            var collection = _pageContentBLL.GetListByPage(sqlwhere, id == 1 ? 0 : (id - 1)*Pagesize + 1, id*Pagesize);
            var viewmos = new List<PageContents>(collection.Count);
            foreach (var contes in collection)
            {
                var page = new PageContents()
                {
                    Id = contes.ID,
                    LanageId = contes.Guid,
                    Title = contes.Item,
                    CreateDate = contes.CreateDate.ToString("yyyy/MM/dd"),
                    LanCode = contes.LanguageCode 
                };
                var parentca = _categoryBLL.GetModelByID(contes.CategoryID);
                if (null != parentca)
                {
                    var uplodf = _categoryBLL.GetModelByID(int.Parse(parentca.ParentGuid));
                    if (null != uplodf)
                        page.Category = String.Format("<b>{0}</b>&nbsp;/&nbsp;{1}", uplodf.CategoryName,
                            parentca.CategoryName);
                }
                viewmos.Add(page);
            }
            var viewmodel = new PagedList<PageContents>(viewmos, id, Pagesize,
                _pageContentBLL.GetRecordCount(sqlwhere));
            if (Request.IsAjaxRequest())
                return PartialView("_PageManagePadingPartialPage", viewmodel);
            return View(viewmodel);
        }

        public ActionResult AddorUpdate(string lanid, string operation, string currentpage = "1")
        {
            ViewData["Currentpage"] = currentpage;
            ViewBag.Operation = operation;

            var viewmodel = new PageContentViewModel();
            if (!String.IsNullOrEmpty(lanid))
            {
                var elmodel = _pageContentBLL.GetModelByLangGuidAndLangCode(lanid, LanageConfig.EnLan);
                var zhmodel = _pageContentBLL.GetModelByLangGuidAndLangCode(lanid, LanageConfig.ZhLan);
                if (null != elmodel)
                {
                    viewmodel.EnID = elmodel.ID;
                    viewmodel.EnItem = elmodel.Item;
                    viewmodel.EnItemContent = elmodel.ItemContent;
                    viewmodel.EnCategoryID = elmodel.CategoryID.ToString(CultureInfo.InvariantCulture);
                    viewmodel.EnTxtKeywords = elmodel.Keywords;
                    viewmodel.EnTxtDesc = elmodel.Description;
                    viewmodel.EnTxtHits = elmodel.SeoTitle;
                    var parentselect = _categoryBLL.GetModelByID(elmodel.CategoryID);
                    viewmodel.EnTopCategoryID = parentselect.ParentGuid;
                }
                if (null != zhmodel)
                {
                    viewmodel.ZhID = zhmodel.ID;
                    viewmodel.ZhItem = zhmodel.Item;
                    viewmodel.ZhItemContent = zhmodel.ItemContent;
                    viewmodel.ZhCategoryID = zhmodel.CategoryID.ToString(CultureInfo.InvariantCulture);
                    viewmodel.TxtKeywords = zhmodel.Keywords;
                    viewmodel.TxtDesc = zhmodel.Description;
                    viewmodel.TxtHits = zhmodel.SeoTitle;
                    var parentselect = _categoryBLL.GetModelByID(zhmodel.CategoryID);
                    viewmodel.CnTopCategoryID = parentselect.ParentGuid;
                }
            }
            PageContentViewModelSelectInit(viewmodel);
            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult AddorUpdate(PageContentViewModel model, string currentpage = "1")
        {
            ViewData["Currentpage"] = currentpage;
            PageContentViewModelSelectInit(model);

            if (!ModelState.IsValid)
                return View(model);
            var languguid = Guid.NewGuid().ToString();

            var enlishPageContent = model.EnID != 0
                ? _pageContentBLL.GetModelByID(model.EnID)
                : new Model.CMS.PageContent();
            enlishPageContent.Item = model.EnItem;
            enlishPageContent.ItemContent = model.EnItemContent;
            enlishPageContent.CategoryID = int.Parse(model.EnCategoryID);
            enlishPageContent.LanguageCode = LanageConfig.EnLan;
            enlishPageContent.Guid = languguid;
            if (model.EnID == 0)
                enlishPageContent.CreateDate = DateTime.Now;
            enlishPageContent.Description = model.EnTxtDesc;
            enlishPageContent.Keywords = model.EnTxtKeywords;
            enlishPageContent.SeoTitle = model.EnTxtHits;


            var chinesePageContent = model.ZhID != 0
                ? _pageContentBLL.GetModelByID(model.ZhID)
                : new Model.CMS.PageContent();
            chinesePageContent.Item = model.ZhItem ?? model.EnItem;
            chinesePageContent.ItemContent = model.ZhItemContent ?? model.EnItemContent;
            chinesePageContent.CategoryID = int.Parse(model.ZhCategoryID);
            chinesePageContent.LanguageCode = LanageConfig.ZhLan;
            chinesePageContent.Guid = languguid;
            if (model.ZhID == 0)
                enlishPageContent.CreateDate = DateTime.Now;
            chinesePageContent.Description = model.TxtDesc;
            chinesePageContent.Keywords = model.TxtKeywords;
            chinesePageContent.SeoTitle = model.TxtHits;

            _pageContentBLL.AddOrUpdate(enlishPageContent);
            _pageContentBLL.AddOrUpdate(chinesePageContent);

            return RedirectToAction("List", new {id = currentpage});
        }


        public ActionResult Del(int id = 0, string lan = "en-us")
        {
            _pageContentBLL.Delete(id);
            return RedirectToAction("List", new {lantype = lan});
        }

        #region private method

        private void PageContentViewModelSelectInit(PageContentViewModel viewmodel)
        {
            viewmodel.SetEnTopParEnToptGuidItems(
                _categoryBLL.GetList(String.Format(" ParentGuid='0' and  LanguageCode='{0}' ", LanageConfig.EnLan)));
            viewmodel.SetCnTopParentGuidItems(
                _categoryBLL.GetList(String.Format(" ParentGuid='0' and  LanguageCode='{0}' ", LanageConfig.ZhLan)));
            int encaid;
            if (int.TryParse(viewmodel.EnTopCategoryID, out encaid))
            {
                viewmodel.SetEnParentGuidItems(_categoryBLL.GetList(String.Format(" ParentGuid='{0}' ", encaid)));
            }

            int cncaid;
            if (int.TryParse(viewmodel.CnTopCategoryID, out cncaid))
            {
                viewmodel.SetZhParentGuidItems(_categoryBLL.GetList(String.Format(" ParentGuid='{0}' ", cncaid)));
            }
        }

        #endregion

    }

}
