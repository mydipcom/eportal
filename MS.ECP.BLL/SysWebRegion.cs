using System;
using System.Collections.Generic;
using System.Data;

using MS.ECP.DALFactory;
using MS.ECP.IDAL;

namespace MS.ECP.BLL
{
    public partial class SysWebRegion
    {
        private readonly ISysWebRegion dal = DataAccess.CreateSysWebRegion();

        public SysWebRegion()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string LangCode)
		{
			return dal.Exists(LangCode);
		}
         
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MS.ECP.Model.SysWebRegion GetModel(string LangCode)
		{
			
			return dal.GetModel(LangCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MS.ECP.Model.SysWebRegion GetModelByCache(string LangCode)
		{
			
			string CacheKey = "SysWebRegionModel-" + LangCode;
            object objModel = MS.ECP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(LangCode);
					if (objModel != null)
					{
                        int ModelCache = MS.ECP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        MS.ECP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MS.ECP.Model.SysWebRegion)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        
        /// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MS.ECP.Model.SysWebRegion> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MS.ECP.Model.SysWebRegion> DataTableToList(DataTable dt)
		{
			List<MS.ECP.Model.SysWebRegion> modelList = new List<MS.ECP.Model.SysWebRegion>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MS.ECP.Model.SysWebRegion model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new MS.ECP.Model.SysWebRegion();
					if(dt.Rows[n]["LangCode"]!=null && dt.Rows[n]["LangCode"].ToString()!="")
					{
					model.LangCode=dt.Rows[n]["LangCode"].ToString();
					}
					if(dt.Rows[n]["LangText"]!=null && dt.Rows[n]["LangText"].ToString()!="")
					{
					model.LangText=dt.Rows[n]["LangText"].ToString();
					}
                    if (dt.Rows[n]["DisplayOrder"] != null && dt.Rows[n]["DisplayOrder"].ToString() != "")
					{
                        model.DisplayOrder = int.Parse(dt.Rows[n]["DisplayOrder"].ToString());
					}
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
					{
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
					}

					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

		#endregion  Method

    }
}
