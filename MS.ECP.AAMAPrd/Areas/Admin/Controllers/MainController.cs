using System.Web.Mvc;
using System.Web.Security;
using MS.ECP.Utility;

namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    public class MainController : BaseController
    {

        private BLL.UserInfo accountBLL = new BLL.UserInfo();
        //
        // GET: /Admin/Main/

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Admin/LogOn

        [HttpPost]
        public ActionResult LogOn(Model.AccountInfo model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (accountBLL.ValidateUserName(model.UserName, model.Password) && accountBLL.ValidatePassword(model.UserName, model.Password))
                {

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Main");
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
        // GET: /Admin/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogOn", "Main");
        }



        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                //return RedirectToAction("Login","User");
            }
            return View();
        }

        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult ClearCache()
        {
            ResourcesHelper.ClearCache("SysResource");

            return RedirectToAction("Dashboard");
        }

    }
}
