using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MS.ECP.AAMAPrd
{
    public class RegionRegister_zh_cn : AreaRegistration
    {
        public override string AreaName
        {
            get { return "zh-cn"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "zh-cn_Default", // 路由名称
                "zh-cn/{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );
        }
    }
}