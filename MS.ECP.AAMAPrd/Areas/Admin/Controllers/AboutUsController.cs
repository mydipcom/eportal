using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MS.ECP.AAMAPrd.Areas.Admin.Models;
using MS.ECP.AAMAPrd.Areas.Admin.WebHelp;
using MS.ECP.AAMAPrd.WebPager;
using MS.ECP.BLL.CMS;
using MS.ECP.Model.CMS;

namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{

    public class AboutUsController : BaseController
    {
        private readonly BLL.CMS.AboutusBll _aboutusBllBLL = new BLL.CMS.AboutusBll();
        private const int Pagesize = 10;
        private const int LanguageSelect = 2;

        public ActionResult List()
        {
            return View(_aboutusBllBLL.GetAllList() ?? new List<Aboutus>());
        }


        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(AboutUsModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var datetimenow = DateTime.Now;
            var languguid = Guid.NewGuid().ToString();

            var enlishnews = new MS.ECP.Model.CMS.Aboutus()
            {
                LangGuid = languguid,
                Guid = Guid.NewGuid().ToString(),
                LinkTitle = model.EnTitle,
                Content = model.EnContent,
                LanguageCode = LanageConfig.EnLan,
                Status = 0,
                SortOrder = model.EnSortOrder
            };

            var zhnews = new Aboutus
            {
                LangGuid = languguid,
                Guid = Guid.NewGuid().ToString(),
                LinkTitle = model.ZhTitle ?? model.EnTitle,
                Content = model.ZhContent ?? model.EnContent,
                LanguageCode = LanageConfig.ZhLan,
                Status = 0,
                SortOrder = model.ZhSortOrder
            };

            _aboutusBllBLL.Add(enlishnews);
            _aboutusBllBLL.Add(zhnews);

            return RedirectToAction("List");
        }



        public ActionResult Edit(string languid)
        {
            var lanlist = _aboutusBllBLL.GetTop(LanguageSelect, String.Format(" LangGuid='{0}' ", languid));
            var newsViewModel = new AboutUsModel();
            var elmodel = lanlist.FirstOrDefault(d => d.LanguageCode == LanageConfig.EnLan);
            var zhmodel = lanlist.FirstOrDefault(d => d.LanguageCode == LanageConfig.ZhLan);
            if (null != elmodel)
            {
                newsViewModel.EnTitle = elmodel.LinkTitle;
                newsViewModel.EnContent = elmodel.Content;
                newsViewModel.EnId = elmodel.ID;
                newsViewModel.EnSortOrder = elmodel.SortOrder??0;
            }

            if (null != zhmodel)
            {
                newsViewModel.ZhTitle = zhmodel.LinkTitle;
                newsViewModel.ZhContent = zhmodel.Content;
                newsViewModel.ZhId = zhmodel.ID;
                newsViewModel.ZhSortOrder = zhmodel.SortOrder ?? 0;
            }
            return View(newsViewModel);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(AboutUsModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var tuple = AboutUsModelToAboutus(model,
                new Tuple<Aboutus, Aboutus>(_aboutusBllBLL.GetModelByID(model.EnId),
                    _aboutusBllBLL.GetModelByID(model.ZhId)));
            var elmodel = tuple.Item1;
            var zhmodel = tuple.Item2;

            if (elmodel.LangGuid == null && elmodel.ID == 0)
            {
                elmodel.Status = 0;
                elmodel.Guid = Guid.NewGuid().ToString();
                elmodel.LangGuid = Guid.NewGuid().ToString();
                _aboutusBllBLL.Add(elmodel);
            }
            if (elmodel.LangGuid != null && elmodel.ID != 0)
            {
                _aboutusBllBLL.Update(elmodel);
            }


            if (zhmodel.LangGuid == null && zhmodel.ID == 0 && zhmodel.Content != elmodel.Content)
            {
                zhmodel.Status = 0;
                zhmodel.Guid = Guid.NewGuid().ToString();
                zhmodel.LangGuid = elmodel.LangGuid;
                _aboutusBllBLL.Add(zhmodel);
            }
            else if (zhmodel.LangGuid != null && zhmodel.ID != 0)
            {
                zhmodel.LangGuid = elmodel.LangGuid;
                _aboutusBllBLL.Update(zhmodel);
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

            if (!_aboutusBllBLL.Exists(id))
            {
                return RedirectToAction("List");
            }

            _aboutusBllBLL.Delete(id);
            return RedirectToAction("List");

        }



        #region private method

        private Tuple<Aboutus, Aboutus> AboutUsModelToAboutus(AboutUsModel model,
            Tuple<Aboutus, Aboutus> tuple)
        {
            var elmodel = tuple.Item1 ?? new Aboutus();
            elmodel.LinkTitle = model.EnTitle;
            elmodel.Content = model.EnContent;
            elmodel.SortOrder = model.EnSortOrder;
            elmodel.LanguageCode = LanageConfig.EnLan;

            var zhmodel = tuple.Item2 ?? new Aboutus();
            zhmodel.LinkTitle = model.ZhTitle ?? model.EnTitle;
            zhmodel.Content = model.ZhContent ?? model.EnContent;
            zhmodel.LanguageCode = LanageConfig.ZhLan;
            zhmodel.SortOrder = model.ZhSortOrder;
            return new Tuple<Aboutus, Aboutus>(elmodel, zhmodel);
        }
        #endregion

    }

}
