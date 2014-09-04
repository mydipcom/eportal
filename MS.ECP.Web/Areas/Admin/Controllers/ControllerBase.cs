using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Web.Areas.Admin.Models;

namespace MS.ECP.Web.Areas.Admin.Controllers
{
    public class ControllerBase : Controller
    {
        protected void DurationUser(LoginModel user)
        {
            Session["admin"] = user;
        }

        protected LoginModel GetAdminUser()
        {
            return Session["admin"] as LoginModel;
        }
         
        protected void ClearAdminUser()
        {
            Session["admin"] = null;
        }
    }
}