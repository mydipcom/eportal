using System;
using System.Linq;
using System.Web.Mvc;
using MS.ECP.AAMAPrd.Areas.Admin.Models;
using MS.ECP.AAMAPrd.Areas.Admin.WebHelp;
using MS.ECP.AAMAPrd.WebPager;
using MS.ECP.Model.CMS;

namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        private readonly BLL.CMS.News _newsBLL = new BLL.CMS.News();
        private const int Pagesize = 10;
        private const int LanguageSelect = 2;

        public ActionResult List(int id = 1)
        {
            var dt = _newsBLL.GetListByPage("", id == 1 ? 0 : (id - 1)*Pagesize + 1, id*Pagesize);
            var listcount = _newsBLL.GetRecordCount("");
            var viewmodel = new PagedList<News>(dt, id, Pagesize, listcount);
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
        public ActionResult Add(NewsViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var datetimenow = DateTime.Now;
            var languguid = Guid.NewGuid().ToString();

            var enlishnews = new News
            {
                LangGuid = languguid,
                Guid = Guid.NewGuid().ToString(),
                Title = model.EnTitle,
                Content = model.EnContent,
                Specification = model.EnSpecification,
                LanguageCode = LanageConfig.EnLan,
                CreateDate = datetimenow,
                ModifyDate = datetimenow,
                IssueDate = datetimenow
            };

            var zhnews = new News
            {
                LangGuid = languguid,
                Guid = Guid.NewGuid().ToString(),
                Title = model.ZhTitle ?? model.EnTitle,
                Content = model.ZhContent ?? model.EnContent,
                Specification = model.ZhSpecification ?? model.EnContent,
                LanguageCode = LanageConfig.ZhLan,
                CreateDate = datetimenow,
                ModifyDate = datetimenow,
                IssueDate = datetimenow
            };

            _newsBLL.Add(enlishnews);
            _newsBLL.Add(zhnews);

            return RedirectToAction("List");
        }



        public ActionResult Edit(string languid)
        {
            var lanlist = _newsBLL.GetList(LanguageSelect, String.Format(" LangGuid='{0}' ", languid));
            var newsViewModel = new NewsViewModel();
            var elmodel = lanlist.FirstOrDefault(d => d.LanguageCode == LanageConfig.EnLan);
            var zhmodel = lanlist.FirstOrDefault(d => d.LanguageCode == LanageConfig.ZhLan);
            if (null != elmodel)
            {
                newsViewModel.EnTitle = elmodel.Title;
                newsViewModel.EnContent = elmodel.Content;
                newsViewModel.EnSpecification = elmodel.Specification;
                newsViewModel.EnId = elmodel.ID;
            }

            if (null != zhmodel)
            {
                newsViewModel.ZhTitle = zhmodel.Title;
                newsViewModel.ZhContent = zhmodel.Content;
                newsViewModel.ZhSpecification = zhmodel.Specification;
                newsViewModel.ZhId = zhmodel.ID;
            }
            return View(newsViewModel);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var tuple = NewsViewModelToNews(model,
                new Tuple<News, News>(_newsBLL.GetModelByID(model.EnId), _newsBLL.GetModelByID(model.ZhId)));
            var elmodel = tuple.Item1;
            var zhmodel = tuple.Item2;
            if (0 == elmodel.ID && null == elmodel.LangGuid)
            {
                elmodel.CreateDate = DateTime.Now;
                elmodel.LangGuid = Guid.NewGuid().ToString();
                _newsBLL.Add(elmodel);
            }
            else if (elmodel.LangGuid != null && elmodel.ID != 0)
            {
                _newsBLL.Update(elmodel);
            }


            if (zhmodel.LangGuid == null && zhmodel.ID == 0 && zhmodel.Content != elmodel.Content)
            {
                zhmodel.CreateDate = DateTime.Now;
                zhmodel.LangGuid = elmodel.LangGuid;
                _newsBLL.Add(zhmodel);
            }
            else if (zhmodel.LangGuid != null && zhmodel.ID != 0)
            {
                zhmodel.LangGuid = elmodel.LangGuid;
                _newsBLL.Update(zhmodel);
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

            if (!_newsBLL.Exists(id))
            {
                return RedirectToAction("List");
            }

            _newsBLL.Delete(id);
            return RedirectToAction("List");

        }

        #region private method

        private Tuple<News, News> NewsViewModelToNews(NewsViewModel model, Tuple<News, News> tuple)
        {
            var elmodel = tuple.Item1 ?? new News();
            var zhmodel = tuple.Item2 ?? new News();

            elmodel.Title = model.EnTitle;
            elmodel.Content = model.EnContent;
            elmodel.Specification = model.EnSpecification;
            elmodel.ModifyDate = DateTime.Now;
            elmodel.LanguageCode = LanageConfig.EnLan;

            zhmodel.Title = model.ZhTitle;
            zhmodel.Content = model.ZhContent;
            zhmodel.Specification = model.ZhSpecification;
            zhmodel.ModifyDate = DateTime.Now;
            zhmodel.LanguageCode = LanageConfig.ZhLan;
            return new Tuple<News, News>(elmodel, zhmodel);
        }

        #endregion

    }
}
