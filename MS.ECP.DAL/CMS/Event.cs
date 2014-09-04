using MS.ECP.IDAL.CMS;
using MS.ECP.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MS.ECP.DAL.CMS
{
     /// <summary>
    /// 数据访问类:Event
    /// </summary>
    public partial class Event : IEvent
    {

        public Event()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CmsEvent");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CmsEvent");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.CMS.Event model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CmsEvent(");
            strSql.Append("Guid,LangGuid,LanguageCode,Title,Content,CreateDate,ModifyDate,Status,IssueDate,Level)");
            strSql.Append(" values (");
            strSql.Append("@Guid,@LangGuid,@LanguageCode,@Title,@Content,@CreateDate,@ModifyDate,@Status,@IssueDate,@Level)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Guid",SqlDbType.NVarChar,1000),  
                    new SqlParameter("@LangGuid",SqlDbType.NVarChar,1000),          
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@Title", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Content", SqlDbType.NText),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@ModifyDate", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@IssueDate", SqlDbType.DateTime),
                    new SqlParameter("@Level", SqlDbType.Int,4)
            };

            parameters[0].Value = Guid.NewGuid().ToString();
            if (model.LangGuid == null || model.LangGuid == "")
            {
                parameters[1].Value = Guid.NewGuid().ToString();
            }
            else
            {
                parameters[1].Value = model.LangGuid;
            }

            parameters[2].Value = model.LanguageCode;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Content;
            parameters[5].Value = DateTime.Now;
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = 1;
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = 0;

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
        public bool Update(Model.CMS.Event model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsEvent set ");
            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" LangGuid = @LangGuid , ");
            strSql.Append(" LanguageCode = @LanguageCode , ");
            strSql.Append(" Title = @Title , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" ModifyDate = @ModifyDate , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" IssueDate = @IssueDate , ");
            strSql.Append(" Level = @Level ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4) ,
                    new SqlParameter("@Guid",SqlDbType.NVarChar,1000),  
                    new SqlParameter("@LangGuid",SqlDbType.NVarChar,1000),    
                    new SqlParameter("@LanguageCode", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.NVarChar,1000), 
                    new SqlParameter("@Content", SqlDbType.NText),
                    new SqlParameter("@ModifyDate", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@IssueDate", SqlDbType.DateTime),
                    new SqlParameter("@Level", SqlDbType.Int,4)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Guid;
            parameters[2].Value = model.LangGuid;
            parameters[3].Value = model.LanguageCode;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Content;
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = 1;
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = 0;

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
        public bool UpdateSeo(Model.CMS.Event model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsEvent set ");
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

        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CmsEvent ");
            strSql.Append(" where ID=@ID");
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
            strSql.Append("delete from CmsEvent ");
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
            strSql.Append("delete from CmsEvent ");
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
        /// 得到一个对象实体
        /// </summary>
        public Model.CMS.Event GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsEvent ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4) ,
            };
            parameters[0].Value = ID;

            Model.CMS.Event model = new Model.CMS.Event();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                model.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueDate"] == null)
                {
                    model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据LangGuid得到一个对象实体
        /// </summary>
        public Model.CMS.Event GetModelByGuid(string langGuid, string languageId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsEvent ");
            strSql.Append(" where LangGuid=@LangGuid ");
            strSql.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LangGuid", SqlDbType.NVarChar,1000) ,
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,
            };
            parameters[0].Value = langGuid;
            parameters[1].Value = languageId;

            Model.CMS.Event model = new Model.CMS.Event();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                model.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueDate"] == null)
                {
                    model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 根据语言得到一个对象实体
        /// </summary>
        public Model.CMS.Event GetDefaultModelByLang(string LanguageCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsEvent ");
            strSql.Append(" where LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = LanguageCode;

            Model.CMS.Event model = new Model.CMS.Event();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                model.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueDate"] == null)
                {
                    model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }

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
        public Model.CMS.Event GetModelByCache(int ID)
        {
            string CacheKey = "EventModel-" + ID;
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
            return (Model.CMS.Event)objModel;
        }

        //// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.Event> GetList(string strWhere)
        {
            DataSet ds = GetDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Event> modelList = new List<Model.CMS.Event>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Event model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Event();

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
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }

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
            strSql.Append(" FROM CmsEvent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }
            strSql.Append(" order by CreateDate desc ");
            
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM CmsEvent ");
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
        public IList<Model.CMS.Event> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = GetListDataSetByPage(strWhere, startIndex, endIndex);
            DataTable dt = ds.Tables[0];
            IList<Model.CMS.Event> modelList = new List<Model.CMS.Event>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Event model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Event();

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
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }

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
            strSql.Append("order by T.CreateDate desc");
            strSql.Append(")AS Row, T.*  from CmsEvent T ");
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
        public IList<Model.CMS.Event> GetList(int Top, string strWhere)
        {
            DataSet ds = GetListDataSet(Top, strWhere);
            DataTable dt = ds.Tables[0];
            IList<Model.CMS.Event> modelList = new List<Model.CMS.Event>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Event model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Event();

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
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public DataSet GetListDataSet(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM CmsEvent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CreateDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据Language分页获得数据列表
        /// </summary>
        public IList<Model.CMS.Event> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode);
            DataTable dt = ds.Tables[0];
            IList<Model.CMS.Event> modelList = new List<Model.CMS.Event>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Event model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Event();

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
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }

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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from CmsEvent T ");
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
        public IList<Model.CMS.Event> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(Top, orderby, LangCode);
            DataTable dt = ds.Tables[0];
            IList<Model.CMS.Event> modelList = new List<Model.CMS.Event>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Event model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Event();

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
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }

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
            strSql.Append(" FROM CmsEvent ");
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

        #endregion  Method
    }
}
