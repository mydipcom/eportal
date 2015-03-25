namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    using System;
    using System.Web.Mvc;

    public class AdminAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            this.ReturnLogin(filterContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            this.ReturnLogin(filterContext);
        }

        private void ReturnLogin(AuthorizationContext filterContext)
        {
            if ((filterContext.HttpContext.Session["AdminUser"] == null) || string.IsNullOrWhiteSpace(filterContext.HttpContext.Session["AdminUser"].ToString()))
            {
                filterContext.HttpContext.Response.Redirect("/admin/default/exit");
            }
        }
    }
}
