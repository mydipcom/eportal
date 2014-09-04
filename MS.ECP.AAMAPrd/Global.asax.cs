using MS.ECP.Bll.EntityContext;
using MS.ECP.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MS.ECP.AAMAPrd
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "MemberProgram", // 路由名称
                "membership", // 带有参数的 URL
                new {controller = "Home", action = "MemberProgram", id = UrlParameter.Optional} // 参数默认值
                );

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //页面语言判断，管理页面根据session判断，普通页面则根据url指定显示语言
            string lang = General.GetRegion(Request.Url.AbsoluteUri);
            CultureInfo ci = new CultureInfo(lang.Trim('/'));

            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Database.SetInitializer<AAMAPrdContext>(null);
       

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RouteTable.Routes.RouteExistingFiles = false;
        }



        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();

        //    // 默认情况下对 Entity Framework 使用 LocalDB


        //    RegisterGlobalFilters(GlobalFilters.Filters);
        //    RegisterRoutes(RouteTable.Routes);
        //    RouteTable.Routes.RouteExistingFiles = false;
        //}

        //public static void RegisterRoutes(RouteCollection routes)
        //{

        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        "Publish", // 路由名称
        //        "PublishSetp/{type}/{id}", // 带有参数的 URL
        //        new { controller = "Product", action = "AjaxPublish" }
        //    );

        //    routes.MapRoute(
        //        "Default", // 路由名称
        //        "{controller}/{action}/{id}", // 带有参数的 URL
        //        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
        //    );

        //    routes.MapRoute(
        //       "Admin", // Route name
        //       "{controller}/{action}/{id}", // URL with parameters
        //       new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
        //       new string[] { "MS.ECP.Admin.Controllers" }
        //   );
        //}


        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //    //页面语言判断，管理页面根据session判断，普通页面则根据url指定显示语言
        //    string lang = General.GetRegion(Request.Url.AbsoluteUri);
        //    CultureInfo ci = new CultureInfo(lang.Trim('/'));

        //    Thread.CurrentThread.CurrentUICulture = ci;
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        //}

        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new HandleErrorAttribute());
        //}


    }
}
