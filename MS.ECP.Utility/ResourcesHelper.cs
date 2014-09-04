using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using MS.ECP.Common;
using MS.ECP;

namespace MS.ECP.Utility
{
    public class ResourcesHelper
    {
        private string pagename = "";

        public ResourcesHelper(string pageName = "Common")
        {
            pagename = pageName;
        }

        public static string GetLang()
        {
            CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture; 
            return ci.Name.ToLower();
        }

        private DataTable GetSysResource()
        {
            DataTable dtCode = new DataTable();
            string cacheKey = string.Format("resource-{0}", "SysResource");
            object objCache = DataCache.GetCache(cacheKey);
            if (objCache == null)
            {
                dtCode = new BLL.SysResource().GetListDataSet("").Tables[0];
                if (dtCode.Rows.Count > 0)
                {
                    DataCache.SetCache(cacheKey, dtCode);
                }
            }
            else
            {
                dtCode = (DataTable)objCache;
            }
            return dtCode;
        }

        public static bool ClearCache(string codeType)
        {
            try
            {
                string cacheKey = string.Format("resource-{0}", codeType);
                object objCache = DataCache.GetCache(cacheKey);
                if (objCache != null)
                {
                    HttpRuntime.Cache.Remove(cacheKey);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataRow[] GetPageCode()
        {
            DataTable dtCode = GetSysResource();
            DataRow[] drRows = dtCode.Select(string.Format(" LanguageCode='{0}' and ResourcePage='{1}' ", GetLang(), pagename), "");
            return drRows;
        }

        public DataRow[] GetPageCode(string webRegion)
        {
            DataTable dtCode = GetSysResource();
            DataRow[] drRows = dtCode.Select(string.Format(" LanguageCode='{0}' and ResourcePage='{1}' ", webRegion, pagename), "");
            return drRows;
        }

        public string GetString(string key)
        {
            string value = "None";
            try
            {
                DataTable dtCode = GetSysResource();
                DataRow[] drRows = dtCode.Select(string.Format(" LanguageCode='{0}' and ResourceKey='{1}'", GetLang(), key),"");
                if (drRows.Length > 0)
                {
                    value = drRows[0]["ResourceValue"].ToString();
                }
            }
            catch (Exception ee)
            {
                throw new Exception("Can't get the resource value, Exception:" + ee.Message);
            }
            return value;
        }

        public string GetString(string key, string webRegion)
        {
            string value = "None";
            try
            {
                DataTable dtCode = GetSysResource();
                DataRow[] drRows = dtCode.Select(string.Format(" LanguageCode='{0}' and ResourceKey='{1}' and ResourcePage='{2}' ", webRegion.ToLower(), key, pagename), "");
                if (drRows.Length > 0)
                {
                    value = drRows[0]["Text"].ToString();
                }
            }
            catch (Exception ee)
            {
                throw new Exception("Can't get the resource value, Exception:" + ee.Message);
            }
            return value;
        }

        public string GetPopupJson()
        {
            StringBuilder jsonBuilder = new StringBuilder("");
            try
            {
                DataTable dtCode = GetSysResource();
                DataRow[] drRows = dtCode.Select(string.Format(" LanguageCode='{0}' and ResourcePage='{1}' ", GetLang(), pagename), "");
                foreach (DataRow drRow in drRows)
                {
                    jsonBuilder.Append(string.Format("\"{0}\":\"{1}\",", drRow["ResourceKey"], drRow["ResourceValue"]));
                }
                if (pagename == "Common")
                {
                    jsonBuilder.Append(string.Format("\"msg_GlobalRegion\":\"{0}\",", GetLang()));
                }
            }
            catch (Exception ee)
            {
                throw new Exception("Can't get the resource value, Exception:" + ee.Message);
            }
            return jsonBuilder.ToString().Trim(',');
        }

        public string GetAllPopupJson()
        {
            var resHelper = new ResourcesHelper("Common");
            string pageJson = GetPopupJson();
            if (pageJson.Trim() == "")
            {
                return resHelper.GetPopupJson();
            }
            return GetPopupJson() + "," + resHelper.GetPopupJson();
        }
    }
}
