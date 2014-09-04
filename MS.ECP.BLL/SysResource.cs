using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.ECP.DALFactory;
using MS.ECP.IDAL;
using System.Collections;


namespace MS.ECP.BLL
{
    public partial class SysResource
    {
        private readonly ISysResource dal = DataAccess.CreateSysResource();
        public SysResource()
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
        public bool Add(Model.SysResource model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.SysResource model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 添加或更新一条数据
        /// </summary>
        public bool AddOrUpdate(Model.SysResource model)
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SysResource GetModelByID(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.SysResource GetModelByCache(int ID)
        {

            string CacheKey = "SysResourceModel-" + ID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = ECP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        ECP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ECP.Model.SysResource)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.SysResource> GetList(string strWhere)
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
        public IList<Model.SysResource> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, startIndex, endIndex);
        }

        /// <summary>
        /// 根据Resourcepage和ResourceValue获得分页数据列表
        /// </summary>
        public IList<Model.SysResource> GetPagingByPageAndValue(int startIndex, int endIndex, string orderby, string resourcePage, string resourceValue)
        {
            return dal.GetPagingByPageAndValue(startIndex, endIndex, orderby, resourcePage, resourceValue);
        }

        /// <summary>
        /// 获得所有ResourcePage数据列表
        /// </summary>
        public IList<Model.SysResource> GetAllResourcePageList()
        {
            return dal.GetResourcePageList("");
        }

        /// <summary>
        ///  根据Resourcepage和ResourceValue获取总记录数
        /// </summary>
        public int GetRecordCountByPageAndValue(string resourcePage, string resourceValue)
        {
            return dal.GetRecordCountByPageAndValue(resourcePage, resourceValue);
        }

        public IList<Model.SysResource> GetResourcePageList(string strWhere)
        {
            return dal.GetResourcePageList(strWhere);
        }

        public DataSet GetListDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }
        public DataSet GetListDataSet(int Top, string strWhere, string filedOrder)
        {
            return dal.GetDataSet(Top, strWhere, filedOrder);
        }
        public DataSet GetALLList()
        {
            return GetListDataSet("");
        }
        public DataSet GetListPaging(string strWhere, int startIndex, int endIndex)
        {
            return dal.GetListDataSetByPage(strWhere, startIndex, endIndex);
        }
        

        #endregion  Method
    }
}
