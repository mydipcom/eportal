namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    using MS.ECP.AAMAPrd.Areas.Admin.Models;
    using MS.ECP.AAMAPrd.Areas.Admin.WebHelp;
    using MS.ECP.AAMAPrd.WebPager;
    using MS.ECP.Model.CMS;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web.Mvc;

    public class NewsController : BaseController
    {
        private readonly DbSet<News> _upcomingNewsQuery;

        public NewsController()
        {
            this._upcomingNewsQuery = base.Contentx.UpcomingNews;
        }

        public ActionResult Add()
        {
            return base.View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(NewsViewModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            DateTime now = DateTime.Now;
            string str = Guid.NewGuid().ToString();
            News entity = new News
            {
                LangGuid = str,
                Guid = Guid.NewGuid().ToString(),
                Title = model.EnTitle,
                Content = model.EnContent,
                Specification = model.EnSpecification,
                LanguageCode = LanageConfig.EnLan,
                CreateDate = now,
                ModifyDate = now,
                IssueDate = now
            };
            News news2 = new News
            {
                LangGuid = str,
                Guid = Guid.NewGuid().ToString(),
                Title = model.ZhTitle ?? model.EnTitle,
                Content = model.ZhContent ?? model.EnContent,
                Specification = model.ZhSpecification ?? model.EnContent,
                LanguageCode = LanageConfig.ZhLan,
                CreateDate = now,
                ModifyDate = now,
                IssueDate = now
            };
            this._upcomingNewsQuery.Add(entity);
            this._upcomingNewsQuery.Add(news2);
            base.SaveChange();
            return base.RedirectToAction("List");
        }

        public ActionResult Del(int id = 0)
        {
            if ((id != 0) && (id >= 0))
            {
                News entity = this._upcomingNewsQuery.FirstOrDefault<News>(m => m.ID == id);
                this._upcomingNewsQuery.Remove(entity);
                base.SaveChange();
            }
            return base.RedirectToAction("List");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(NewsViewModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            Tuple<News, News> tuple = this.NewsViewModelToNews(model, new Tuple<News, News>(this._upcomingNewsQuery.FirstOrDefault<News>(m => m.ID == model.EnId), this._upcomingNewsQuery.FirstOrDefault<News>(m => m.ID == model.ZhId)));
            News entity = tuple.Item1;
            News news2 = tuple.Item2;
            string str = Guid.NewGuid().ToString();
            entity.CreateDate = base.DateTimeFormat(model.EnCreateTime);
            entity.LangGuid = str;
            if ((entity.ID == 0) && (entity.LangGuid == null))
            {
                this._upcomingNewsQuery.Add(entity);
            }
            news2.CreateDate = base.DateTimeFormat(model.ZhCreateTime);
            news2.LangGuid = str;
            if (((news2.LangGuid == null) && (news2.ID == 0)) && (news2.Content != entity.Content))
            {
                this._upcomingNewsQuery.Add(news2);
            }
            base.SaveChange();
            return base.RedirectToAction("List");
        }

        public ActionResult Edit(string languid)
        {
            List<News> source = (from m in this._upcomingNewsQuery
                                 where m.LangGuid == languid
                                 orderby m.ModifyDate descending
                                 select m).Take<News>(2).ToList<News>();
            NewsViewModel model = new NewsViewModel();
            News news = source.FirstOrDefault<News>(d => d.LanguageCode == LanageConfig.EnLan);
            News news2 = source.FirstOrDefault<News>(d => d.LanguageCode == LanageConfig.ZhLan);
            if (news != null)
            {
                model.EnTitle = news.Title;
                model.EnContent = news.Content;
                model.EnSpecification = news.Specification;
                model.EnId = news.ID;
                model.EnCreateTime = base.DateToString(news.CreateDate);
            }
            if (news2 != null)
            {
                model.ZhTitle = news2.Title;
                model.ZhContent = news2.Content;
                model.ZhSpecification = news2.Specification;
                model.ZhId = news2.ID;
                model.ZhCreateTime = base.DateToString(news2.CreateDate);
            }
            return base.View(model);
        }

        public ActionResult List(int id = 1)
        {
            List<News> currentPageItems = (from m in this._upcomingNewsQuery
                                           orderby m.ModifyDate descending
                                           select m).Skip<News>(((id - 1) * 10)).Take<News>(10).ToList<News>();
            int totalItemCount = this._upcomingNewsQuery.Count<News>();
            PagedList<News> model = new PagedList<News>(currentPageItems, id, 10, totalItemCount);
            if (base.Request.IsAjaxRequest())
            {
                return this.PartialView("_NewsPagingPartialPage", model);
            }
            return base.View(model);
        }

        private Tuple<News, News> NewsViewModelToNews(NewsViewModel model, Tuple<News, News> tuple)
        {
            News news = tuple.Item1 ?? new News();
            News news2 = tuple.Item2 ?? new News();
            news.Title = model.EnTitle;
            news.Content = model.EnContent;
            news.Specification = model.EnSpecification;
            news.ModifyDate = DateTime.Now;
            news.LanguageCode = LanageConfig.EnLan;
            news2.Title = model.ZhTitle;
            news2.Content = model.ZhContent;
            news2.Specification = model.ZhSpecification;
            news2.ModifyDate = DateTime.Now;
            news2.LanguageCode = LanageConfig.ZhLan;
            return new Tuple<News, News>(news, news2);
        }
    }
}
