using MS.ECP.DALFactory;

namespace MS.ECP.BLL
{
    using MS.ECP.IDAL.CMS;
    using MS.ECP.Model.CMS;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Event
    {
        private readonly IEvent dal = DataAccess.CreateEvent();

        public bool Add(CmsEvent model)
        {
            return this.dal.Add(model);
        }

        public bool AddOrUpdate(CmsEvent model)
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

        public IList<CmsEvent> GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetALLList()
        {
            return this.dal.GetDataSet("");
        }

        public IList<CmsEvent> GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public IList<CmsEvent> GetList(int Top, string strWhere)
        {
            return this.dal.GetList(Top, strWhere);
        }

        public IList<CmsEvent> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, startIndex, endIndex);
        }

        public DataSet GetListDataSet(string strWhere)
        {
            return this.dal.GetDataSet(strWhere);
        }

        public DataSet GetListDataSet(int Top, string strWhere)
        {
            return this.dal.GetListDataSet(Top, strWhere);
        }

        public DataSet GetListPaging(string strWhere, int startIndex, int endIndex)
        {
            return this.dal.GetListDataSetByPage(strWhere, startIndex, endIndex);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public CmsEvent GetModelByCache(int ID)
        {
            return this.dal.GetModelByCache(ID);
        }

        public CmsEvent GetModelByID(int ID)
        {
            return this.dal.GetModel(ID);
        }

        public CmsEvent GetModelByLangCode(string LanguageCode)
        {
            return this.dal.GetDefaultModelByLang(LanguageCode);
        }

        public CmsEvent GetModelByLangGuidAndLangCode(string langGuid, string languageCode)
        {
            return this.dal.GetModelByGuid(langGuid, languageCode);
        }

        public IList<CmsEvent> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            return this.dal.GetPagingByLangCode(Top, orderby, LangCode);
        }

        public IList<CmsEvent> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            return this.dal.GetPagingByLangCode(startIndex, endIndex, orderby, LangCode);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(CmsEvent model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateSeo(CmsEvent model)
        {
            return this.dal.UpdateSeo(model);
        }
    }
}
