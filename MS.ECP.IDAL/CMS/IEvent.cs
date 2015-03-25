namespace MS.ECP.IDAL.CMS
{
    using MS.ECP.Model.CMS;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public interface IEvent
    {
        bool Add(CmsEvent model);
        bool Delete(int ID);
        bool DeleteByLangGuid(string langGuid);
        bool DeleteList(string IDlist);
        bool Exists(int ID);
        DataSet GetDataSet(string strWhere);
        CmsEvent GetDefaultModelByLang(string LanguageCode);
        IList<CmsEvent> GetList(string strWhere);
        IList<CmsEvent> GetList(int Top, string strWhere);
        IList<CmsEvent> GetListByPage(string strWhere, int startIndex, int endIndex);
        DataSet GetListDataSet(int Top, string strWhere);
        DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex);
        int GetMaxId();
        CmsEvent GetModel(int ID);
        CmsEvent GetModelByCache(int ID);
        CmsEvent GetModelByGuid(string langGuid, string languageId);
        IList<CmsEvent> GetPagingByLangCode(int Top, string orderby, string LangCode);
        IList<CmsEvent> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode);
        int GetRecordCount(string strWhere);
        bool Update(CmsEvent model);
        bool UpdateSeo(CmsEvent model);
    }
}
