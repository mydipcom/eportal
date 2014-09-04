using System.Web.Mvc;
using MS.ECP.AAMAPrd.Areas.Admin.Models;
using MS.ECP.AAMAPrd.WebPager;
using MS.ECP.BLL;

namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    public class ResourceController : Controller
    {
        //
        // GET: /Admin/SysResource/

        private readonly SysResource _resourceBLL = new SysResource();
        private const int Pagesize = 10;

        public ActionResult List(int id = 1)
        {
            var dt = _resourceBLL.GetListByPage("", id == 1 ? 0 : (id - 1)*Pagesize + 1, id*Pagesize);
            var listcount = _resourceBLL.GetRecordCount("");
            var viewmodel = new PagedList<MS.ECP.Model.SysResource>(dt, id, Pagesize, listcount);
            if (Request.IsAjaxRequest())
                return PartialView("_ResourcePartialPage", viewmodel);
            return View(viewmodel);
        }

        public ActionResult Edit(int id)
        {
            var resulr = _resourceBLL.GetModelByID(id);
            var viewmodel = new ResourceViewModel()
            {
                Id = id,
                LanguageCode = resulr.LanguageCode,
                ResourceKey = resulr.ResourceKey,
                ResourceValue = resulr.ResourceValue
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ResourceViewModel model)
        {
            var resulr = _resourceBLL.GetModelByID(model.Id);
            resulr.ResourceValue = model.ResourceValue;
            _resourceBLL.Update(resulr);
            return RedirectToAction("List");
        }


    }
}
