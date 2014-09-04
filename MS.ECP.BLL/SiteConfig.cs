using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using MS.ECP.Common;
using MS.ECP.Model;
using MS.ECP.IDAL;
using MS.ECP.DALFactory;

namespace MS.ECP.BLL
{
    public class SiteConfig
    {
        private readonly ISiteConfig dal = DataAccess.CreateSiteConfig();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        public Model.SiteConfig loadConfig(string configFilePath)
        {
            Model.SiteConfig model = Common.DataCache.Get<Model.SiteConfig>("ms_cache_site_config");
            if (model == null)
            {
                Common.DataCache.SetCache("ms_cache_site_config", dal.loadConfig(configFilePath), configFilePath);
                model = Common.DataCache.Get<Model.SiteConfig>("ms_cache_site_config");
            }
            return model;
        }

    }
}
