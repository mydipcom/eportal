


using System;
using System.Linq;
using System.Web.Mvc;
using MS.ECP.AAMAPrd.Areas.Admin.Models;
using MS.ECP.AAMAPrd.Areas.Admin.WebHelp;
using MS.ECP.AAMAPrd.WebPager;
using MS.ECP.Bll.EntityContext;
using MS.ECP.Model;
using MS.ECP.Model.CMS;

namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    public class MultiNewsController : Controller
    {
        private const int Pagesize = 10;
        private const int LanguageSelect = 2;
        readonly AAMAPrdContext _context = new AAMAPrdContext();



        public ActionResult List(int id = 1)
        {
            var dt = _context.MultiNewss.OrderByDescending(m => m.ModifyDate).Skip(id - 1).Take(Pagesize).ToList();
            var listcount = _context.MultiNewss.Count();
            var viewmodel = new PagedList<MultiNews>(dt, id, Pagesize, listcount);
            if (Request.IsAjaxRequest())
                return PartialView("_NewsPagingPartialPage", viewmodel);
            return View(viewmodel);
        }


        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(MutilNewsViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var datetimenow = DateTime.Now;
            var languguid = Guid.NewGuid().ToString();

            var enlishnews = new MS.ECP.Model.MultiNews()
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

            var zhnews = new MS.ECP.Model.MultiNews()
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
            _context.MultiNewss.Add(enlishnews);
            _context.MultiNewss.Add(zhnews);
            _context.SaveChanges();
            return RedirectToAction("List");
        }



        public ActionResult Edit(string languid)
        {

            var lanlist =
                _context.MultiNewss.Where(m => m.LangGuid == languid)
                    .OrderByDescending(m => m.ModifyDate)
                    .Take(LanguageSelect)
                    .ToList();

            var newsViewModel = new MutilNewsViewModel();
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
        public ActionResult Edit(MutilNewsViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var tuple = EventsViewModelToEvent(model,
                new Tuple<MultiNews, MultiNews>(_context.MultiNewss.FirstOrDefault(m => m.ID == model.EnId),
                    _context.MultiNewss.FirstOrDefault(m => m.ID == model.ZhId)));

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
                _context.MultiNewss.Add(elmodel);
            }
            else if (elmodel.LangGuid != null && elmodel.ID != 0)
            {
                _context.SaveChanges();
            }

            if (zhmodel.LangGuid == null && zhmodel.ID == 0 && zhmodel.Content != elmodel.Content)
            {
                var datetimenow = DateTime.Now;
                zhmodel.CreateDate = datetimenow;
                zhmodel.ModifyDate = datetimenow;
                zhmodel.IssueDate = datetimenow;
                zhmodel.Guid = Guid.NewGuid().ToString();
                zhmodel.LangGuid = elmodel.LangGuid;
                   _context.MultiNewss.Add(zhmodel);
            }
            else if (zhmodel.LangGuid != null && zhmodel.ID != 0)
            {
                zhmodel.LangGuid = elmodel.LangGuid;
                _context.SaveChanges();
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

            var news = _context.MultiNewss.FirstOrDefault(m => m.ID == id);
            _context.MultiNewss.Remove(news);
            _context.SaveChanges();
            return RedirectToAction("List");
        }



        #region private method

        private Tuple<MultiNews, MultiNews> EventsViewModelToEvent(MutilNewsViewModel model,
            Tuple<MultiNews, MultiNews> tuple)
        {
            var elmodel = tuple.Item1 ?? new MultiNews();
            elmodel.Title = model.EnTitle;
            elmodel.Content = model.EnContent;
            elmodel.LanguageCode = LanageConfig.EnLan;

            var zhmodel = tuple.Item2 ?? new MultiNews();
            zhmodel.Title = model.ZhTitle ?? model.EnTitle;
            zhmodel.Content = model.ZhContent ?? model.EnContent;
            zhmodel.LanguageCode = LanageConfig.ZhLan;
            return new Tuple<MultiNews, MultiNews>(elmodel, zhmodel);
        }
        #endregion

    }
}

