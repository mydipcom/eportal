using MS.ECP.DALFactory;

namespace MS.ECP.BLL
{
    using MS.ECP.Common;
    using MS.ECP.IDAL;
    using MS.ECP.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class SysWebRegion
    {
        private readonly ISysWebRegion dal = DataAccess.CreateSysWebRegion();

        public List<MS.ECP.Model.SysWebRegion> DataTableToList(DataTable dt)
        {
            List<MS.ECP.Model.SysWebRegion> list = new List<MS.ECP.Model.SysWebRegion>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.SysWebRegion item = new MS.ECP.Model.SysWebRegion();
                    if ((dt.Rows[i]["LangCode"] != null) && (dt.Rows[i]["LangCode"].ToString() != ""))
                    {
                        item.LangCode = dt.Rows[i]["LangCode"].ToString();
                    }
                    if ((dt.Rows[i]["LangText"] != null) && (dt.Rows[i]["LangText"].ToString() != ""))
                    {
                        item.LangText = dt.Rows[i]["LangText"].ToString();
                    }
                    if ((dt.Rows[i]["DisplayOrder"] != null) && (dt.Rows[i]["DisplayOrder"].ToString() != ""))
                    {
                        item.DisplayOrder = int.Parse(dt.Rows[i]["DisplayOrder"].ToString());
                    }
                    if ((dt.Rows[i]["Status"] != null) && (dt.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = int.Parse(dt.Rows[i]["Status"].ToString());
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Exists(string LangCode)
        {
            return this.dal.Exists(LangCode);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return this.dal.GetList(Top, strWhere, filedOrder);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public MS.ECP.Model.SysWebRegion GetModel(string LangCode)
        {
            return this.dal.GetModel(LangCode);
        }

        public MS.ECP.Model.SysWebRegion GetModelByCache(string LangCode)
        {
            string cacheKey = "SysWebRegionModel-" + LangCode;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(LangCode);
                    if (cache != null)
                    {
                        int configInt = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(cacheKey, cache, DateTime.Now.AddMinutes((double)configInt), TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (MS.ECP.Model.SysWebRegion)cache;
        }

        public List<MS.ECP.Model.SysWebRegion> GetModelList(string strWhere)
        {
            DataSet list = this.dal.GetList(strWhere);
            return this.DataTableToList(list.Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }
    }
}
