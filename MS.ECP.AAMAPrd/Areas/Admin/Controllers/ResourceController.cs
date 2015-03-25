namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    using MS.ECP.AAMAPrd.Areas.Admin.Models;
    using MS.ECP.AAMAPrd.WebPager;
    using MS.ECP.BLL;
    using MS.ECP.Model;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Web.Mvc;

    public class ResourceController : Controller
    {
        private readonly MS.ECP.BLL.SysResource _resourceBLL = new MS.ECP.BLL.SysResource();
        private const int Pagesize = 10;

        [HttpPost]
        public ActionResult Edit(ResourceViewModel model)
        {
            MS.ECP.Model.SysResource modelByID = this._resourceBLL.GetModelByID(model.Id);
            modelByID.ResourceValue = model.ResourceValue;
            this._resourceBLL.Update(modelByID);
            return base.RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            MS.ECP.Model.SysResource modelByID = this._resourceBLL.GetModelByID(id);
            ResourceViewModel model = new ResourceViewModel
            {
                Id = id,
                LanguageCode = modelByID.LanguageCode,
                ResourceKey = modelByID.ResourceKey,
                ResourceValue = modelByID.ResourceValue
            };
            return base.View(model);
        }

        public ActionResult List(int id = 1)
        {
            IList<MS.ECP.Model.SysResource> currentPageItems = this._resourceBLL.GetListByPage("", (id == 1) ? 0 : (((id - 1) * 10) + 1), id * 10);
            int recordCount = this._resourceBLL.GetRecordCount("");
            PagedList<MS.ECP.Model.SysResource> model = new PagedList<MS.ECP.Model.SysResource>(currentPageItems, id, 10, recordCount);
            if (base.Request.IsAjaxRequest())
            {
                return this.PartialView("_ResourcePartialPage", model);
            }
            return base.View(model);
        }
    }
}
