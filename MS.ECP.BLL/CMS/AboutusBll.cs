using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MS.ECP.DALFactory;
using MS.ECP.IDAL.CMS;

namespace MS.ECP.BLL.CMS  
{
    public partial class AboutusBll
    {
        private readonly IAboutusDal dal = DataAccess.CreateAboutus();

        public AboutusBll()
        { }

        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.CMS.Aboutus model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.Aboutus model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 添加或更新一条数据
        /// </summary>
        public bool AddOrUpdate(Model.CMS.Aboutus model)
        {
            bool result;
            if (model.ID == 0)
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
        /// 更新一条SEO数据
        /// </summary>
        public bool UpdateSeo(Model.CMS.Aboutus model)
        {
            return dal.UpdateSeo(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 根据LangGuid删除数据
        /// </summary>
        public bool DeleteByLangGuid(string langGuid)
        {
            return dal.DeleteByLangGuid(langGuid);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        public Model.CMS.Aboutus GetModelByID(int ID)
        {

            return dal.GetModelByID(ID);
        }

        /// <summary>
        /// 根据LangGuid和LangCode得到一个对象实体
        /// </summary>
        public Model.CMS.Aboutus GetModelByLangGuidAndLangCode(string langGuid, string languageCode)
        {
            return dal.GetModelByLangGuidAndLangCode(langGuid, languageCode);
        }
         
        /// <summary>
        /// 根据Language得到一个对象实体
        /// </summary>
        public Model.CMS.Aboutus GetModelByLangCode(string LanguageCode)
        {
            return dal.GetModelByLangCode(LanguageCode);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.CMS.Aboutus GetModelByCache(int ID)
        {
            return dal.GetModelByCache(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.Aboutus> GetList(string strWhere)
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

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public IList<Model.CMS.Aboutus> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, startIndex, endIndex);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<Model.CMS.Aboutus> GetTop(int Top, string strWhere)
        {
            return dal.GetTop(Top, strWhere);
        }

        //// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.Aboutus> GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        public IList<Model.CMS.Aboutus> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            return dal.GetPagingByLangCode(startIndex, endIndex, orderby, LangCode);
        }
        /// <summary>
        /// 根据Language获得前几行数据
        /// </summary>
        public IList<Model.CMS.Aboutus> GetTopByLangCode(int Top, string orderby, string LangCode)
        {
            return dal.GetTopByLangCode(Top, orderby, LangCode);
        }

        #endregion
    }
}
