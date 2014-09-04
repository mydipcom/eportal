using System.Web.Mvc;

namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        private BLL.UserInfo userBLL = new BLL.UserInfo();

        // GET: /Admin/User/

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            var statuslist = new[]{
                new Status{Name = "无效的",Value=0},
                new Status{Name = "有效的",Value=1}
            };
            ViewBag.AllStatus = new SelectList(statuslist, "Value", "Name");

            var typelist = new[]{
                new Type{Name = "管理员",Value=0},
                new Type{Name = "普通用户",Value=1},
                new Type{Name = "开发者",Value=2},
                new Type{Name = "合作伙伴",Value=3},
                new Type{Name = "服务客户",Value=4}
            };
            ViewBag.AllType = new SelectList(typelist, "Value", "Name");

            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            var statuslist = new[]{
                new Status{Name = "无效的",Value=0},
                new Status{Name = "有效的",Value=1}
            };
            ViewBag.AllStatus = new SelectList(statuslist, "Value", "Name");

            var typelist = new[]{
                new Type{Name = "管理员",Value=0},
                new Type{Name = "普通用户",Value=1},
                new Type{Name = "开发者",Value=2},
                new Type{Name = "合作伙伴",Value=3},
                new Type{Name = "服务客户",Value=4}
            };
            ViewBag.AllType = new SelectList(typelist, "Value", "Name");

            Model.UserInfo model = null;
            if (id > 0)
            {
                model = userBLL.GetModel(id);
            }

            return View(model);
        }


        #region Action
        /// <summary>
        /// Add/Edit User
        /// </summary>
        /// <param name="bews"></param>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Model.UserInfo user, FormCollection formCollection)
        {
            bool result;

            if ((string.IsNullOrEmpty(user.UserName)) || (string.IsNullOrEmpty(user.Email)))
            {
                return RedirectToAction("Add");
            }

            if (user.ID > 0)
            {
                result = userBLL.Update(user);
            }
            else
            {
                result = userBLL.Add(user);
            }

            if (result)
            {
                return RedirectToAction("List");
            }
            else
            {

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

            if (!userBLL.Exists(id))
            {
                return RedirectToAction("List");
            }

            userBLL.Delete(id);

            return RedirectToAction("List");

        }

        #endregion


        public class Type
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        public class Status
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}
