using System;
using System.Collections.Generic;
using System.Data;

using MS.ECP.Model;
using MS.ECP.DALFactory;
using MS.ECP.IDAL.CMS;

namespace MS.ECP.BLL.CMS
{
    public class PageContent
    {
        private readonly IPageContent dal = DataAccess.CreatePageContent();

        public PageContent() { }

        #region 方法


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
        public bool Add(Model.CMS.PageContent model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.PageContent model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 添加或更新一条数据
        /// </summary>
        public bool AddOrUpdate(Model.CMS.PageContent model)
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
        /// 更新一条数据 SEO
        /// </summary>
        public bool UpdateSeo(Model.CMS.PageContent model)
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
        public Model.CMS.PageContent GetModelByID(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 根据LangGuid和LangCode得到一个对象实体
        /// </summary>
        public Model.CMS.PageContent GetModelByLangGuidAndLangCode(string langGuid, string languageCode)
        {
            return dal.GetModelByGuid(langGuid, languageCode);
        }

        /// <summary>
        /// 根据ParentGuid得到一个对象实体
        /// </summary>
        public Model.CMS.PageContent GetModelByParentGuid(string ParentGuid)
        {
            return dal.GetDefaultModel(ParentGuid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.CMS.PageContent GetModelByCache(int ID)
        {
            return dal.GetModelByCache(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.PageContent> GetList(string strWhere)
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
        public IList<Model.CMS.PageContent> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, startIndex, endIndex);
        }

        //// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.PageContent> GetAllList()
        {
            return GetList("");
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

        #endregion
    }
}
