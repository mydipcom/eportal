using MS.ECP.Model.CMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MS.ECP.IDAL.CMS
{
    /// <summary>
    /// 接口层INews
    /// </summary>
    public interface INews
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(News model);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Model.CMS.NewsInput model);

        bool Update(Model.CMS.NewsInput model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(News model);

        /// <summary>
        /// 更新一条SEO数据
        /// </summary>
        bool UpdateSeo(News model);

        Model.CMS.NewsInput GetNewsInputModel(int ID);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);

                /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteInput(int ID);
        
        /// <summary>
        /// 根据LangGuid删除数据
        /// </summary>
        bool DeleteByLangGuid(string langGuid);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        bool DeleteList(string IDlist);

        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        News GetModel(int ID);

        /// <summary>
        /// 根据LangGuid得到一个对象实体
        /// </summary>
        News GetModelByGuid(string langGuid, string languageId);  

        /// <summary>
        /// 根据Language得到一个对象实体
        /// </summary>
        News GetDefaultModelByLang(string LanguageCode);

         /// <summary>
        /// 根据LanguageCode得到一个最新对象实体
        /// </summary>
        News GetNewestModelByLangCode(string LanguageCode);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<News> GetList(string strWhere);

        /// <summary>
        /// 获取总记录数
        /// </summary>
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        IList<News> GetListByPage(string strWhere, int startIndex, int endIndex);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        IList<News> GetList(int Top, string strWhere);

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        IList<News> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode);

        /// <summary>
        /// 根据Language获得前几行数据
        /// </summary>
        IList<News> GetPagingByLangCode(int Top, string orderby, string LangCode);

        /// <summary>
        /// 从缓存中得到一个对象实体
        /// </summary>
        News GetModelByCache(int ID);


        //DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        //DataSet GetListDataSet(int PageSize,int PageIndex,string strWhere);
        DataSet GetDataSet(string strWhere);
        DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex);
        DataSet GetListDataSet(int Top, string strWhere);

        #endregion  成员方法
    }
}
