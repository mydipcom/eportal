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
using JobViewModel = MS.ECP.Web.Areas.Admin.Models.JobViewModel;

namespace MS.ECP.Web.Areas.Admin.Controllers
{
      [LoginAuthenticity]
    public class JobController : Controller
    {

        private readonly BLL.CMS.Job _jobBLL = new BLL.CMS.Job();
        private const int Pagesize = 15;


        public ActionResult List(string keywords, int id = 1, string lantype = "en-us")
        {
            ViewBag.Lanage = LanageConfig.LanHash[lantype];

            var sqlwhere = String.Format("  LanguageCode='{0}' ", lantype);
            if (!String.IsNullOrWhiteSpace(keywords) && keywords != AdminConfig.SearKeyWord)
                sqlwhere += String.Format(" and JobTitle like N'%{0}%' ", keywords);
            var dt = _jobBLL.GetListByPage(sqlwhere, id == 1 ? 0 : (id - 1)*Pagesize + 1, id*Pagesize);
            var listcount = _jobBLL.GetRecordCount(sqlwhere);
            var viewmodel = new PagedList<Job>(dt, id, Pagesize, listcount);
            if (Request.IsAjaxRequest())
                return PartialView("_JobPagingPartialPage", viewmodel);
            return View(viewmodel);
        }


        public ActionResult AddorUpdate(string lanid, string operation, string currentpage = "1")
        {
            ViewData["Currentpage"] = currentpage;
            ViewBag.Operation = operation;

            var viewmodel = new JobViewModel();
            if (!String.IsNullOrEmpty(lanid))
            {
                var elmodel = _jobBLL.GetModelByLangGuidAndLangCode(lanid, LanageConfig.EnLan);
                var zhmodel = _jobBLL.GetModelByLangGuidAndLangCode(lanid, LanageConfig.ZhLan);
                if (null != elmodel)
                {
                    viewmodel.EnId = elmodel.ID;
                    viewmodel.EnJobTitle = elmodel.JobTitle;
                    viewmodel.EnNeedNum = elmodel.NeedNum;
                    viewmodel.EnWorkplace = elmodel.Workplace;
                    viewmodel.EnSalary = elmodel.Salary;
                    viewmodel.EnLanguageRequired = elmodel.LanguageRequired;
                    viewmodel.EnTOrderNum = elmodel.ID;
                    viewmodel.EnJobDesc = elmodel.JobDesc;
                    viewmodel.EnJobBligation = elmodel.JobBligation;
                    viewmodel.EnTxtKeywords = elmodel.Keywords;
                    viewmodel.EnTxtDesc = elmodel.Description;
                    viewmodel.EnTxtHits = elmodel.SeoTitle;
                }
                if (null != zhmodel)
                {
                    viewmodel.ZhId = zhmodel.ID;
                    viewmodel.ZhJobTitle = zhmodel.JobTitle;
                    viewmodel.ZhNeedNum = zhmodel.NeedNum;
                    viewmodel.ZhWorkplace = zhmodel.Workplace;
                    viewmodel.ZhSalary = zhmodel.Salary;
                    viewmodel.ZhLanguageRequired = zhmodel.LanguageRequired;
                    viewmodel.ZhTOrderNum = zhmodel.ID;
                    viewmodel.ZhJobDesc = zhmodel.JobDesc;
                    viewmodel.ZhJobBligation = zhmodel.JobBligation;
                    viewmodel.TxtKeywords = zhmodel.Keywords;
                    viewmodel.TxtDesc = zhmodel.Description;
                    viewmodel.TxtHits = zhmodel.SeoTitle;
                }
            }
            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult AddorUpdate(JobViewModel model, string currentpage = "1")
        {
            ViewData["Currentpage"] = currentpage;

            if (!ModelState.IsValid)
                return View(model);

            var languguid = Guid.NewGuid().ToString();
            var elmodel = model.EnId != 0
                ? _jobBLL.GetModelByID(model.EnId)
                : new Job();

            elmodel.JobTitle = model.EnJobTitle;
            elmodel.NeedNum = model.EnNeedNum;
            elmodel.LangGuid = languguid;
            elmodel.LanguageCode = LanageConfig.EnLan;
            elmodel.Workplace = model.EnWorkplace;
            elmodel.Salary = model.EnSalary;
            elmodel.LanguageRequired = model.EnLanguageRequired;
            elmodel.OrderNum = model.EnTOrderNum;
            elmodel.JobDesc = model.EnJobDesc;
            elmodel.JobBligation = model.EnJobBligation;
            if (model.EnId == 0) elmodel.CreateDate = DateTime.Now;
            elmodel.Description = model.EnTxtDesc;
            elmodel.Keywords = model.EnTxtKeywords;
            elmodel.SeoTitle = model.EnTxtHits;


            var zhmodel = model.ZhId != 0
                ? _jobBLL.GetModelByID(model.ZhId)
                : new Job();
            zhmodel.JobTitle = model.ZhJobTitle ?? model.EnJobTitle;
            zhmodel.NeedNum = model.ZhNeedNum;
            zhmodel.LangGuid = languguid;
            zhmodel.LanguageCode = LanageConfig.ZhLan;
            zhmodel.Workplace = model.ZhWorkplace ?? model.EnWorkplace;
            zhmodel.Salary = model.ZhSalary ?? model.EnSalary;
            zhmodel.LanguageRequired = model.ZhLanguageRequired ?? model.EnLanguageRequired;
            zhmodel.OrderNum = model.ZhTOrderNum;
            zhmodel.JobDesc = model.ZhJobDesc ?? model.EnJobDesc;
            zhmodel.JobBligation = model.ZhJobBligation ?? model.EnJobBligation;
            if (model.ZhId == 0) elmodel.CreateDate = DateTime.Now;
            zhmodel.Description = model.TxtDesc;
            zhmodel.Keywords = model.TxtKeywords;
            zhmodel.SeoTitle = model.TxtHits;


            _jobBLL.AddOrUpdate(elmodel);
            _jobBLL.AddOrUpdate(zhmodel);

            return RedirectToAction("List", new { id = currentpage });
        }



        public ActionResult Del(int id = 0, string lan = "en-us")
        {
            _jobBLL.Delete(id);
            return RedirectToAction("List", new { lantype = lan });
        }

    }
}
