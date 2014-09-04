using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MS.ECP.Model;
using MS.ECP.Common;
using MS.ECP.IDAL;

namespace MS.ECP.DAL
{
    public class SiteConfig : ISiteConfig
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.SiteConfig loadConfig(string configFilePath)
        {
            return (Model.SiteConfig)SerializationHelper.Load(typeof(Model.SiteConfig), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.SiteConfig saveConifg(Model.SiteConfig model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }
    }
}
