using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Web.WebHelp;

namespace MS.ECP.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.Keywords = LanageCommon.CommonSeoKeywords;
            ViewBag.Description = LanageCommon.CommonSeoDescription;
            ViewBag.Title = LanageCommon.CommonSeoTitle;
        }
    }
}
