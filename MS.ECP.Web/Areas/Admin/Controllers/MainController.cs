using MS.ECP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MS.ECP.Web.Filters;

namespace MS.ECP.Web.Areas.Admin.Controllers
{
    [LoginAuthenticity]
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
