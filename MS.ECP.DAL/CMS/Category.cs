using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MS.ECP.Model.CMS;
using MS.ECP.Utility;
using MS.ECP.IDAL.CMS;

namespace MS.ECP.DAL.CMS
{
    public partial class Category : ICategory
    {
        public Category() { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CmsCategory");
        }

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CmsCategory");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.CMS.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CmsCategory(");
            strSql.Append("Guid, CategoryName,LanguageCode,ParentGuid,Keywords,Description,SeoTitle,Url");
            strSql.Append(") values (");
            strSql.Append("@Guid, @CategoryName,@LanguageCode,@ParentGuid,@Keywords,@Description,@SeoTitle,@Url");
            strSql.Append(") ");

            SqlParameter[] parameters = {      
                        new SqlParameter("@Guid",SqlDbType.NVarChar,1000), 
                        new SqlParameter("@CategoryName", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ParentGuid", SqlDbType.NVarChar,1000),
                        new SqlParameter("@Keywords", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Description", SqlDbType.NText), 
                        new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,225) 
            };

            if (model.Guid == "" || model.Guid == null)
            {
                parameters[0].Value = Guid.NewGuid().ToString();
            }
            else
            {
                parameters[0].Value = model.Guid;
            }
            parameters[1].Value = model.CategoryName;
            parameters[2].Value = model.LanguageCode;
            parameters[3].Value = model.ParentGuid;
            parameters[4].Value = model.Keywords;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.SeoTitle;
            parameters[7].Value = model.Url;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsCategory set ");
            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" CategoryName = @CategoryName , ");
            strSql.Append(" LanguageCode = @LanguageCode , ");
            strSql.Append(" ParentGuid = @ParentGuid , ");
            strSql.Append(" Keywords = @Keywords , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" SeoTitle = @SeoTitle ,  ");
            strSql.Append(" Url = @Url  ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
			        new SqlParameter("@ID", SqlDbType.Int,4) ,       
                    new SqlParameter("@Guid",SqlDbType.NVarChar,1000),
                    new SqlParameter("@CategoryName", SqlDbType.NVarChar,255) ,            
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,            
                    new SqlParameter("@ParentGuid", SqlDbType.NVarChar,1000) ,
                    new SqlParameter("@Keywords", SqlDbType.NVarChar,50) ,            
                    new SqlParameter("@Description", SqlDbType.NText) ,            
                    new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                    new SqlParameter("@Url", SqlDbType.NVarChar,225)
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Guid;
            parameters[2].Value = model.CategoryName;
            parameters[3].Value = model.LanguageCode;
            parameters[4].Value = model.ParentGuid;
            parameters[5].Value = model.Keywords;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.SeoTitle;
            parameters[8].Value = model.Url;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSeo(Model.CMS.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsCategory set ");
            strSql.Append(" Keywords = @Keywords , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" SeoTitle = @SeoTitle ,  ");
            strSql.Append(" Url = @Url  ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Keywords", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Description", SqlDbType.NText) ,            
                        new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,225)               
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Keywords;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.SeoTitle;
            parameters[4].Value = model.Url;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CmsCategory ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)		
            };

            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据LangGuid删除数据
        /// </summary>
        public bool DeleteByLangGuid(string langGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CmsCategory ");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,1000)		};
            parameters[0].Value = langGuid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CmsCategory ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        public Model.CMS.Category GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsCategory ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;


            Model.CMS.Category model = new Model.CMS.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryName"] != null && ds.Tables[0].Rows[0]["CategoryName"].ToString() != "")
                {
                    model.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentGuid"].ToString() != "")
                {
                    model.ParentGuid = ds.Tables[0].Rows[0]["ParentGuid"].ToString();
                }
                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        public Model.CMS.Category GetModelByGuid(string guid, string languageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsCategory ");
            strSql.Append(" where Guid=@Guid ");
            strSql.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Guid", SqlDbType.NVarChar,1000) ,
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,
            };
            parameters[0].Value = guid;
            parameters[1].Value = languageId;


            Model.CMS.Category model = new Model.CMS.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryName"] != null && ds.Tables[0].Rows[0]["CategoryName"].ToString() != "")
                {
                    model.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentGuid"].ToString() != "")
                {
                    model.ParentGuid = ds.Tables[0].Rows[0]["ParentGuid"].ToString();
                }

                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        public Model.CMS.Category  GetDefaultModelByLang(string LanguageCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsCategory ");
            strSql.Append(" where LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = LanguageCode;


            Model.CMS.Category model = new Model.CMS.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryName"] != null && ds.Tables[0].Rows[0]["CategoryName"].ToString() != "")
                {
                    model.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentGuid"].ToString() != "")
                {
                    model.ParentGuid = ds.Tables[0].Rows[0]["ParentGuid"].ToString();
                }

                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件得到对象实体
        /// </summary>
        public Model.CMS.Category GetModelByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            Model.CMS.Category model = new Model.CMS.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryName"] != null && ds.Tables[0].Rows[0]["CategoryName"].ToString() != "")
                {
                    model.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentGuid"].ToString() != "")
                {
                    model.ParentGuid = ds.Tables[0].Rows[0]["ParentGuid"].ToString();
                }

                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.Category> GetList(string strWhere)
        {
            DataSet ds = GetDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Category> modelList = new List<Model.CMS.Category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Category model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Category();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["CategoryName"] != null && dt.Rows[n]["CategoryName"].ToString() != "")
                    {
                        model.CategoryName = dt.Rows[n]["CategoryName"].ToString();
                    }
                    if (dt.Rows[n]["ParentGuid"] != null && dt.Rows[n]["ParentGuid"].ToString() != "")
                    {
                        model.ParentGuid = dt.Rows[n]["ParentGuid"].ToString();
                    }

                    model.Keywords = dt.Rows[n]["Keywords"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    model.SeoTitle = dt.Rows[n]["SeoTitle"].ToString();
                    model.Url = dt.Rows[n]["Url"].ToString();

                    modelList.Add(model);
                }
            }

            return modelList;
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CmsCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM CmsCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public IList<Model.CMS.Category> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = GetListDataSetByPage(strWhere, startIndex, endIndex);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Category> modelList = new List<Model.CMS.Category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Category model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Category();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["CategoryName"] != null && dt.Rows[n]["CategoryName"].ToString() != "")
                    {
                        model.CategoryName = dt.Rows[n]["CategoryName"].ToString();
                    }
                    if (dt.Rows[n]["ParentGuid"] != null && dt.Rows[n]["ParentGuid"].ToString() != "")
                    {
                        model.ParentGuid = dt.Rows[n]["ParentGuid"].ToString();
                    }

                    model.Keywords = dt.Rows[n]["Keywords"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    model.SeoTitle = dt.Rows[n]["SeoTitle"].ToString();
                    model.Url = dt.Rows[n]["Url"].ToString();

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex)
        {
            var strSql = new StringBuilder();
            strSql.Append(
                "SELECT  *  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.ID desc");
            strSql.Append(")AS Row, T.*  from CmsCategory T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM CmsCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 从缓存中得到一个对象实体
        /// </summary>
        public Model.CMS.Category GetModelByCache(int ID)
        {
            string CacheKey = "CategoryModel-" + ID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = ECP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        ECP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.CMS.Category)objModel;
        }
    }
        #endregion Method
}
