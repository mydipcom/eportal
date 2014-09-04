using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace  MS.ECP.AAMAPrd
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_login",
                "Admin/Login",
                new { controller = "Main", action = "Logon", id = UrlParameter.Optional }

            );

            context.MapRoute(
               "Admin",
               "Admin",
               new { controller = "Main", action = "Logon", id = UrlParameter.Optional }

           );

            context.MapRoute(
               "Admin_Menu",
               AreaName + "/{controller}/{action}/{cid}/{id}",
               new { Controller = "Main", action = "LogOn", mid = UrlParameter.Optional, cid = UrlParameter.Optional, id = UrlParameter.Optional },
               new string[] { "MS.ECP.AAMAPrd.Areas.Admin.Controllers" }
               );

            context.MapRoute(
                "Admin_default",
                AreaName + "/{controller}/{action}/{cid}",
                new { Controller = "Main", action = "LogOn", cid = UrlParameter.Optional },
                new string[] { "MS.ECP.AAMAPrd.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_Content",
                AreaName + "/{controller}/{action}/{id}",
                new { Controller = "Main", action = "LogOn", id = UrlParameter.Optional },
                new string[] { "MS.ECP.AAMAPrd.Areas.Admin.Controllers" }
                );
        }
    }
}
