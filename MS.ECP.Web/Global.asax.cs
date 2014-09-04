using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MS.ECP.Common;
using MS.ECP.Utility;

namespace MS.ECP.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        #region private var

        private static Timer _crashdelege;

        #endregion

        #region Application Method

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "HtmlStatic", // Route name
                "{lanage}/{controller}_{action}_{version}.html", // URL with parameters
                null
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //页面语言判断，管理页面根据session判断，普通页面则根据url指定显示语言

            //过滤其他请求
            if(!General.FiltrationUrl(Request.Url.Segments.LastOrDefault())) return; 

            var lang = General.GetRegion(Request.Url.AbsoluteUri);
            var ci = new CultureInfo(lang.Trim('/')); 
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // 默认情况下对 Entity Framework 使用 LocalDB
            Database.DefaultConnectionFactory =
                new SqlConnectionFactory(
                    @"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RouteTable.Routes.RouteExistingFiles = false;


            //毫秒
           // _crashdelege = new Timer(DeleteDirctory, this, 0, 10000);
        }

        protected void Application_End()
        {
            if (null != _crashdelege)
            {
                _crashdelege.Dispose();
                _crashdelege = null;
            }
        }

        #endregion

        #region private method

        private static void DeleteDirctory(Object obj)
        {
            try
            {
                var dier = AppDomain.CurrentDomain.BaseDirectory;
                var chinadir = dier + "en-us";
                var endir = dier + "zh-cn";
                if (Directory.Exists(chinadir))
                    Directory.Delete(chinadir, true);

                if (Directory.Exists(endir))
                    Directory.Delete(endir, true);
            }
            catch (Exception)
            {

            }
        }

        #endregion

    }
}