using MS.ECP.Model.CMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MS.ECP.IDAL.CMS
{
    public interface IJob
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
        bool Add(Job model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Job model);

        /// <summary>
        /// 更新一条SEO数据
        /// </summary>
        bool UpdateSeo(Job model);

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
        Job GetModel(int ID);

        /// <summary>
        /// 根据LangGuid得到一个对象实体
        /// </summary>
        Job GetModelByGuid(string langGuid, string languageId);

        /// <summary>
        /// 根据Language得到一个对象实体
        /// </summary>
        Job GetDefaultModelByLang(string LanguageCode);

        /// <summary>
        /// 从缓存中得到一个对象实体
        /// </summary>
        Job GetModelByCache(int ID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<Job> GetList(string strWhere);

        /// <summary>
        /// 获取总记录数
        /// </summary>
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        IList<Job> GetListByPage(string strWhere, int startIndex, int endIndex);

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        IList<Job> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode);

        /// <summary>
        /// 根据Language获得前几行数据
        /// </summary>
        IList<Job> GetPagingByLangCode(int Top, string orderby, string LangCode);


        DataSet GetDataSet(string strWhere);
        DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex);

        #endregion  成员方法
    }
}
