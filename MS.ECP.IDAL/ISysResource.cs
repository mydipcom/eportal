using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.ECP.Model;

namespace MS.ECP.IDAL
{
    /// <summary>
    /// 接口层SysResource
    /// </summary>
    public interface ISysResource
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
        bool Add(SysResource model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(SysResource model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        SysResource GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<SysResource> GetList(string strWhere);

        /// <summary>
        /// 获取总记录数
        /// </summary>
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        IList<SysResource> GetListByPage(string strWhere, int startIndex, int endIndex);

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        IList<SysResource> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode);

        /// <summary>
        /// 根据Resourcepage和ResourceValue获得分页数据列表
        /// </summary>
        IList<SysResource> GetPagingByPageAndValue(int startIndex, int endIndex, string orderby, string resourcePage, string resourceValue);

        IList<Model.SysResource> GetResourcePageList(string strWhere);

        /// <summary>
        ///  根据Resourcepage和ResourceValue获取总记录数
        /// </summary>
        int GetRecordCountByPageAndValue(string resourcePage, string resourceValue);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetDataSet(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetDataSet(int Top, string strWhere, string filedOrder);
        DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}
