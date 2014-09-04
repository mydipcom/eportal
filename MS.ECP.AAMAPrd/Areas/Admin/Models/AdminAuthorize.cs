using System.Web.Mvc;

namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            ReturnLogin(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //base.HandleUnauthorizedRequest(filterContext);
            ReturnLogin(filterContext);
        }

        private void ReturnLogin(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["AdminUser"] == null || string.IsNullOrWhiteSpace(filterContext.HttpContext.Session["AdminUser"].ToString()))
            {
                filterContext.HttpContext.Response.Redirect("/admin/default/exit");
            }
        }
    }
}