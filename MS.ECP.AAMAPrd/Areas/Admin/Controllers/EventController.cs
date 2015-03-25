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

    public class EventController : BaseController
    {
        private readonly DbSet<CmsEvent> _recentEventsQuery;

        public EventController()
        {
            this._recentEventsQuery = base.Contentx.RecentEvents;
        }

        public ActionResult Add()
        {
            return base.View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(EventsViewModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            DateTime now = DateTime.Now;
            string str = Guid.NewGuid().ToString();
            CmsEvent entity = new CmsEvent
            {
                LangGuid = str,
                Guid = Guid.NewGuid().ToString(),
                Title = model.EnTitle,
                Content = model.EnContent,
                LanguageCode = LanageConfig.EnLan,
                CreateDate = now,
                ModifyDate = now,
                IssueDate = now
            };
            CmsEvent event3 = new CmsEvent
            {
                LangGuid = str,
                Guid = Guid.NewGuid().ToString(),
                Title = model.ZhTitle ?? model.EnTitle,
                Content = model.ZhContent ?? model.EnContent,
                LanguageCode = LanageConfig.ZhLan,
                CreateDate = now,
                ModifyDate = now,
                IssueDate = now
            };
            this._recentEventsQuery.Add(entity);
            this._recentEventsQuery.Add(event3);
            base.SaveChange();
            return base.RedirectToAction("List");
        }

        public ActionResult Del(int id = 0)
        {
            if ((id != 0) && (id >= 0))
            {
                CmsEvent entity = this._recentEventsQuery.FirstOrDefault<CmsEvent>(m => m.ID == id);
                this._recentEventsQuery.Remove(entity);
                base.SaveChange();
            }
            return base.RedirectToAction("List");
        }

        [ValidateInput(false), HttpPost]
        public ActionResult Edit(EventsViewModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            Tuple<CmsEvent, CmsEvent> tuple = this.EventsViewModelToEvent(model, new Tuple<CmsEvent, CmsEvent>(this._recentEventsQuery.FirstOrDefault<CmsEvent>(m => m.ID == model.EnId), this._recentEventsQuery.FirstOrDefault<CmsEvent>(m => m.ID == model.ZhId)));
            CmsEvent entity = tuple.Item1;
            CmsEvent event3 = tuple.Item2;
            string str = Guid.NewGuid().ToString();
            DateTime now = DateTime.Now;
            entity.CreateDate = base.DateTimeFormat(model.EnCreateTime);
            entity.ModifyDate = now;
            entity.IssueDate = now;
            entity.Guid = Guid.NewGuid().ToString();
            entity.LangGuid = str;
            if ((entity.LangGuid == null) && (entity.ID == 0))
            {
                this._recentEventsQuery.Add(entity);
            }
            event3.CreateDate = base.DateTimeFormat(model.ZhCreateTime);
            event3.ModifyDate = now;
            event3.IssueDate = now;
            event3.Guid = Guid.NewGuid().ToString();
            event3.LangGuid = str;
            if ((event3.LangGuid == null) && (event3.ID == 0))
            {
                this._recentEventsQuery.Add(event3);
            }
            base.SaveChange();
            return base.RedirectToAction("List");
        }

        public ActionResult Edit(string languid)
        {
            List<CmsEvent> source = (from m in this._recentEventsQuery
                                     where m.LangGuid == languid
                                     orderby m.ModifyDate descending
                                     select m).Take<CmsEvent>(2).ToList<CmsEvent>();
            EventsViewModel model = new EventsViewModel();
            CmsEvent event2 = source.FirstOrDefault<CmsEvent>(d => d.LanguageCode == LanageConfig.EnLan);
            CmsEvent event3 = source.FirstOrDefault<CmsEvent>(d => d.LanguageCode == LanageConfig.ZhLan);
            if (event2 != null)
            {
                model.EnTitle = event2.Title;
                model.EnContent = event2.Content;
                model.EnId = event2.ID;
                model.EnCreateTime = base.DateToString(event2.CreateDate);
            }
            if (event3 != null)
            {
                model.ZhTitle = event3.Title;
                model.ZhContent = event3.Content;
                model.ZhId = event3.ID;
                model.ZhCreateTime = base.DateToString(event3.CreateDate);
            }
            return base.View(model);
        }

        private Tuple<CmsEvent, CmsEvent> EventsViewModelToEvent(EventsViewModel model, Tuple<CmsEvent, CmsEvent> tuple)
        {
            CmsEvent event2 = tuple.Item1 ?? new CmsEvent();
            event2.Title = model.EnTitle;
            event2.Content = model.EnContent;
            event2.LanguageCode = LanageConfig.EnLan;
            CmsEvent event3 = tuple.Item2 ?? new CmsEvent();
            event3.Title = model.ZhTitle ?? model.EnTitle;
            event3.Content = model.ZhContent ?? model.EnContent;
            event3.LanguageCode = LanageConfig.ZhLan;
            return new Tuple<CmsEvent, CmsEvent>(event2, event3);
        }

        public ActionResult List(int id = 1)
        {
            List<CmsEvent> currentPageItems = (from m in this._recentEventsQuery
                                               orderby m.ModifyDate descending
                                               select m).Skip<CmsEvent>(((id - 1) * 10)).Take<CmsEvent>(10).ToList<CmsEvent>();
            int totalItemCount = this._recentEventsQuery.Count<CmsEvent>();
            PagedList<CmsEvent> model = new PagedList<CmsEvent>(currentPageItems, id, 10, totalItemCount);
            if (base.Request.IsAjaxRequest())
            {
                return this.PartialView("_EventPagingPartialPage", model);
            }
            return base.View(model);
        }
    }
}
