using MS.ECP.Model.CMS;
using System;
using System.Collections.Generic;
using System.Data;

namespace MS.ECP.IDAL.CMS
{
    public interface ICategory
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
        bool Add(Model.CMS.Category model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Model.CMS.Category model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateSeo(Model.CMS.Category model);

        /// <summary>
        /// 删除数据
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
        Category GetModel(int ID);

        /// <summary>
        /// 根据Guid得到一个对象实体
        /// </summary>
        Category GetModelByGuid(string guid, string languageId);

        /// <summary>
        /// 根据Language得到一个对象实体
        /// </summary>
        Category GetDefaultModelByLang(string LanguageCode);

        /// <summary>
        /// 根据条件得到对象实体
        /// </summary>
        Category GetModelByWhere(string strWhere);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<Category> GetList(string strWhere);

        /// <summary>
        /// 获取总记录数
        /// </summary>
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        IList<Category> GetListByPage(string strWhere, int startIndex, int endIndex);

        /// <summary>
        /// 从缓存中得到一个对象实体
        /// </summary>
        Category GetModelByCache(int ID);

        DataSet GetDataSet(string strWhere);
        DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex);

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}
