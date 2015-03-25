using MS.ECP.DALFactory;

namespace MS.ECP.BLL.CMS
{
    using MS.ECP.IDAL.CMS;
    using MS.ECP.Model.CMS;
    using System;
    using System.Collections.Generic;

    public class AboutusBll
    {
        private readonly IAboutusDal dal = DataAccess.CreateAboutus();

        public bool Add(Aboutus model)
        {
            return this.dal.Add(model);
        }

        public bool AddOrUpdate(Aboutus model)
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

        public IList<Aboutus> GetAllList()
        {
            return this.GetList("");
        }

        public IList<Aboutus> GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public IList<Aboutus> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, startIndex, endIndex);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public Aboutus GetModelByCache(int ID)
        {
            return this.dal.GetModelByCache(ID);
        }

        public Aboutus GetModelByID(int ID)
        {
            return this.dal.GetModelByID(ID);
        }

        public Aboutus GetModelByLangCode(string LanguageCode)
        {
            return this.dal.GetModelByLangCode(LanguageCode);
        }

        public Aboutus GetModelByLangGuidAndLangCode(string langGuid, string languageCode)
        {
            return this.dal.GetModelByLangGuidAndLangCode(langGuid, languageCode);
        }

        public IList<Aboutus> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            return this.dal.GetPagingByLangCode(startIndex, endIndex, orderby, LangCode);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public IList<Aboutus> GetTop(int Top, string strWhere)
        {
            return this.dal.GetTop(Top, strWhere);
        }

        public IList<Aboutus> GetTopByLangCode(int Top, string orderby, string LangCode)
        {
            return this.dal.GetTopByLangCode(Top, orderby, LangCode);
        }

        public bool Update(Aboutus model)
        {
            return this.dal.Update(model);
        }

        public bool UpdateSeo(Aboutus model)
        {
            return this.dal.UpdateSeo(model);
        }
    }
}
