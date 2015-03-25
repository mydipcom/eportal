using MS.ECP.DALFactory;

namespace MS.ECP.BLL
{
    using MS.ECP.IDAL;
    using MS.ECP.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class SysLanguage
    {
        private readonly ISysLanguage dal = DataAccess.CreateSysLanguage();

        public bool Add(MS.ECP.Model.SysLanguage model)
        {
            return this.dal.Add(model);
        }

        public bool AddOrUpdate(MS.ECP.Model.SysLanguage model)
        {
            if (model.LanguageID == 0)
            {
                return this.dal.Add(model);
            }
            return this.dal.Update(model);
        }

        public bool Delete(int LanguageID)
        {
            return this.dal.Delete(LanguageID);
        }

        public bool DeleteByLangGuid(string langGuid)
        {
            return this.dal.DeleteByLangGuid(langGuid);
        }

        public bool DeleteList(string LanguageIDlist)
        {
            return this.dal.DeleteList(LanguageIDlist);
        }

        public bool Exists(int LanguageID)
        {
            return this.dal.Exists(LanguageID);
        }

        public IList<MS.ECP.Model.SysLanguage> GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetALLList()
        {
            return this.dal.GetDataSet("");
        }

        public IList<MS.ECP.Model.SysLanguage> GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetListDataSet(string strWhere)
        {
            return this.dal.GetDataSet(strWhere);
        }

        public DataSet GetListPaging(string strWhere, int startIndex, int endIndex)
        {
            return this.dal.GetListDataSetByPage(strWhere, startIndex, endIndex);
        }

        public MS.ECP.Model.SysLanguage GetModelByID(int ID)
        {
            return this.dal.GetModelByID(ID);
        }

        public MS.ECP.Model.SysLanguage GetModelByLangCode(string LanguageCode)
        {
            return this.dal.GetModelByLangCode(LanguageCode);
        }

        public MS.ECP.Model.SysLanguage GetModelByLangCodeAndWebRegion(string LanguageCode, string WebRegion)
        {
            return this.dal.GetModelByLangCodeAndWebRegion(LanguageCode, WebRegion);
        }

        public DataTable GetPageList(int pIndex, int pageCount, ref int total, string strWhere)
        {
            return this.dal.GetPageList(pIndex, pageCount, ref total, strWhere);
        }

        public IList<MS.ECP.Model.SysLanguage> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            return this.dal.GetPagingByLangCode(startIndex, endIndex, orderby, LangCode);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public IList<MS.ECP.Model.SysLanguage> GetTopByLangCode(int Top, string orderby, string LangCode)
        {
            return this.dal.GetTopByLangCode(Top, orderby, LangCode);
        }

        public bool Update(MS.ECP.Model.SysLanguage model)
        {
            return this.dal.Update(model);
        }
    }
}
