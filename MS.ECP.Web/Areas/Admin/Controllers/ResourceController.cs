using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
using MS.ECP.BLL;
using MS.ECP.Web.Areas.Admin.Models;
using MS.ECP.Web.Areas.Admin.WebHelp;
using MS.ECP.Web.Filters;
using MS.ECP.Web.Models;
using MS.ECP.Web.WebHelp;
using MS.ECP.Web.WebPager;

namespace MS.ECP.Web.Areas.Admin.Controllers
{
    [LoginAuthenticity]
    public class ResourceController : Controller
    {


        private readonly SysResource _resourceBLL = new SysResource();
        private const int Pagesize = 15;

        public ActionResult List(string keywords, string resourcepage, int id = 1, string lantype = "en-us")
        {
            ViewBag.Lanage = LanageConfig.LanHash[lantype];

            var sqlwhere = String.Format("  LanguageCode='{0}' ", lantype);
            if (!String.IsNullOrEmpty(keywords) && keywords != AdminConfig.ResourceSearKeyWord)
                sqlwhere += String.Format(" and  ResourceValue  like N'%{0}%' ", keywords);

            if (!String.IsNullOrEmpty(resourcepage) && resourcepage != AdminConfig.ResourcePage)
                sqlwhere += String.Format(" and  ResourcePage  like N'%{0}%' ", resourcepage);

            var dt = _resourceBLL.GetListByPage(sqlwhere, id == 1 ? 0 : (id - 1)*Pagesize + 1, id*Pagesize);
            var listcount = _resourceBLL.GetRecordCount(sqlwhere);
            var viewmodel = new PagedList<Model.SysResource>(dt, id, Pagesize, listcount);
            if (Request.IsAjaxRequest())
                return PartialView("_ResourcePartialPage", viewmodel);
            return View(viewmodel);
        }



        public ActionResult AddorUpdate(string lanid, string currentpage = "1")
        {
            ViewData["Currentpage"] = currentpage;
            var viewmodel = new ResourceViewModel();
            if (!String.IsNullOrEmpty(lanid))
            {
                var res = _resourceBLL.GetList(String.Format(" ResourceKey='{0}' ", lanid));
                var elmodel = res.FirstOrDefault(m => m.LanguageCode == LanageConfig.EnLan);
                var zhmodel = res.FirstOrDefault(m => m.LanguageCode == LanageConfig.ZhLan);
                if (null != elmodel)
                {
                    viewmodel.EnId = elmodel.ID;
                    viewmodel.EnResourceKey = elmodel.ResourceKey;
                    viewmodel.EnResourceValue = elmodel.ResourceValue;
                    viewmodel.EnResourcePage = elmodel.ResourcePage;
                }
                if (null != zhmodel)
                {
                    viewmodel.ZhId = zhmodel.ID;
                    viewmodel.ResourceKey = zhmodel.ResourceKey;
                    viewmodel.ResourceValue = zhmodel.ResourceValue;
                    viewmodel.ResourcePage = zhmodel.ResourcePage;
                }
            }
            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult AddorUpdate(ResourceViewModel model, string currentpage = "1")
        {
            ViewData["Currentpage"] = currentpage;
            if (!ModelState.IsValid)
                return View(model);
            var elmodel = _resourceBLL.GetModelByID(model.EnId);
            elmodel.ResourceValue = model.EnResourceValue;
            _resourceBLL.Update(elmodel);

            var cnmodel = _resourceBLL.GetModelByID(model.ZhId);
            cnmodel.ResourceValue = model.ResourceValue;
            _resourceBLL.Update(cnmodel);
            return RedirectToAction("List", new {id = currentpage});
        }

    }
}
