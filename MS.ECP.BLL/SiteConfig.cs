using MS.ECP.DALFactory;

namespace MS.ECP.BLL
{
    using MS.ECP.Common;
    using MS.ECP.IDAL;
    using MS.ECP.Model;
    using System;

    public class SiteConfig
    {
        private readonly ISiteConfig dal = DataAccess.CreateSiteConfig();

        public MS.ECP.Model.SiteConfig loadConfig(string configFilePath)
        {
            MS.ECP.Model.SiteConfig config = DataCache.Get<MS.ECP.Model.SiteConfig>("ms_cache_site_config");
            if (config == null)
            {
                DataCache.SetCache("ms_cache_site_config", this.dal.loadConfig(configFilePath), configFilePath);
                config = DataCache.Get<MS.ECP.Model.SiteConfig>("ms_cache_site_config");
            }
            return config;
        }
    }
}
