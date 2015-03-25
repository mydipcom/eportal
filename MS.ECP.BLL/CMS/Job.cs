using MS.ECP.DALFactory;

namespace MS.ECP.BLL.CMS
{
    using MS.ECP.IDAL.CMS;
    using MS.ECP.Model.CMS;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Job
    {
        private readonly IJob dal = DataAccess.CreateJob();

        public bool Add(MS.ECP.Model.CMS.Job model)
        {
            return this.dal.Add(model);
        }

        public bool AddOrUpdate(MS.ECP.Model.CMS.Job model)
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

        public bool DeleteByLangGuid(string langGuid)
        {
            return this.dal.DeleteByLangGuid(langGuid);
        }

        public bool DeleteList(string IDlist)
        {
            return this.dal.DeleteList(IDlist);
        }

        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }

        public IList<MS.ECP.Model.CMS.Job> GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetALLList()
        {
            return this.dal.GetDataSet("");
        }

        public IList<MS.ECP.Model.CMS.Job> GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public IList<MS.ECP.Model.CMS.Job> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, startIndex, endIndex);
        }

        public DataSet GetListDataSet(string strWhere)
        {
            return this.dal.GetDataSet(strWhere);
        }

        public DataSet GetListPaging(string strWhere, int startIndex, int endIndex)
        {
            return this.dal.GetListDataSetByPage(strWhere, startIndex, endIndex);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public MS.ECP.Model.CMS.Job GetModelByCache(int ID)
        {
            return this.dal.GetModelByCache(ID);
        }

        public MS.ECP.Model.CMS.Job GetModelByID(int ID)
        {
            return this.dal.GetModel(ID);
        }

        public MS.ECP.Model.CMS.Job GetModelByLangCode(string LanguageCode)
        {
            return this.dal.GetDefaultModelByLang(LanguageCode);
        }

        public MS.ECP.Model.CMS.Job GetModelByLangGuidAndLangCode(string langGuid, string languageCode)
        {
            return this.dal.GetModelByGuid(langGuid, languageCode);
        }

        public IList<MS.ECP.Model.CMS.Job> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            return this.dal.GetPagingByLangCode(Top, orderby, LangCode);
        }

        public IList<MS.ECP.Model.CMS.Job> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            return this.dal.GetPagingByLangCode(startIndex, endIndex, orderby, LangCode);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(MS.ECP.Model.CMS.Job model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateSeo(MS.ECP.Model.CMS.Job model)
        {
            return this.dal.UpdateSeo(model);
        }
    }
}
