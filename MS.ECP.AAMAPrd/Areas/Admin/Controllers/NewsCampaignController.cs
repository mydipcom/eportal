using System;
using System.Linq;
using System.Web.Mvc;
using MS.ECP.AAMAPrd.Areas.Admin.Models;
using MS.ECP.AAMAPrd.Areas.Admin.WebHelp;
using MS.ECP.AAMAPrd.WebPager;
using MS.ECP.Model.CMS;


namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    public class NewsCampaignController : Controller
    {
        private readonly BLL.CMS.News _newsBLL = new BLL.CMS.News();
        private const int Pagesize = 10;
        private const int LanguageSelect = 2;

        public ActionResult List(int id = 1)
        {
            var dt = _newsBLL.GetListByPage("", id == 1 ? 0 : (id - 1) * Pagesize + 1, id * Pagesize);
            var listcount = _newsBLL.GetRecordCount("");
            var viewmodel = new PagedList<News>(dt, id, Pagesize, listcount);
            if (Request.IsAjaxRequest())
                return PartialView("_NewsPagingPartialPage", viewmodel); 
            return View(viewmodel);
        }


        public ActionResult Add(string languid)
        {
            var modle = new NewsInputViewModel()
            {
                LangGuid = languid
            };
            return View(modle);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(NewsInputViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var enlishnews = new NewsInput
            {
                LangGuid = model.LangGuid,
                InputName = Guid.NewGuid().ToString(),
                IsAllowNull = model.IsAllowNull,
                InputType = model.InputType,
                Inputtitle = model.Inputtitle,
                InputValue = model.InputValue
            };

            _newsBLL.Add(enlishnews);
            return RedirectToAction("List");
        }



        public ActionResult Edit(int id)
        {
            var inpumodel = _newsBLL.GetNewsInputByID(id);
            var modle = new NewsInputViewModel()
            {
                Id=id,
                LangGuid = inpumodel.LangGuid,
                Inputtitle = inpumodel.Inputtitle,
                InputValue = inpumodel.InputValue,
                InputType = inpumodel.InputType,
                IsAllowNull = inpumodel.IsAllowNull,
            };
            return View(modle);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsInputViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var enlishnews = new NewsInput
            {
                ID = model.Id,
                IsAllowNull = model.IsAllowNull,
                InputType = model.InputType,
                Inputtitle = model.Inputtitle,
                InputValue = model.InputValue,
            };
            _newsBLL.Update(enlishnews);
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


            _newsBLL.Deleteintput(id);
            return RedirectToAction("List");

        }



    }
}
