using System;
using System.Linq;
using System.Web.Mvc;
using MS.ECP.AAMAPrd.Areas.Admin.Models;
using MS.ECP.AAMAPrd.Areas.Admin.WebHelp;
using MS.ECP.AAMAPrd.WebPager;
using MS.ECP.Model.CMS;

namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    public class EventController : Controller
    {
        private readonly BLL.Event _event = new BLL.Event(); 
        private const int Pagesize = 10;
        private const int LanguageSelect = 2;

        public ActionResult List(int id = 1)
        {
            var dt = _event.GetListByPage("", id == 1 ? 0 : (id - 1) * Pagesize + 1, id * Pagesize);
            var listcount = _event.GetRecordCount("");
            var viewmodel = new PagedList<Event>(dt, id, Pagesize, listcount);
            if (Request.IsAjaxRequest())
                return PartialView("_EventPagingPartialPage", viewmodel);
            return View(viewmodel);
        }


        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(EventsViewModel model)
        { 
            if (!ModelState.IsValid) return View(model); 

            var datetimenow = DateTime.Now;
            var languguid = Guid.NewGuid().ToString();

            var enlishnews = new MS.ECP.Model.CMS.Event
            {
                LangGuid = languguid,
                Guid = Guid.NewGuid().ToString(),
                Title = model.EnTitle,
                Content = model.EnContent,
                LanguageCode = LanageConfig.EnLan,
                CreateDate = datetimenow,
                ModifyDate = datetimenow,
                IssueDate = datetimenow
            };

            var zhnews = new MS.ECP.Model.CMS.Event
            {
                LangGuid = languguid,
                Guid = Guid.NewGuid().ToString(),
                Title = model.ZhTitle ?? model.EnTitle,
                Content = model.ZhContent ?? model.EnContent,
                LanguageCode = LanageConfig.ZhLan,
                CreateDate = datetimenow,
                ModifyDate = datetimenow,
                IssueDate = datetimenow
            };

            _event.Add(enlishnews);
            _event.Add(zhnews);

            return RedirectToAction("List");
        } 



        public ActionResult Edit(string languid)
        {
            var lanlist = _event.GetList(LanguageSelect, String.Format(" LangGuid='{0}' ", languid));
            var newsViewModel = new EventsViewModel();
            var elmodel = lanlist.FirstOrDefault(d => d.LanguageCode == LanageConfig.EnLan);
            var zhmodel = lanlist.FirstOrDefault(d => d.LanguageCode == LanageConfig.ZhLan);
            if (null != elmodel)
            {
                newsViewModel.EnTitle = elmodel.Title;
                newsViewModel.EnContent = elmodel.Content;
                newsViewModel.EnId = elmodel.ID;
            }

            if (null != zhmodel)
            {
                newsViewModel.ZhTitle = zhmodel.Title;
                newsViewModel.ZhContent = zhmodel.Content;
                newsViewModel.ZhId = zhmodel.ID;
            }
            return View(newsViewModel);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EventsViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var tuple = EventsViewModelToEvent(model,
                new Tuple<Event, Event>(_event.GetModelByID(model.EnId),
                    _event.GetModelByID(model.ZhId)));
            var elmodel = tuple.Item1;
            var zhmodel = tuple.Item2;

            if (elmodel.LangGuid == null && elmodel.ID == 0)
            {
                var datetimenow = DateTime.Now;
                elmodel.CreateDate = datetimenow;
                elmodel.ModifyDate = datetimenow;
                elmodel.IssueDate = datetimenow;
                elmodel.Guid = Guid.NewGuid().ToString();
                elmodel.LangGuid = Guid.NewGuid().ToString();
                _event.Add(elmodel);
            }
            else if (elmodel.LangGuid != null && elmodel.ID != 0)
            {
                _event.Update(elmodel);
            }

            if (zhmodel.LangGuid == null && zhmodel.ID == 0 && zhmodel.Content != elmodel.Content)
            {
                var datetimenow = DateTime.Now;
                zhmodel.CreateDate = datetimenow;
                zhmodel.ModifyDate = datetimenow;
                zhmodel.IssueDate = datetimenow;
                zhmodel.Guid = Guid.NewGuid().ToString();
                zhmodel.LangGuid = elmodel.LangGuid;
                _event.Add(zhmodel);
            }
            else if (zhmodel.LangGuid != null && zhmodel.ID != 0)
            {
                zhmodel.LangGuid = elmodel.LangGuid;
                _event.Update(zhmodel);
            }

            return RedirectToAction("List");
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Del(int id = 0)
        {
            if (id == 0 || id < 0)
            {
                return RedirectToAction("List");
            }

            if (!_event.Exists(id))
            {
                return RedirectToAction("List");
            }

            _event.Delete(id);
            return RedirectToAction("List");

        }



        #region private method

        private Tuple<Event, Event> EventsViewModelToEvent(EventsViewModel model,
            Tuple<Event, Event> tuple)
        {
            var elmodel = tuple.Item1 ?? new Event();
            elmodel.Title = model.EnTitle;
            elmodel.Content = model.EnContent;
            elmodel.LanguageCode = LanageConfig.EnLan;

            var zhmodel = tuple.Item2 ?? new Event();
            zhmodel.Title = model.ZhTitle ?? model.EnTitle;
            zhmodel.Content = model.ZhContent ?? model.EnContent;
            zhmodel.LanguageCode = LanageConfig.ZhLan;
            return new Tuple<Event, Event>(elmodel, zhmodel);
        }
        #endregion

    }
}
