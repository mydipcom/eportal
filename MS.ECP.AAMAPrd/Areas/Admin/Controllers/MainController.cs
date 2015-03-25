namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    using MS.ECP.BLL;
    using MS.ECP.Model;
    using MS.ECP.Utility;
    using System;
    using System.Web.Mvc;
    using System.Web.Security;

    public class MainController : BaseController
    {
        private MS.ECP.BLL.UserInfo accountBLL = new MS.ECP.BLL.UserInfo();

        public ActionResult ClearCache()
        {
            ResourcesHelper.ClearCache("SysResource");
            return base.RedirectToAction("Dashboard");
        }

        public ActionResult DashBoard()
        {
            return base.View();
        }

        public ActionResult Index()
        {
            object obj1 = base.Session["UserName"];
            return base.View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return base.RedirectToAction("LogOn", "Main");
        }

        public ActionResult LogOn()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult LogOn(AccountInfo model, string returnUrl)
        {
            if (base.ModelState.IsValid)
            {
                if (this.accountBLL.ValidateUserName(model.UserName, model.Password) && this.accountBLL.ValidatePassword(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (((base.Url.IsLocalUrl(returnUrl) && (returnUrl.Length > 1)) && (returnUrl.StartsWith("/") && !returnUrl.StartsWith("//"))) && !returnUrl.StartsWith(@"/\"))
                    {
                        return this.Redirect(returnUrl);
                    }
                    return base.RedirectToAction("Index", "Main");
                }
                base.ModelState.AddModelError("", "提供的用户名或密码不正确。");
            }
            return base.View(model);
        }
    }
}
