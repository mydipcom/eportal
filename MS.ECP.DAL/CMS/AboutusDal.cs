using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MS.ECP.Utility;
using MS.ECP.IDAL.CMS;

namespace MS.ECP.DAL.CMS
{
    public partial class AboutusDal : IAboutusDal
    {
        public AboutusDal() { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CmsAboutus");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CmsAboutus");
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
        public bool Add(Model.CMS.Aboutus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CmsAboutus(");
            strSql.Append("Guid,LangGuid,LanguageCode,LinkTitle,Content,Status,SortOrder,Keywords,Description,SeoTitle,Url");
            strSql.Append(") values (");
            strSql.Append("@Guid,@LangGuid,@LanguageCode,@LinkTitle,@Content,@Status,@SortOrder,@Keywords,@Description,@SeoTitle,@Url");
            strSql.Append(") ");

            SqlParameter[] parameters = {   
                        new SqlParameter("@Guid",SqlDbType.NVarChar,1000),  
                        new SqlParameter("@LangGuid",SqlDbType.NVarChar,1000),  
                        new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LinkTitle", SqlDbType.NVarChar,250) ,                       
                        new SqlParameter("@Content", SqlDbType.NText) ,   
                        new SqlParameter("@Status", SqlDbType.Int,4), 
                        new SqlParameter("@SortOrder", SqlDbType.Int,4), 
                        new SqlParameter("@Keywords", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Description", SqlDbType.NText), 
                        new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,225) 
            };
            parameters[0].Value = Guid.NewGuid().ToString();
            if (model.LangGuid == null)
            {
                parameters[1].Value = Guid.NewGuid().ToString();
            }
            else
            {
                parameters[1].Value = model.LangGuid;
            }
            parameters[2].Value = model.LanguageCode;
            parameters[3].Value = model.LinkTitle;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.SortOrder;
            parameters[7].Value = model.Keywords;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.SeoTitle;
            parameters[10].Value = model.Url;

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
        public bool Update(Model.CMS.Aboutus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsAboutus set ");
            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" LangGuid = @LangGuid , ");
            strSql.Append(" LanguageCode = @LanguageCode , ");
            strSql.Append(" LinkTitle = @LinkTitle , ");
            strSql.Append(" Content = @Content ,  ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" SortOrder = @SortOrder ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,    
                        new SqlParameter("@Guid",SqlDbType.NVarChar,1000),
                        new SqlParameter("@LangGuid", SqlDbType.NVarChar,1000) ,
                        new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LinkTitle", SqlDbType.NVarChar,250) ,
                        new SqlParameter("@Content", SqlDbType.NText) , 
                        new SqlParameter("@Status", SqlDbType.Int,4),   
                        new SqlParameter("@SortOrder", SqlDbType.Int,4)                        
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Guid;
            parameters[2].Value = model.LangGuid;
            parameters[3].Value = model.LanguageCode;
            parameters[4].Value = model.LinkTitle;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.SortOrder;

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
        /// 更新一条数据 SEO
        /// </summary>
        public bool UpdateSeo(Model.CMS.Aboutus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsAboutus set ");
            strSql.Append(" Keywords = @Keywords , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" SeoTitle = @SeoTitle ,  ");
            strSql.Append(" Url = @Url  ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Keywords", SqlDbType.NVarChar,50) ,            
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
            strSql.Append("delete from CmsAboutus ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)		};
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
            strSql.Append("delete from CmsAboutus ");
            strSql.Append(" where LangGuid=@LangGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@LangGuid", SqlDbType.NVarChar,1000)		};
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
            strSql.Append("delete from CmsAboutus ");
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
        public Model.CMS.Aboutus GetModelByID(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsAboutus ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;


            Model.CMS.Aboutus model = new Model.CMS.Aboutus();
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
                if (ds.Tables[0].Rows[0]["LangGuid"] != null && ds.Tables[0].Rows[0]["LangGuid"].ToString() != "")
                {
                    model.LangGuid = ds.Tables[0].Rows[0]["LangGuid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkTitle"] != null && ds.Tables[0].Rows[0]["LinkTitle"].ToString() != "")
                {
                    model.LinkTitle = ds.Tables[0].Rows[0]["LinkTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortOrder"].ToString() != "")
                {
                    model.SortOrder = int.Parse(ds.Tables[0].Rows[0]["SortOrder"].ToString());
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
        /// 根据LangGuid和LangCode得到一个对象实体
        /// </summary>
        public Model.CMS.Aboutus GetModelByLangGuidAndLangCode(string langGuid, string languageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsAboutus ");
            strSql.Append(" where LangGuid=@LangGuid ");
            strSql.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LangGuid", SqlDbType.NVarChar,1000) ,
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,
            };
            parameters[0].Value = langGuid;
            parameters[1].Value = languageId;


            Model.CMS.Aboutus model = new Model.CMS.Aboutus();
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
                if (ds.Tables[0].Rows[0]["LangGuid"] != null && ds.Tables[0].Rows[0]["LangGuid"].ToString() != "")
                {
                    model.LangGuid = ds.Tables[0].Rows[0]["LangGuid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkTitle"] != null && ds.Tables[0].Rows[0]["LinkTitle"].ToString() != "")
                {
                    model.LinkTitle = ds.Tables[0].Rows[0]["LinkTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortOrder"].ToString() != "")
                {
                    model.SortOrder = int.Parse(ds.Tables[0].Rows[0]["SortOrder"].ToString());
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
        /// 根据LanguageCode得到一个对象实体
        /// </summary>
        public Model.CMS.Aboutus GetModelByLangCode(string LanguageCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsAboutus ");
            strSql.Append(" where LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = LanguageCode;

            Model.CMS.Aboutus model = new Model.CMS.Aboutus();
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
                if (ds.Tables[0].Rows[0]["LangGuid"] != null && ds.Tables[0].Rows[0]["LangGuid"].ToString() != "")
                {
                    model.LangGuid = ds.Tables[0].Rows[0]["LangGuid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkTitle"] != null && ds.Tables[0].Rows[0]["LinkTitle"].ToString() != "")
                {
                    model.LinkTitle = ds.Tables[0].Rows[0]["LinkTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortOrder"].ToString() != "")
                {
                    model.SortOrder = int.Parse(ds.Tables[0].Rows[0]["SortOrder"].ToString());
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
        /// 从缓存中得到一个对象实体
        /// </summary>
        public Model.CMS.Aboutus GetModelByCache(int ID)
        {
            string CacheKey = "AboutusModel-" + ID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetModelByID(ID);
                    if (objModel != null)
                    {
                        int ModelCache = ECP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        ECP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.CMS.Aboutus)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.Aboutus> GetList(string strWhere)
        {
            DataSet ds = GetDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Aboutus> modelList = new List<Model.CMS.Aboutus>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Aboutus model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Aboutus();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["LinkTitle"] != null && dt.Rows[n]["LinkTitle"].ToString() != "")
                    {
                        model.LinkTitle = dt.Rows[n]["LinkTitle"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                     if (dt.Rows[n]["SortOrder"] != null && dt.Rows[n]["SortOrder"].ToString() != "")
                    {
                        model.SortOrder = int.Parse(dt.Rows[n]["SortOrder"].ToString());
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
        /// <summary>
        /// 获得数据列表 DataSet
        /// </summary>
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CmsAboutus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SortOrder ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM CmsAboutus ");
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
        public IList<Model.CMS.Aboutus> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = GetListDataSetByPage(strWhere, startIndex, endIndex);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Aboutus> modelList = new List<Model.CMS.Aboutus>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Aboutus model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Aboutus();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["LinkTitle"] != null && dt.Rows[n]["LinkTitle"].ToString() != "")
                    {
                        model.LinkTitle = dt.Rows[n]["LinkTitle"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["SortOrder"] != null && dt.Rows[n]["SortOrder"].ToString() != "")
                    {
                        model.SortOrder = int.Parse(dt.Rows[n]["SortOrder"].ToString());
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
            strSql.Append("order by T.SortOrder ");
            strSql.Append(")AS Row, T.*  from CmsAboutus T ");
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
        public IList<Model.CMS.Aboutus> GetTop(int Top, string strWhere)
        {
            DataSet ds = GetTopDataSet(Top, strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Aboutus> modelList = new List<Model.CMS.Aboutus>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Aboutus model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Aboutus();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["LinkTitle"] != null && dt.Rows[n]["LinkTitle"].ToString() != "")
                    {
                        model.LinkTitle = dt.Rows[n]["LinkTitle"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["SortOrder"] != null && dt.Rows[n]["SortOrder"].ToString() != "")
                    {
                        model.SortOrder = int.Parse(dt.Rows[n]["SortOrder"].ToString());
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

        public DataSet GetTopDataSet(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM CmsAboutus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SortOrder");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        public IList<Model.CMS.Aboutus> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Aboutus> modelList = new List<Model.CMS.Aboutus>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Aboutus model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Aboutus();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["LinkTitle"] != null && dt.Rows[n]["LinkTitle"].ToString() != "")
                    {
                        model.LinkTitle = dt.Rows[n]["LinkTitle"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["SortOrder"] != null && dt.Rows[n]["SortOrder"].ToString() != "")
                    {
                        model.SortOrder = int.Parse(dt.Rows[n]["SortOrder"].ToString());
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
        public DataSet GetDataSetByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby + " desc ");
            }
            else
            {
                strSql.Append("order by T.SortOrder desc");
            }
            strSql.Append(")AS Row, T.*  from CmsAboutus T ");
            if (!string.IsNullOrEmpty(LangCode.Trim()))
            {
                strSql.Append(" WHERE T.LanguageCode=@LanguageCode ");
                SqlParameter[] parameters = {
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50)
                 };
                parameters[0].Value = LangCode;
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据Language获得前几行数据
        /// </summary>
        public IList<Model.CMS.Aboutus> GetTopByLangCode(int Top, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(Top, orderby, LangCode);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Aboutus> modelList = new List<Model.CMS.Aboutus>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Aboutus model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Aboutus();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["LinkTitle"] != null && dt.Rows[n]["LinkTitle"].ToString() != "")
                    {
                        model.LinkTitle = dt.Rows[n]["LinkTitle"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["SortOrder"] != null && dt.Rows[n]["SortOrder"].ToString() != "")
                    {
                        model.SortOrder = int.Parse(dt.Rows[n]["SortOrder"].ToString());
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
        public DataSet GetDataSetByLangCode(int Top, string orderby, string LangCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM CmsAboutus ");
            if (LangCode.Trim() != "")
            {
                strSql.Append(" WHERE LanguageCode=@LanguageCode ");
                SqlParameter[] parameters = {
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50)
                 };
                parameters[0].Value = LangCode;
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by " + orderby + " desc ");
            }
            else
            {
                strSql.Append("order by ID desc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion Method
    }
}
