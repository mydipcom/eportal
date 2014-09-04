using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.ECP.Common
{
    public class General
    {
        public static string[] Regions =
        {
            "/zh-tw", "/zh-cn", "/en-us", "/de-de", "/fr-fr", "/ja-jp", "/ko-kr", "/es-es"
        };

        public static string GetRegion(string url)
        {
            foreach (var region in Regions.Where(region => url.IndexOf(region, System.StringComparison.Ordinal) > -1))
            {
                return region;
            }
            return "/en-us";
        }


        //过滤其他请求
        public static bool FiltrationUrl(string url)
        {
            return !url.Contains(".") || url.Contains(".html");

        }
    }
}
