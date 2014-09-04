using MS.ECP.Model.CMS;
using System;
using System.Collections.Generic;
using System.Data;

namespace MS.ECP.IDAL.CMS
{
    public interface IPageContent
    {
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
        bool Add(PageContent model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(PageContent model);

        /// <summary>
        /// 更新一条SEO数据
        /// </summary>
        bool UpdateSeo(PageContent model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);

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
        PageContent GetModel(int id);

        /// <summary>
        /// 根据CategoryID得到一个对象实体
        /// </summary>
        PageContent GetFirstModelByCategory(int categoryID);

        /// <summary>
        /// 根据Guid得到一个对象实体
        /// </summary>
        PageContent GetModelByGuid(string guid, string languageId);

        /// <summary>
        /// 根据ParentGuid得到一个对象实体
        /// </summary>
        PageContent GetDefaultModel(string ParentGuid);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<PageContent> GetList(string strWhere);

        /// <summary>
        /// 获取总记录数
        /// </summary>
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        IList<PageContent> GetListByPage(string strWhere, int startIndex, int endIndex);

        /// <summary>
        /// 从缓存中得到一个对象实体
        /// </summary>
        PageContent GetModelByCache(int ID);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetDataSet(string strWhere);

        DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex);
    }
}
