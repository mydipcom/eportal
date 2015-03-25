using MS.ECP.AAMAPrd.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace MS.ECP.AAMAPrd.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public ActionResult ChangePassword()
        {
            return base.View();
        }

        [Authorize, HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (base.ModelState.IsValid)
            {
                bool flag;
                try
                {
                    flag = Membership.GetUser(base.User.Identity.Name, true)
                        .ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    flag = false;
                }
                if (flag)
                {
                    return base.RedirectToAction("ChangePasswordSuccess");
                }
                base.ModelState.AddModelError("", "当前密码不正确或新密码无效。");
            }
            return base.View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {
            return base.View();
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            switch (createStatus)
            {
                case MembershipCreateStatus.InvalidUserName:
                    return "提供的用户名无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidPassword:
                    return "提供的密码无效。请输入有效的密码值。";

                case MembershipCreateStatus.InvalidQuestion:
                    return "提供的密码取回问题无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidAnswer:
                    return "提供的密码取回答案无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidEmail:
                    return "提供的电子邮件地址无效。请检查该值并重试。";

                case MembershipCreateStatus.DuplicateUserName:
                    return "用户名已存在。请输入不同的用户名。";

                case MembershipCreateStatus.DuplicateEmail:
                    return "该电子邮件地址的用户名已存在。请输入不同的电子邮件地址。";

                case MembershipCreateStatus.UserRejected:
                    return "已取消用户创建请求。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                case MembershipCreateStatus.ProviderError:
                    return "身份验证提供程序返回了错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";
            }
            return "发生未知错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return base.RedirectToAction("Index", "Home");
        }

        public ActionResult LogOn()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (base.ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (((base.Url.IsLocalUrl(returnUrl) && (returnUrl.Length > 1)) &&
                         (returnUrl.StartsWith("/") && !returnUrl.StartsWith("//"))) && !returnUrl.StartsWith(@"/\"))
                    {
                        return this.Redirect(returnUrl);
                    }
                    return base.RedirectToAction("Index", "Home");
                }
                base.ModelState.AddModelError("", "提供的用户名或密码不正确。");
            }
            return base.View(model);
        }

        public ActionResult Register()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (base.ModelState.IsValid)
            {
                MembershipCreateStatus status;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out status);
                if (status == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return base.RedirectToAction("Index", "Home");
                }
                base.ModelState.AddModelError("", ErrorCodeToString(status));
            }
            return base.View(model);
        }
    }
}