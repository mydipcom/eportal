namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    using MS.ECP.AAMAPrd.Areas.Admin.Models;
    using MS.ECP.AAMAPrd.Areas.Admin.WebHelp;
    using MS.ECP.BLL.CMS;
    using MS.ECP.Model.CMS;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web.Mvc;

    public class AboutUsController : BaseController
    {
        private readonly AboutusBll _aboutusBllBLL = new AboutusBll();
        private const int LanguageSelect = 2;
        private const int Pagesize = 10;

        private Tuple<Aboutus, Aboutus> AboutUsModelToAboutus(AboutUsModel model, Tuple<Aboutus, Aboutus> tuple)
        {
            Aboutus aboutus = tuple.Item1 ?? new Aboutus();
            aboutus.LinkTitle = model.EnTitle;
            aboutus.Content = model.EnContent;
            aboutus.SortOrder = new int?(model.EnSortOrder);
            aboutus.LanguageCode = LanageConfig.EnLan;
            Aboutus aboutus2 = tuple.Item2 ?? new Aboutus();
            aboutus2.LinkTitle = model.ZhTitle ?? model.EnTitle;
            aboutus2.Content = model.ZhContent ?? model.EnContent;
            aboutus2.LanguageCode = LanageConfig.ZhLan;
            aboutus2.SortOrder = new int?(model.ZhSortOrder);
            return new Tuple<Aboutus, Aboutus>(aboutus, aboutus2);
        }

        public ActionResult Add()
        {
            return base.View();
        }

        [ValidateInput(false), HttpPost]
        public ActionResult Add(AboutUsModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            DateTime now = DateTime.Now;
            string str = Guid.NewGuid().ToString();
            Aboutus aboutus = new Aboutus
            {
                LangGuid = str,
                Guid = Guid.NewGuid().ToString(),
                LinkTitle = model.EnTitle,
                Content = model.EnContent,
                LanguageCode = LanageConfig.EnLan,
                Status = 0,
                SortOrder = new int?(model.EnSortOrder)
            };
            Aboutus aboutus2 = new Aboutus
            {
                LangGuid = str,
                Guid = Guid.NewGuid().ToString(),
                LinkTitle = model.ZhTitle ?? model.EnTitle,
                Content = model.ZhContent ?? model.EnContent,
                LanguageCode = LanageConfig.ZhLan,
                Status = 0,
                SortOrder = new int?(model.ZhSortOrder)
            };
            this._aboutusBllBLL.Add(aboutus);
            this._aboutusBllBLL.Add(aboutus2);
            return base.RedirectToAction("List");
        }

        public ActionResult Del(int id = 0)
        {
            if (((id != 0) && (id >= 0)) && this._aboutusBllBLL.Exists(id))
            {
                this._aboutusBllBLL.Delete(id);
            }
            return base.RedirectToAction("List");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(AboutUsModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            Tuple<Aboutus, Aboutus> tuple = this.AboutUsModelToAboutus(model, new Tuple<Aboutus, Aboutus>(this._aboutusBllBLL.GetModelByID(model.EnId), this._aboutusBllBLL.GetModelByID(model.ZhId)));
            Aboutus aboutus = tuple.Item1;
            Aboutus aboutus2 = tuple.Item2;
            if ((aboutus.LangGuid == null) && (aboutus.ID == 0))
            {
                aboutus.Status = 0;
                aboutus.Guid = Guid.NewGuid().ToString();
                aboutus.LangGuid = Guid.NewGuid().ToString();
                this._aboutusBllBLL.Add(aboutus);
            }
            if ((aboutus.LangGuid != null) && (aboutus.ID != 0))
            {
                this._aboutusBllBLL.Update(aboutus);
            }
            if (((aboutus2.LangGuid == null) && (aboutus2.ID == 0)) && (aboutus2.Content != aboutus.Content))
            {
                aboutus2.Status = 0;
                aboutus2.Guid = Guid.NewGuid().ToString();
                aboutus2.LangGuid = aboutus.LangGuid;
                this._aboutusBllBLL.Add(aboutus2);
            }
            else if ((aboutus2.LangGuid != null) && (aboutus2.ID != 0))
            {
                aboutus2.LangGuid = aboutus.LangGuid;
                this._aboutusBllBLL.Update(aboutus2);
            }
            return base.RedirectToAction("List");
        }

        public ActionResult Edit(string languid)
        {
            IList<Aboutus> top = this._aboutusBllBLL.GetTop(2, string.Format(" LangGuid='{0}' ", languid));
            AboutUsModel model = new AboutUsModel();
            Aboutus aboutus = top.FirstOrDefault<Aboutus>(d => d.LanguageCode == LanageConfig.EnLan);
            Aboutus aboutus2 = top.FirstOrDefault<Aboutus>(d => d.LanguageCode == LanageConfig.ZhLan);
            if (aboutus != null)
            {
                model.EnTitle = aboutus.LinkTitle;
                model.EnContent = aboutus.Content;
                model.EnId = aboutus.ID;
                int? sortOrder = aboutus.SortOrder;
                model.EnSortOrder = sortOrder.HasValue ? sortOrder.GetValueOrDefault() : 0;
            }
            if (aboutus2 != null)
            {
                model.ZhTitle = aboutus2.LinkTitle;
                model.ZhContent = aboutus2.Content;
                model.ZhId = aboutus2.ID;
                int? nullable2 = aboutus2.SortOrder;
                model.ZhSortOrder = nullable2.HasValue ? nullable2.GetValueOrDefault() : 0;
            }
            return base.View(model);
        }

        public ActionResult List()
        {
            return base.View(this._aboutusBllBLL.GetAllList() ?? new List<Aboutus>());
        }
    }
}
