using MS.ECP.DALFactory;
using MS.ECP.IDAL.CMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MS.ECP.BLL.CMS
{
    public partial class News
    {
        private readonly INews dal = DataAccess.CreateNews();
        public News()
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
        public bool Add(Model.CMS.News model)
        {
           return dal.Add(model);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.CMS.NewsInput model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.News model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.NewsInput model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 添加或更新一条数据
        /// </summary>
        public bool AddOrUpdate(Model.CMS.News model)
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
        public bool UpdateSeo(Model.CMS.News model)
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
        /// 删除一条数据
        /// </summary>
        public bool Deleteintput(int ID)
        {
            return dal.DeleteInput(ID); 
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
        public Model.CMS.News GetModelByID(int ID)
        {
            return dal.GetModel(ID);
        }


        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        public Model.CMS.NewsInput GetNewsInputByID(int ID)
        {
            return dal.GetNewsInputModel(ID);  
        }

        /// <summary>
        /// 根据LangGuid和LangCode得到一个对象实体
        /// </summary>
        public Model.CMS.News GetModelByLangGuidAndLangCode(string langGuid, string languageCode)
        {
            return dal.GetModelByGuid(langGuid, languageCode);
        }

        /// <summary>
        /// 根据LanguageCode得到一个对象实体
        /// </summary>
        public Model.CMS.News GetModelByLangCode(string LanguageCode)
        {
            return dal.GetDefaultModelByLang(LanguageCode);
        }

        /// <summary>
        /// 根据LanguageCode得到一个最新对象实体
        /// </summary>
        public Model.CMS.News GetNewestModelByLangCode(string LanguageCode)
        {
            return dal.GetNewestModelByLangCode(LanguageCode);
        }

        /// <summary>
        /// 从缓存中得到一个对象实体
        /// </summary>
        public Model.CMS.News GetModelByCache(int ID)
        {
            return dal.GetModelByCache(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.News> GetList(string strWhere)
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
        public IList<Model.CMS.News> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, startIndex, endIndex);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<Model.CMS.News> GetList(int Top, string strWhere)
        {
            return dal.GetList(Top, strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.News> GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        public IList<Model.CMS.News> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            return dal.GetPagingByLangCode(startIndex, endIndex, orderby, LangCode);
        }
        /// <summary>
        /// 根据Language获得前几行数据
        /// </summary>
        public IList<Model.CMS.News> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            return dal.GetPagingByLangCode(Top, orderby, LangCode);
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
        public DataSet GetListDataSet(int Top, string strWhere)
        {
            return dal.GetListDataSet(Top, strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        //}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}


 
