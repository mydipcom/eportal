using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MS.ECP.IDAL
{
    public interface ISysWebRegion
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string LangCode);
         
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.SysWebRegion GetModel(string LangCode);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法

    }
}
