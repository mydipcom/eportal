using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MS.ECP.Web.Models;
using MS.ECP.Utility;
using MS.ECP.Common;
using MS.ECP.Model;
using System.Web.UI.WebControls;

namespace MS.ECP.Web.Controllers
{
    public class AccountController : Controller
    {

        private BLL.UserInfo userinfoBLL = new BLL.UserInfo();


        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (userinfoBLL.ValidateUserName(model.UserName, model.Password) && userinfoBLL.ValidatePassword(model.UserName, model.Password))
                {
                
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "提供的用户名或密码不正确。");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View(registerModel);

            /*           ResourcesHelper reHelper = new ResourcesHelper("Default");
            MS.ECP.Utility.ResourcesHelper reRegHelper = new MS.ECP.Utility.ResourcesHelper("Register");
            if (!string.IsNullOrWhiteSpace(Email) && Email != reHelper.GetString("tip_Email"))
            {
                ViewBag.strEmail = Email;
                ViewBag.strReEmail = Email;
            }
            else
            {
                ViewBag.strEmail = reRegHelper.GetString("tip_EmailAddress");
                ViewBag.strReEmail = reRegHelper.GetString("tip_ReEmailAddress");
            }          
            */
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register2()
        {

            Common.PageValidate val = new PageValidate();//格式验证
            ResourcesHelper reHelper = new ResourcesHelper("Register");
            #region 验证

            string pwd = Request.Form["Password"].ToString();
            string repwd = Request.Form["RePassword"].ToString();
            if (!string.IsNullOrEmpty(pwd) && !string.IsNullOrEmpty(repwd))//验证密码
            {
                if (!pwd.Equals(repwd))
                {
                    return Json(new { result = "0", errMsg = "密码不一致" });
                }
            }
            else
            {
                return Json(new { result = "0", errMsg = "请输入密码" });
            }

            string username = Request.Form["UserName"].ToString().Trim();//验证邮箱
            string email = Request.Form["Email"].ToString().Trim();//验证邮箱

            if (!string.IsNullOrEmpty(username))// username都不为空时
            {
                //判断用户唯一
                bool exist = userinfoBLL.ExistUserName(username);
                if (exist)
                {
                    return Json(new { result = "0", errMsg = "UserName 不唯一" });
                }
            }
            else
            {
                return Json(new { result = "0", errMsg = "UserName 不能为空" });
            }

            if (!string.IsNullOrEmpty(email))// email都不为空时
            {

                if (PageValidate.IsEmail2(email) == false)//验证没通过
                {
                    return Json(new { result = "0", errMsg = "Email格式不正确" });
                }
                else
                {
                    //判断邮箱唯一
                    bool exist = userinfoBLL.ExistEmail(email);
                    if (exist)
                    {
                        return Json(new { result = "0", errMsg = "Email 不唯一" });
                    }
                }
            }
            else
            {
                return Json(new { result = "0", errMsg = "email 不能为空" });
            }

            #endregion

            try
            {
                Model.UserInfo userInfo = new Model.UserInfo();
                string guid = Guid.NewGuid().ToString();
                userInfo.Guid = guid;
                userInfo.UserName = Request.Form["UserName"].Trim();

                userInfo.CreateTime = DateTime.Now;

                userInfo.UpdateTime = DateTime.Now;


                userInfo.Email = Request.Form["Email"];

                string enpwd = Request.Form["Password"].Trim();
                userInfo.Password = Utility.DESEncrypt.Encrypt(enpwd);
                userInfo.UserType = 1;

                string[] array = new string[] { "," };
                bool userResult = userinfoBLL.Add(userInfo);

                if (userResult)
                {
                    //注册成功后发送邮件 激活
                    MailModel modMail = new MailModel();
                    modMail.ToAddress = userInfo.Email;
                    modMail.UserCode = guid;
                    modMail.MailName = "activemail";

                    modMail.IsActionCode = true;
                    List<ListItem> listitem = new List<ListItem>();

                    ListItem lt2 = new ListItem();
                    lt2.Value = "{$data_Code$}";
                    listitem.Add(lt2);
                    FrontUtility.SendMail(modMail, listitem, "激活邮件");
                }
                else
                {
                    return Json(new { result = "0", errMsg = "用户注册失败" });
                }

                return Json(new { result = "1", errMsg = "用户注册成功", find = Url.Action("index", "home") });

            }
            catch (Exception ee)
            {
                return Json(new { result = "0", errMsg = "用户注册失败" });
            }
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // 在某些出错情况下，ChangePassword 将引发异常，
                // 而不是返回 false。
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "当前密码不正确或新密码无效。");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // 请参见 http://go.microsoft.com/fwlink/?LinkID=177550 以查看
            // 状态代码的完整列表。
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "用户名已存在。请输入不同的用户名。";

                case MembershipCreateStatus.DuplicateEmail:
                    return "该电子邮件地址的用户名已存在。请输入不同的电子邮件地址。";

                case MembershipCreateStatus.InvalidPassword:
                    return "提供的密码无效。请输入有效的密码值。";

                case MembershipCreateStatus.InvalidEmail:
                    return "提供的电子邮件地址无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidAnswer:
                    return "提供的密码取回答案无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidQuestion:
                    return "提供的密码取回问题无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidUserName:
                    return "提供的用户名无效。请检查该值并重试。";

                case MembershipCreateStatus.ProviderError:
                    return "身份验证提供程序返回了错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                case MembershipCreateStatus.UserRejected:
                    return "已取消用户创建请求。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                default:
                    return "发生未知错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";
            }
        }
        #endregion
    }
}
