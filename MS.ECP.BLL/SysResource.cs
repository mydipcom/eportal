using MS.ECP.DALFactory;

namespace MS.ECP.BLL
{
    using MS.ECP.Common;
    using MS.ECP.IDAL;
    using MS.ECP.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class SysResource
    {
        private readonly ISysResource dal = DataAccess.CreateSysResource();

        public bool Add(MS.ECP.Model.SysResource model)
        {
            return this.dal.Add(model);
        }

        public bool AddOrUpdate(MS.ECP.Model.SysResource model)
        {
            if (model.ID == 0)
            {
                return this.dal.Add(model);
            }
            return this.dal.Update(model);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        public bool DeleteList(string IDlist)
        {
            return this.dal.DeleteList(IDlist);
        }

        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }

        public DataSet GetALLList()
        {
            return this.GetListDataSet("");
        }

        public IList<MS.ECP.Model.SysResource> GetAllResourcePageList()
        {
            return this.dal.GetResourcePageList("");
        }

        public IList<MS.ECP.Model.SysResource> GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public IList<MS.ECP.Model.SysResource> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, startIndex, endIndex);
        }

        public DataSet GetListDataSet(string strWhere)
        {
            return this.dal.GetDataSet(strWhere);
        }

        public DataSet GetListDataSet(int Top, string strWhere, string filedOrder)
        {
            return this.dal.GetDataSet(Top, strWhere, filedOrder);
        }

        public DataSet GetListPaging(string strWhere, int startIndex, int endIndex)
        {
            return this.dal.GetListDataSetByPage(strWhere, startIndex, endIndex);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public MS.ECP.Model.SysResource GetModelByCache(int ID)
        {
            string cacheKey = "SysResourceModel-" + ID;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.dal.GetModel(ID);
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
            return (MS.ECP.Model.SysResource)cache;
        }

        public MS.ECP.Model.SysResource GetModelByID(int ID)
        {
            return this.dal.GetModel(ID);
        }

        public IList<MS.ECP.Model.SysResource> GetPagingByPageAndValue(int startIndex, int endIndex, string orderby, string resourcePage, string resourceValue)
        {
            return this.dal.GetPagingByPageAndValue(startIndex, endIndex, orderby, resourcePage, resourceValue);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public int GetRecordCountByPageAndValue(string resourcePage, string resourceValue)
        {
            return this.dal.GetRecordCountByPageAndValue(resourcePage, resourceValue);
        }

        public IList<MS.ECP.Model.SysResource> GetResourcePageList(string strWhere)
        {
            return this.dal.GetResourcePageList(strWhere);
        }

        public bool Update(MS.ECP.Model.SysResource model)
        {
            return this.dal.Update(model);
        }
    }
}
