using System;
using System.Reflection;
using System.Configuration;
using MS.ECP.Common;

namespace MS.ECP.DALFactory
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口) 
    /// DataCache类在导出代码的文件夹里
    /// <appSettings> 
    /// <add key="DAL" value="MS.ECP.SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public sealed class DataAccess//<t>
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }

        /// <summary>
        /// 创建AllLanguage数据层接口。
        /// </summary>
        public static IDAL.ISysLanguage CreateSysLanguage()
        {

            string ClassNamespace = AssemblyPath + ".SysLanguage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ECP.IDAL.ISysLanguage)objType;
        }

        /// <summary>
        /// 创建SysResource数据层接口。
        /// </summary>
        public static IDAL.ISysResource CreateSysResource()
        {
            string ClassNamespace = AssemblyPath + ".SysResource";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ECP.IDAL.ISysResource)objType;
        }

        /// <summary>
        /// 创建SysWebRegion数据层接口。
        /// </summary>
        public static IDAL.ISysWebRegion CreateSysWebRegion()
        {

            string ClassNamespace = AssemblyPath + ".SysWebRegion";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.ISysWebRegion)objType;
        }

        /// <summary>
        /// 创建PageCotent的数据层接口
        /// </summary>
        /// <returns></returns>
        public static IDAL.CMS.IPageContent CreatePageContent()
        {
            string ClassNamespace = AssemblyPath + ".CMS.PageContent";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ECP.IDAL.CMS.IPageContent)objType;
        }

        /// <summary>
        /// 创建Category的数据层接口
        /// </summary>
        /// <returns></returns>
        public static IDAL.CMS.ICategory CreateCategory()
        {
            string ClassNamespace = AssemblyPath + ".CMS.Category";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ECP.IDAL.CMS.ICategory)objType;
        }

        public static IDAL.ISiteConfig CreateSiteConfig()
        {
            string ClassNamespace = AssemblyPath + ".SiteConfig";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ECP.IDAL.ISiteConfig)objType;
        }

        public static IDAL.CMS.IJob CreateJob()
        {
            string ClassNamespace = AssemblyPath + ".CMS.Job";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.CMS.IJob)objType;
        }

        public static IDAL.CMS.INews CreateNews()
        {
            string ClassNamespace = AssemblyPath + ".CMS.News";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.CMS.INews)objType;
        }

        public static IDAL.IUserInfo CreateUserInfo()
        {
            string ClassNamespace = AssemblyPath + ".UserInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ECP.IDAL.IUserInfo)objType;
        }

        public static IDAL.CMS.IEvent CreateEvent()
        {
            string ClassNamespace = AssemblyPath + ".CMS.Event";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ECP.IDAL.CMS.IEvent)objType;
        }

        public static IDAL.CMS.IAboutusDal CreateAboutus()
        {
            string ClassNamespace = AssemblyPath + ".CMS.AboutusDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ECP.IDAL.CMS.IAboutusDal)objType;
        }
    }
}