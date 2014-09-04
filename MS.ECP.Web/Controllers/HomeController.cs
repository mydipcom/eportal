using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using MS.ECP.Model.CMS;
using MS.ECP.Utility;
using MS.ECP.Web.Filters;
using MS.ECP.Web.Models;

using MS.ECP.BLL;
using MS.ECP.Model;
using MS.ECP.Common;
using MS.ECP.Web.WebHelp;
using MS.ECP.Web.WebPager;
using Job = MS.ECP.BLL.CMS.Job;
using News = MS.ECP.BLL.CMS.News;
using System.Web.UI.WebControls;


namespace MS.ECP.Web.Controllers
{
    public class HomeController : BaseController 
    {
        private readonly BLL.CMS.Category _categoryBLL = new BLL.CMS.Category();
        private readonly BLL.CMS.PageContent _contentBLL = new BLL.CMS.PageContent();
        private readonly Job _job = new Job();

        private readonly News _news = new News();
        private const int Pagesize = 6;
        //private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(Utils.GetXmlMapPath("Configpath"));

        /*     [StaticFileWriteFilter] */

        public ActionResult Index()
        {
            var viewmodel = new IndexViewModel();
            var firstOrDefault = _categoryBLL.GetList(String.Format(" ParentGuid='0' and Categoryname=N'{0}' ",
                LanageCommon.MenuLblSolutions)).FirstOrDefault();
            if (firstOrDefault != null)
                viewmodel.SolutionsLanGuid =
                    firstOrDefault.Guid;
            return View(viewmodel);
        }


        /*      [StaticFileWriteFilter] */

        public ActionResult Technologies(string languid, string currentGuid)
        {
            if (String.IsNullOrEmpty(languid))
            {
                var model = _categoryBLL.GetModelByWhere(String.Format(" ParentGuid='0' and Categoryname=N'{0}' ",
                    LanageCommon.MenuLblTechnologies));
                if (model == null) return View(new CategoryViewModel());
                languid = model.Guid;
            }
            var viewmodle = CategoryViewModelBuilder(languid, currentGuid);
            return View(viewmodle);
        }


        /*   [StaticFileWriteFilter] */

        public ActionResult Solutions(string languid, string currentGuid)
        {
            if (String.IsNullOrEmpty(languid))
            {
                var model = _categoryBLL.GetModelByWhere(String.Format(" ParentGuid='0' and Categoryname=N'{0}' ",
                    LanageCommon.MenuLblSolutions));
                if (model == null) return View(new CategoryViewModel());
                languid = model.Guid;
            }

            var viewmodle = CategoryViewModelBuilder(languid, currentGuid);
            ViewBag.Keywords = viewmodle.CurrentPageContent.Keywords;
            ViewBag.Description = viewmodle.CurrentPageContent.Description;
            ViewBag.Pagetitle = viewmodle.CurrentPageContent.SeoTitle;
            return View(viewmodle);
        }


        public ActionResult Aboutus()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Aboutus(Feedback feedback)
        {
            if (ModelState.IsValid && Feedback(feedback)) return View();
            feedback.IsValidBack = true;
            ModelState.AddModelError("", "发送失败");
            return View(feedback);
        }



        public ActionResult Workwithus(string langGuid, int id = 1)
        {
            var dtNews = _job.GetListByPage(SqlLanWhere, id == 1 ? id : (id - 1) * Pagesize + 1, id * Pagesize);
            var listcount = _job.GetRecordCount(SqlLanWhere);
            var viemodel = new JobViewModel
            {
                CurrentJob =
                    String.IsNullOrEmpty(langGuid) && id == 1
                        ? dtNews.FirstOrDefault()
                        : dtNews.FirstOrDefault(
                            d => d.LangGuid == langGuid),
                JobTitles = new PagedList<Model.CMS.Job>(dtNews, id, Pagesize, listcount)
            };
            viemodel.CurrentJob = viemodel.CurrentJob ?? new Model.CMS.Job();
            if (Request.IsAjaxRequest())
                return PartialView("_JobTitlePartialPage", viemodel);

            ViewBag.Keywords = viemodel.CurrentJob.Keywords;
            ViewBag.Description = viemodel.CurrentJob.Description;
            ViewBag.Pagetitle = viemodel.CurrentJob.SeoTitle;
            return View(viemodel);
        }


