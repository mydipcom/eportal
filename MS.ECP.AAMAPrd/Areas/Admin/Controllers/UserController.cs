namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    using MS.ECP.BLL;
    using MS.ECP.Model;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Web.Mvc;

    public class UserController : BaseController
    {
        private MS.ECP.BLL.UserInfo userBLL = new MS.ECP.BLL.UserInfo();

        public ActionResult Add()
        {
            Status[] statusArray2 = new Status[2];
            Status status = new Status
            {
                Name = "无效的",
                Value = 0
            };
            statusArray2[0] = status;
            Status status2 = new Status
            {
                Name = "有效的",
                Value = 1
            };
            statusArray2[1] = status2;
            Status[] items = statusArray2;
            ((dynamic)base.ViewBag).AllStatus = new SelectList(items, "Value", "Name");
            Type[] typeArray2 = new Type[5];
            Type type = new Type
            {
                Name = "管理员",
                Value = 0
            };
            typeArray2[0] = type;
            Type type2 = new Type
            {
                Name = "普通用户",
                Value = 1
            };
            typeArray2[1] = type2;
            Type type3 = new Type
            {
                Name = "开发者",
                Value = 2
            };
            typeArray2[2] = type3;
            Type type4 = new Type
            {
                Name = "合作伙伴",
                Value = 3
            };
            typeArray2[3] = type4;
            Type type5 = new Type
            {
                Name = "服务客户",
                Value = 4
            };
            typeArray2[4] = type5;
            Type[] typeArray = typeArray2;
            ((dynamic)base.ViewBag).AllType = new SelectList(typeArray, "Value", "Name");
            return base.View();
        }

        public ActionResult Del(int id = 0)
        {
            if (((id != 0) && (id >= 0)) && this.userBLL.Exists(id))
            {
                this.userBLL.Delete(id);
            }
            return base.RedirectToAction("List");
        }

        public ActionResult Edit(int id = 0)
        {
            Status[] statusArray2 = new Status[2];
            Status status = new Status
            {
                Name = "无效的",
                Value = 0
            };
            statusArray2[0] = status;
            Status status2 = new Status
            {
                Name = "有效的",
                Value = 1
            };
            statusArray2[1] = status2;
            Status[] items = statusArray2;
            ((dynamic)base.ViewBag).AllStatus = new SelectList(items, "Value", "Name");
            Type[] typeArray2 = new Type[5];
            Type type = new Type
            {
                Name = "管理员",
                Value = 0
            };
            typeArray2[0] = type;
            Type type2 = new Type
            {
                Name = "普通用户",
                Value = 1
            };
            typeArray2[1] = type2;
            Type type3 = new Type
            {
                Name = "开发者",
                Value = 2
            };
            typeArray2[2] = type3;
            Type type4 = new Type
            {
                Name = "合作伙伴",
                Value = 3
            };
            typeArray2[3] = type4;
            Type type5 = new Type
            {
                Name = "服务客户",
                Value = 4
            };
            typeArray2[4] = type5;
            Type[] typeArray = typeArray2;
            ((dynamic)base.ViewBag).AllType = new SelectList(typeArray, "Value", "Name");
            MS.ECP.Model.UserInfo model = null;
            if (id > 0)
            {
                model = this.userBLL.GetModel(id);
            }
            return base.View(model);
        }

        public ActionResult List()
        {
            return base.View();
        }

        [ValidateInput(false), HttpPost]
        public ActionResult Save(MS.ECP.Model.UserInfo user, FormCollection formCollection)
        {
            bool flag;
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Email))
            {
                return base.RedirectToAction("Add");
            }
            if (user.ID > 0)
            {
                flag = this.userBLL.Update(user);
            }
            else
            {
                flag = this.userBLL.Add(user);
            }
            if (flag)
            {
                return base.RedirectToAction("List");
            }
            return base.RedirectToAction("List");
        }

        public class Status
        {
            public string Name { get; set; }

            public int Value { get; set; }
        }

        public class Type
        {
            public string Name { get; set; }

            public int Value { get; set; }
        }
    }
}
