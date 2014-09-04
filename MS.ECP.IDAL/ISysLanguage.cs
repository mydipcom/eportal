using System;
using System.Collections.Generic;
using System.Data;

namespace MS.ECP.IDAL
{
	/// <summary>
	/// 接口层SysLanguage
	/// </summary>
	public interface ISysLanguage
	{
		#region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
		/// <summary>
		/// 根据ID是否存在该记录
		/// </summary>
		bool Exists(int LanguageID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Model.SysLanguage model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Model.SysLanguage model);
		/// <summary>
		/// 根据ID删除一条数据
		/// </summary>
		bool Delete(int LanguageID);

        /// <summary>
        /// 根据LangGuid删除数据
        /// </summary>
        bool DeleteByLangGuid(string langGuid);

        /// <summary>
        /// 删除多条数据
        /// </summary>
		bool DeleteList(string LanguageIDlist );

        /// <summary>
        /// 根据LangCode到一个对象实体
        /// </summary>
        Model.SysLanguage GetModelByLangCode(string LanguageCode);
        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        Model.SysLanguage GetModelByID(int ID);

        /// <summary>
		/// 根据LangCode和WebRegion得到一个对象实体
		/// </summary>
        Model.SysLanguage GetModelByLangCodeAndWebRegion(string LanguageCode, string WebRegion);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<Model.SysLanguage> GetList(string strWhere);

        /// <summary>
        /// 获取总记录数
        /// </summary>
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        IList<Model.SysLanguage> GetListByPage(string strWhere, int startIndex, int endIndex);

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        IList<Model.SysLanguage> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode);

        /// <summary>
        /// 根据Language获得前几行数据
        /// </summary>
        IList<Model.SysLanguage> GetTopByLangCode(int Top, string orderby, string LangCode);


        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetDataSet(string strWhere);
        DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex);

		#endregion  成员方法

        DataTable GetPageList(int pIndex, int pageCount, ref int total,string strWhere);
    } 
}
