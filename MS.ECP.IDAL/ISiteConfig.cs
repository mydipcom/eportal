using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.IDAL
{
    public interface ISiteConfig
    {
        Model.SiteConfig loadConfig(string configFilePath);
        Model.SiteConfig saveConifg(Model.SiteConfig model, string configFilePath);
    }
}
