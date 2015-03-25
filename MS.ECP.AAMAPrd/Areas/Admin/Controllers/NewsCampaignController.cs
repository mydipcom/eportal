namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    using MS.ECP.AAMAPrd.Areas.Admin.Models;
    using MS.ECP.AAMAPrd.WebPager;
    using MS.ECP.BLL.CMS;
    using MS.ECP.Model.CMS;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Web.Mvc;

    public class NewsCampaignController : Controller
    {
        private readonly MS.ECP.BLL.CMS.News _newsBLL = new MS.ECP.BLL.CMS.News();
        private const int LanguageSelect = 2;
        private const int Pagesize = 10;

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(NewsInputViewModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            NewsInput input = new NewsInput
            {
                LangGuid = model.LangGuid,
                InputName = Guid.NewGuid().ToString(),
                IsAllowNull = model.IsAllowNull,
                InputType = model.InputType,
                Inputtitle = model.Inputtitle,
                InputValue = model.InputValue
            };
            this._newsBLL.Add(input);
            return base.RedirectToAction("List");
        }

        public ActionResult Add(string languid)
        {
            NewsInputViewModel model = new NewsInputViewModel
            {
                LangGuid = languid
            };
            return base.View(model);
        }

        public ActionResult Del(int id = 0)
        {
            if ((id != 0) && (id >= 0))
            {
                this._newsBLL.Deleteintput(id);
            }
            return base.RedirectToAction("List");
        }

        [ValidateInput(false), HttpPost]
        public ActionResult Edit(NewsInputViewModel model)
        {
            if (!base.ModelState.IsValid)
            {
                return base.View(model);
            }
            NewsInput input = new NewsInput
            {
                ID = model.Id,
                IsAllowNull = model.IsAllowNull,
                InputType = model.InputType,
                Inputtitle = model.Inputtitle,
                InputValue = model.InputValue
            };
            this._newsBLL.Update(input);
            return base.RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            NewsInput newsInputByID = this._newsBLL.GetNewsInputByID(id);
            NewsInputViewModel model = new NewsInputViewModel
            {
                Id = id,
                LangGuid = newsInputByID.LangGuid,
                Inputtitle = newsInputByID.Inputtitle,
                InputValue = newsInputByID.InputValue,
                InputType = newsInputByID.InputType,
                IsAllowNull = newsInputByID.IsAllowNull
            };
            return base.View(model);
        }

        public ActionResult List(int id = 1)
        {
            IList<MS.ECP.Model.CMS.News> currentPageItems = this._newsBLL.GetListByPage("", (id == 1) ? 0 : (((id - 1) * 10) + 1), id * 10);
            int recordCount = this._newsBLL.GetRecordCount("");
            PagedList<MS.ECP.Model.CMS.News> model = new PagedList<MS.ECP.Model.CMS.News>(currentPageItems, id, 10, recordCount);
            if (base.Request.IsAjaxRequest())
            {
                return this.PartialView("_NewsPagingPartialPage", model);
            }
            return base.View(model);
        }
    }
}
