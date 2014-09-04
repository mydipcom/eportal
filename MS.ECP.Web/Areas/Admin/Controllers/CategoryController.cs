using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Data;

using MS.ECP.Model;
using MS.ECP.BLL;
using MS.ECP.Model.CMS;
using MS.ECP.Web.Areas.Admin.Models;
using MS.ECP.Web.Areas.Admin.WebHelp;
using MS.ECP.Web.Filters;
using MS.ECP.Web.Models;
using MS.ECP.Web.WebHelp;


namespace MS.ECP.Web.Areas.Admin.Controllers
{
    [LoginAuthenticity]
    public class CategoryController : Controller
    {

        private readonly BLL.CMS.Category _categoryBLL = new BLL.CMS.Category();


        public ActionResult List()
        {
            var parentlist = _categoryBLL.GetList(" ParentGuid='0' ");
            var viewmodles = new List<CategoryListViewModel>();
            var enumerable = parentlist.GroupBy(m => m.Guid);
            var variables = enumerable as IList<IGrouping<string, Category>> ?? enumerable.ToList();
            for (var i = 0; i < variables.Count(); i++)
            {
                var model = new CategoryListViewModel() {Id = i + 1, LanGuid = variables[i].Key};
                foreach (var lanitem in parentlist.Where(m => m.Guid == variables[i].Key))
                {
                    if (lanitem.LanguageCode == LanageConfig.EnLan)
                    {
                        model.EnParentCategory = lanitem;
                        model.EnChildCategories = _categoryBLL.GetList(String.Format(" ParentGuid='{0}' ", lanitem.ID));
                    }
                    else if (lanitem.LanguageCode == LanageConfig.ZhLan)
                    {
                        model.ZhParentCategory = lanitem;
                        model.ZhChildCategories = _categoryBLL.GetList(String.Format(" ParentGuid='{0}' ", lanitem.ID));
                    }
                }
                viewmodles.Add(model);
            }
            return View(viewmodles);
        }


        public ActionResult Add(string lanid)
        {
            var viewmodles = new CategoryaeModel() {CategoryLanGuid = lanid};
            viewmodles.SetCategoryItems(OptoinItemBuilder());
            return View(viewmodles);
        }


        [HttpPost]
        public ActionResult Add(CategoryaeModel model)
        {
            model.SetCategoryItems(OptoinItemBuilder());
            if (!ModelState.IsValid)
                return View(model);
            var languguid = Guid.NewGuid().ToString();
            var enmodel = _categoryBLL.GetModelByLangGuidAndLangCode(model.CategoryLanGuid, LanageConfig.EnLan);
            var cnmodel = _categoryBLL.GetModelByLangGuidAndLangCode(model.CategoryLanGuid, LanageConfig.ZhLan);
            var enlishCategory = new Category
            {
                CategoryName = model.EnCategoryName,
                ParentGuid = null == enmodel ? "0" : enmodel.ID.ToString(CultureInfo.InvariantCulture),
                LanguageCode = LanageConfig.EnLan,
                Guid = languguid
            };
            var chineseCategory = new Category
            {
                CategoryName = model.CnCategoryName ?? model.EnCategoryName,
                ParentGuid = null == cnmodel ? "0" : cnmodel.ID.ToString(CultureInfo.InvariantCulture),
                LanguageCode = LanageConfig.ZhLan,
                Guid = languguid
            };
            _categoryBLL.Add(enlishCategory);
            _categoryBLL.Add(chineseCategory);


            return RedirectToAction("List");
        }


        public ActionResult Edit(string lanid)
        {
            ViewBag.Lanid = lanid;
            var enmodel = _categoryBLL.GetModelByLangGuidAndLangCode(lanid, LanageConfig.EnLan);
            var cnmodel = _categoryBLL.GetModelByLangGuidAndLangCode(lanid, LanageConfig.ZhLan);
            var enlist = _categoryBLL.GetList(String.Format(" ParentGuid='{0}' ", enmodel.ID));
            var cnlist = _categoryBLL.GetList(String.Format(" ParentGuid='{0}' ", cnmodel.ID));
            var viewmodle = new CategorEditModel
            {
                EnId = enmodel.ID,
                EnCategoryname = enmodel.CategoryName,
                CnCategoryname = cnmodel.CategoryName,
                CnId = cnmodel.ID
            };
            foreach (var category in enlist)
            {
                var caeit = new CategorEditItem {EnText = category.CategoryName, EnId = category.ID};
                var zhmoff = cnlist.FirstOrDefault(m => m.Guid == category.Guid);
                caeit.CnText = null == zhmoff ? "" : zhmoff.CategoryName;
                caeit.CnId = null == zhmoff ? 0 : zhmoff.ID;
                viewmodle.CategoryItems.Add(caeit);
            }

            return View(viewmodle);
        }


