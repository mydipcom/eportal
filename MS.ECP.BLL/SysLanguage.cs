using System;
using System.Data;
using System.Collections.Generic;

using MS.ECP.Model;
using MS.ECP.DALFactory;
using MS.ECP.IDAL;

namespace MS.ECP.BLL
{
	/// <summary>
    /// SysLanguage
	/// </summary>
	public partial class SysLanguage
	{
        private readonly ISysLanguage dal = DataAccess.CreateSysLanguage();
        public SysLanguage()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LanguageID)
		{
			return dal.Exists(LanguageID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.SysLanguage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.SysLanguage model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 添加或更新一条数据
        /// </summary>
        public bool AddOrUpdate(Model.SysLanguage model)
        {
            bool result;
            if (model.LanguageID == 0)
            {
                result = dal.Add(model);

            }
            else
            {
                result = dal.Update(model);
            }
            return result;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LanguageID)
		{
			return dal.Delete(LanguageID);
		}

        /// <summary>
        /// 根据LangGuid删除数据
        /// </summary>
        public bool DeleteByLangGuid(string langGuid)
        {
            return dal.DeleteByLangGuid(langGuid);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LanguageIDlist )
		{
			return dal.DeleteList(LanguageIDlist );
		}
        /// <summary>
        /// 根据LangCode和WebRegion得到一个对象实体
		/// </summary>
        public Model.SysLanguage GetModelByLangCodeAndWebRegion(string LanguageCode, string WebRegion)
		{
            return dal.GetModelByLangCodeAndWebRegion(LanguageCode, WebRegion);
		}
		/// <summary>
        /// 根据LangCode到一个对象实体
		/// </summary>
        public Model.SysLanguage GetModelByLangCode(string LanguageCode)
		{
            return dal.GetModelByLangCode(LanguageCode);
		}

        /// <summary>
        /// 根据LangCode到一个对象实体
        /// </summary>
        public Model.SysLanguage GetModelByID(int ID)
        {
            return dal.GetModelByID(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.SysLanguage> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        //// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.SysLanguage> GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        public IList<Model.SysLanguage> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            return dal.GetPagingByLangCode(startIndex, endIndex, orderby, LangCode);
        }
        /// <summary>
        /// 根据Language获得前几行数据
        /// </summary>
        public IList<Model.SysLanguage> GetTopByLangCode(int Top, string orderby, string LangCode)
        {
            return dal.GetTopByLangCode(Top, orderby, LangCode);
        }


        public DataSet GetALLList()
        {
            return dal.GetDataSet("");
        }
        public DataSet GetListDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }
        public DataSet GetListPaging(string strWhere, int startIndex, int endIndex)
        {
            return dal.GetListDataSetByPage(strWhere, startIndex, endIndex);
        }
		#endregion  Method

        public DataTable GetPageList(int pIndex, int pageCount, ref int total,string strWhere)
        {
            return dal.GetPageList(pIndex, pageCount, ref total, strWhere);
        }
    }
}

