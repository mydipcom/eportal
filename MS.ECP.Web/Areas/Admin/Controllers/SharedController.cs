using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Utility;
using MS.ECP.Web.Areas.Admin.Models;
using MS.ECP.Web.Filters;
using MS.ECP.Web.Models;

namespace MS.ECP.Web.Areas.Admin.Controllers
{

    public class SharedController : ControllerBase
    {

        public ActionResult Sidebar()
        {
            return View();
        }

        [LoginAuthenticity]
        public ActionResult Navbar()
        {
            ViewBag.UserName = GetAdminUser().UserName;
            return View();
        }

        [LoginAuthenticity]
        public ActionResult Content()
        {
            return View();
        }

        [LoginAuthenticity]
        public ActionResult ClearCache()
        {
            ResourcesHelper.ClearCache("SysResource");
            return Json(new JqueryResult()
            {
                Result = true
            });
        }


        public ActionResult Error()
        {
            return View();
        }


    }
}