        [HttpPost]
        public ActionResult Edit(CategorEditModel model, FormCollection form)
        {
            if (!ModelState.IsValid)
                return View(model);
            var keypair = LanKVPairBuilder(form);
            if (keypair.Count(d => d.LanCode == LanageConfig.EnLan && String.IsNullOrWhiteSpace(d.Value)) != 0)
            {
                ModelState.AddModelError("", "The (EN) field is required.");
                return View(model);
            }

            //中文标题
            var languid = Guid.NewGuid().ToString();
            var catitle = _categoryBLL.GetModelByID(model.EnId);
            catitle.Guid = languid;
            catitle.CategoryName = model.EnCategoryname;
            _categoryBLL.AddOrUpdate(catitle);

            //英文标题
            var cncatitle = _categoryBLL.GetModelByID(model.CnId) ??
                            new Category {ParentGuid = "0", LanguageCode = LanageConfig.ZhLan};
            cncatitle.Guid = languid;
            cncatitle.CategoryName = model.CnCategoryname;
            _categoryBLL.AddOrUpdate(cncatitle);


            //子标题
            foreach (var lanKVPair in keypair.GroupBy(k => k.InputId))
            {
                var cldlanguid = Guid.NewGuid().ToString();
                //en
                var en = keypair.FirstOrDefault(m => m.InputId == lanKVPair.Key && m.LanCode == LanageConfig.EnLan);
                var entitle = _categoryBLL.GetModelByID(en.Id) ??
                              new Category
                              {
                                  ParentGuid = catitle.ID.ToString(CultureInfo.InvariantCulture),
                                  LanguageCode = LanageConfig.EnLan
                              };
                entitle.Guid = cldlanguid;
                entitle.CategoryName = en.Value;
                _categoryBLL.AddOrUpdate(entitle);
                //cn
                var cn = keypair.FirstOrDefault(m => m.InputId == lanKVPair.Key && m.LanCode == LanageConfig.ZhLan);
                var cntitle = _categoryBLL.GetModelByID(cn.Id) ??
                              new Category
                              {
                                  ParentGuid = cncatitle.ID.ToString(CultureInfo.InvariantCulture),
                                  LanguageCode = LanageConfig.ZhLan
                              };
                cntitle.Guid = cldlanguid;
                cntitle.CategoryName = String.IsNullOrEmpty(cn.Value) ? en.Value : cn.Value;
                _categoryBLL.AddOrUpdate(cntitle);
            }

            return RedirectToAction("List");
        }


        public ActionResult Del(int id)
        {
            if (0 != id)
                _categoryBLL.Delete(id);
            return RedirectToAction("List");
        }

        public ActionResult DelByLan(string id) 
        { 
            if (!String.IsNullOrEmpty(id))
                _categoryBLL.DeleteByLangGuid(id);
            return RedirectToAction("List");
        } 

        public ActionResult GetChildCategory(int id)
        {
            return Json(_categoryBLL.GetList(String.Format(" ParentGuid='{0}' ", id)),JsonRequestBehavior.AllowGet);
        }

        #region private method

        private IList<OptoinItem> OptoinItemBuilder()
        {
            var parentlist = _categoryBLL.GetList(" ParentGuid='0' ");
            var enumerable = parentlist.GroupBy(m => m.Guid);
            var variables = enumerable as IList<IGrouping<string, Category>> ?? enumerable.ToList();
            var drouplist = variables.Select(varia => new OptoinItem()
            {
                Value = varia.Key,
                Text =
                    String.Join("/",
                        parentlist.Where(m => m.Guid == varia.Key)
                            .OrderBy(m => m.LanguageCode)
                            .Select(m => m.CategoryName))
            }).ToList();
            return drouplist;
        }


        private IList<InputVal> LanKVPairBuilder(FormCollection form)
        {
            var regex = new Regex(String.Format(@"({0}|{1})_(.*?)_(\d+)", LanageConfig.ZhLan, LanageConfig.EnLan));
            var keys = new List<InputVal>();
            foreach (string key in form.Keys)
            {
                if (regex.IsMatch(key))
                {
                    var inputs = new InputVal();
                    foreach (Match match in regex.Matches(key))
                    {
                        inputs.LanCode = match.Groups[1].Value;
                        inputs.InputId = match.Groups[2].Value;
                        inputs.Id = String.IsNullOrWhiteSpace(match.Groups[3].Value)
                            ? 0
                            : int.Parse(match.Groups[3].Value);
                        inputs.Value = form[key];
                    }
                    keys.Add(inputs);
                }
            }
            return keys;
        }

        #endregion

    }
}
