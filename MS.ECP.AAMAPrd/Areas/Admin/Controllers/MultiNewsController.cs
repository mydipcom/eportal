namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    using MS.ECP.AAMAPrd.Areas.Admin.Models;
    using MS.ECP.AAMAPrd.Areas.Admin.WebHelp;
    using MS.ECP.AAMAPrd.WebPager;
    using MS.ECP.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web.Mvc;

    public class MultiNewsController : BaseController
    {
        private readonly DbSet<MultiNews> _aamanewsquery;

        public MultiNewsController()
        {
            this._aamanewsquery = base.Contentx.AAMANews;
        }

        public ActionResult Add()
        {
            return base.View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(MutilNewsViewModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            DateTime now = DateTime.Now;
            string str = Guid.NewGuid().ToString();
            MultiNews entity = new MultiNews
            {
                LangGuid = str,
                Guid = Guid.NewGuid().ToString(),
                Title = model.EnTitle,
                Content = model.EnContent,
                LanguageCode = LanageConfig.EnLan,
                CreateDate = now,
                ModifyDate = now,
                IssueDate = new DateTime?(now)
            };
            MultiNews news2 = new MultiNews
            {
                LangGuid = str,
                Guid = Guid.NewGuid().ToString(),
                Title = model.ZhTitle ?? model.EnTitle,
                Content = model.ZhContent ?? model.EnContent,
                LanguageCode = LanageConfig.ZhLan,
                CreateDate = now,
                ModifyDate = now,
                IssueDate = new DateTime?(now)
            };
            this._aamanewsquery.Add(entity);
            this._aamanewsquery.Add(news2);
            base.SaveChange();
            return base.RedirectToAction("List");
        }

        public ActionResult Del(int id = 0)
        {
            if ((id != 0) && (id >= 0))
            {
                MultiNews entity = this._aamanewsquery.FirstOrDefault<MultiNews>(m => m.ID == id);
                this._aamanewsquery.Remove(entity);
                base.SaveChange();
            }
            return base.RedirectToAction("List");
        }

        [ValidateInput(false), HttpPost]
        public ActionResult Edit(MutilNewsViewModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            Tuple<MultiNews, MultiNews> tuple = this.EventsViewModelToEvent(model, new Tuple<MultiNews, MultiNews>(this._aamanewsquery.FirstOrDefault<MultiNews>(m => m.ID == model.EnId), this._aamanewsquery.FirstOrDefault<MultiNews>(m => m.ID == model.ZhId)));
            MultiNews entity = tuple.Item1;
            MultiNews news2 = tuple.Item2;
            string str = Guid.NewGuid().ToString();
            DateTime now = DateTime.Now;
            entity.CreateDate = base.DateTimeFormat(model.EnCreateTime);
            entity.ModifyDate = now;
            entity.IssueDate = new DateTime?(now);
            entity.Guid = Guid.NewGuid().ToString();
            entity.LangGuid = str;
            if ((entity.LangGuid == null) && (entity.ID == 0))
            {
                this._aamanewsquery.Add(entity);
            }
            news2.CreateDate = base.DateTimeFormat(model.ZhCreateTime);
            news2.ModifyDate = now;
            news2.IssueDate = new DateTime?(now);
            news2.Guid = Guid.NewGuid().ToString();
            news2.LangGuid = str;
            if (((news2.LangGuid == null) && (news2.ID == 0)) && (news2.Content != entity.Content))
            {
                this._aamanewsquery.Add(news2);
            }
            base.SaveChange();
            return base.RedirectToAction("List");
        }

        public ActionResult Edit(string languid)
        {
            List<MultiNews> source = (from m in this._aamanewsquery
                                      where m.LangGuid == languid
                                      orderby m.ModifyDate descending
                                      select m).Take<MultiNews>(2).ToList<MultiNews>();
            MutilNewsViewModel model = new MutilNewsViewModel();
            MultiNews news = source.FirstOrDefault<MultiNews>(d => d.LanguageCode == LanageConfig.EnLan);
            MultiNews news2 = source.FirstOrDefault<MultiNews>(d => d.LanguageCode == LanageConfig.ZhLan);
            if (news != null)
            {
                model.EnTitle = news.Title;
                model.EnContent = news.Content;
                model.EnId = news.ID;
                model.EnCreateTime = base.DateToString(news.CreateDate);
            }
            if (news2 != null)
            {
                model.ZhTitle = news2.Title;
                model.ZhContent = news2.Content;
                model.ZhId = news2.ID;
                model.ZhCreateTime = base.DateToString(news2.CreateDate);
            }
            return base.View(model);
        }

        private Tuple<MultiNews, MultiNews> EventsViewModelToEvent(MutilNewsViewModel model, Tuple<MultiNews, MultiNews> tuple)
        {
            MultiNews news = tuple.Item1 ?? new MultiNews();
            news.Title = model.EnTitle;
            news.Content = model.EnContent;
            news.LanguageCode = LanageConfig.EnLan;
            MultiNews news2 = tuple.Item2 ?? new MultiNews();
            news2.Title = model.ZhTitle ?? model.EnTitle;
            news2.Content = model.ZhContent ?? model.EnContent;
            news2.LanguageCode = LanageConfig.ZhLan;
            return new Tuple<MultiNews, MultiNews>(news, news2);
        }

        public ActionResult List(int id = 1)
        {
            List<MultiNews> currentPageItems = (from m in this._aamanewsquery
                                                orderby m.ModifyDate descending
                                                select m).Skip<MultiNews>(((id - 1) * 10)).Take<MultiNews>(10).ToList<MultiNews>();
            int totalItemCount = this._aamanewsquery.Count<MultiNews>();
            PagedList<MultiNews> model = new PagedList<MultiNews>(currentPageItems, id, 10, totalItemCount);
            if (base.Request.IsAjaxRequest())
            {
                return this.PartialView("_NewsPagingPartialPage", model);
            }
            return base.View(model);
        }
    }
}
