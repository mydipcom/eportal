using System.Collections;

namespace MS.ECP.Web.Areas.Admin.WebHelp
{
    public class LanageConfig
    {
        static LanageConfig()
        {
            LanHash = new Hashtable {{EnLan, "中文"}, {ZhLan, "English"}};
        }

        public static Hashtable LanHash { get; set; }

        public static string EnLan
        {
            get { return "en-us"; }
        }

        public static string ZhLan  
        {
            get { return "zh-cn"; }
        }

    }


    public static class AdminConfig
    {
        public static string SearKeyWord
        {
            get { return "Title"; }
        }

        public static string ResourceSearKeyWord  
        {
            get { return "Resource Content"; } 
        }

        public static string ResourcePage  
        {
            get { return "Resource Page"; }
        }
    }




}