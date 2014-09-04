using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MS.ECP.Web.Areas.Admin.Models;

namespace MS.ECP.Web.Areas.Admin.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly BLL.UserInfo _accountBLL = new BLL.UserInfo();

        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);
            if (_accountBLL.ValidateUserName(model.UserName, model.Password) &&
                _accountBLL.ValidatePassword(model.UserName, model.Password))
            {
                DurationUser(model);
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Main");
            }
            ModelState.AddModelError("", "提供的用户名或密码不正确。");
            return View();
        }


        public ActionResult LogOut()
        {
            ClearAdminUser();
            FormsAuthentication.SignOut();
            return RedirectToAction("LogOn", "Account");
        }
    }
}