        public ActionResult News(int id = 1)
        {
            var dtNews = _news.GetListByPage(SqlLanWhere, id == 1 ? id : (id - 1)*Pagesize + 1, id*Pagesize);
            var listcount = _news.GetRecordCount(SqlLanWhere);
            var viemodel = new NewsViewModel
            {
                NewsTitles = new PagedList<Model.CMS.News>(dtNews, id, Pagesize, listcount),
                CurrentNews = _news.GetNewestModelByLangCode(LanageCommon.CurrenLanage) ?? new Model.CMS.News()
            };
            if (Request.IsAjaxRequest())
                return PartialView("_NewTitlePartialPage", viemodel);

            ViewBag.Keywords = viemodel.CurrentNews.Keywords;
            ViewBag.Description = viemodel.CurrentNews.Description;
            ViewBag.Pagetitle = viemodel.CurrentNews.SeoTitle;
            return View(viemodel);
        }


        public ActionResult NewsDetail(string langGuid, int id = 1)
        {
            var dtNews = _news.GetModelByLangGuidAndLangCode(langGuid, LanageCommon.CurrenLanage) ??
                         new Model.CMS.News();
            ViewBag.IndexId = id;
            ViewBag.Keywords = dtNews.Keywords;
            ViewBag.Description = dtNews.Description;
            ViewBag.Pagetitle = dtNews.SeoTitle;
            return View(dtNews);
        }


        #region private

        private CategoryViewModel CategoryViewModelBuilder(string languid, string contentid)
        {
            var viewmodle = new CategoryViewModel
            {
                CurrentPageContent = _contentBLL.GetModelByLangGuidAndLangCode(contentid, ResourcesHelper.GetLang()),
                CaridLanguid = languid
            };
            var catltype = _categoryBLL.GetModelByLangGuidAndLangCode(languid, ResourcesHelper.GetLang());
            PageContent firstPageContent = null;
            foreach (var catype in _categoryBLL.GetList(String.Format(" ParentGuid='{0}' ", catltype.ID)))
            {
                var titlevm = new TitleListViewModel {TitleCategory = catype};
                foreach (var caiteme in _contentBLL.GetList(String.Format(" CategoryID='{0}' ", catype.ID)))
                {
                    firstPageContent = firstPageContent ?? caiteme;
                    titlevm.TitleList.Add(caiteme);
                }
                viewmodle.TitlViewModel.Add(titlevm);
            }
            viewmodle.CurrentPageContent = viewmodle.CurrentPageContent ?? (firstPageContent ?? new PageContent());
            return viewmodle;
        }

        private String SqlLanWhere
        {
            get
            {
                return String.Format(" LanguageCode='{0}'", LanageCommon.CurrenLanage);
            }
        }

        public bool Feedback(Feedback fbFeedback)
        {
            try
            {
                var userInfo = new Model.UserInfo();
                var guid = Guid.NewGuid().ToString();
                userInfo.Guid = guid;
                userInfo.UserName = fbFeedback.UserName;

                //发送邮件给系统管理员
                var modMail = new MailModel
                {
                    ToAddress = ConfigurationManager.AppSettings["EmailTo"],
                    UserCode = guid,
                    MailName = "feedback",
                    IsActionCode = true
                };

                var listitem = new List<ListItem>()
                {
                    new ListItem()
                    {
                        Value = "{$data_UserName$}",
                        Text = fbFeedback.UserName
                    },
                    new ListItem()
                    {
                        Value = "{$data_Subject$}",
                        Text = fbFeedback.Subject
                    },
                    new ListItem()
                    {
                        Value = "{$data_Body$}",
                        Text = fbFeedback.Body
                    }
                };
                return FrontUtility.SendMailMiss(modMail, listitem, "来自网上的反馈");
            }
            catch (Exception ee)
            {
                return false;
            }
        }

        #endregion

    }
}
