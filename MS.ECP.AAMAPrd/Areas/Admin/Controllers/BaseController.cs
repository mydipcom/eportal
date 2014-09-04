using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public string ControllerName
        {
            get
            {
                return Request.RequestContext.RouteData.Values["Controller"].ToString();
            }
        }

        public string ActionName
        {
            get
            {
                return Request.RequestContext.RouteData.Values["Action"].ToString();
            }
        }

        public int cid
        {
            get
            {
                return Convert.ToInt32(Request.RequestContext.RouteData.Values["cid"].ToString());
            }
        }


    }
}
