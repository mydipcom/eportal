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
    public partial class Job : IJob
    {
        public Job() { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CmsJob");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CmsJob");
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
        public bool Add(Model.CMS.Job model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CmsJob(");
            strSql.Append("Guid,LangGuid,LanguageCode,JobTitle,NeedNum,Workplace,Salary,LanguageRequired,JobBligation,JobDesc,OrderNum,CreateDate,Keywords,Description,SeoTitle,Url");
            strSql.Append(") values (");
            strSql.Append("@Guid,@LangGuid,@LanguageCode,@JobTitle,@NeedNum,@Workplace,@Salary,@LanguageRequired,@JobBligation,@JobDesc,@OrderNum,@CreateDate,@Keywords,@Description,@SeoTitle,@Url");
            strSql.Append(") ");

            SqlParameter[] parameters = {   
                        new SqlParameter("@Guid",SqlDbType.NVarChar,1000),  
                        new SqlParameter("@LangGuid",SqlDbType.NVarChar,1000),  
                        new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@JobTitle", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@NeedNum", SqlDbType.Int,4),   
                        new SqlParameter("@Workplace", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Salary", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@LanguageRequired", SqlDbType.NVarChar,200), 
                        new SqlParameter("@JobBligation", SqlDbType.NText) ,            
                        new SqlParameter("@JobDesc", SqlDbType.NText) ,   
                        new SqlParameter("@OrderNum", SqlDbType.Int,4),
                        new SqlParameter("@CreateDate",SqlDbType.DateTime),
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
            parameters[3].Value = model.JobTitle;
            parameters[4].Value = model.NeedNum;
            parameters[5].Value = model.Workplace;
            parameters[6].Value = model.Salary;
            parameters[7].Value = model.LanguageRequired;
            parameters[8].Value = model.JobBligation;
            parameters[9].Value = model.JobDesc;
            parameters[10].Value = model.OrderNum;
            parameters[11].Value = DateTime.Now;
            parameters[12].Value = model.Keywords;
            parameters[13].Value = model.Description;
            parameters[14].Value = model.SeoTitle;
            parameters[15].Value = model.Url;

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
        public bool Update(Model.CMS.Job model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsJob set ");
            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" LangGuid = @LangGuid , ");
            strSql.Append(" LanguageCode = @LanguageCode , ");
            strSql.Append(" JobTitle = @JobTitle , ");
            strSql.Append(" NeedNum = @NeedNum ,  ");
            strSql.Append(" Workplace = @Workplace , ");
            strSql.Append(" Salary = @Salary , ");
            strSql.Append(" LanguageRequired = @LanguageRequired , ");
            strSql.Append(" JobBligation = @JobBligation , ");
            strSql.Append(" JobDesc = @JobDesc , ");
            strSql.Append(" OrderNum = @OrderNum , ");
            strSql.Append(" Keywords = @Keywords , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" SeoTitle = @SeoTitle ,  ");
            strSql.Append(" Url = @Url  ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Guid",SqlDbType.NVarChar,1000),
                        new SqlParameter("@LangGuid", SqlDbType.NVarChar,1000) ,
                        new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@JobTitle", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@NeedNum", SqlDbType.Int,4),   
                        new SqlParameter("@Workplace", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Salary", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@LanguageRequired", SqlDbType.NVarChar,200), 
                        new SqlParameter("@JobBligation", SqlDbType.NText) ,            
                        new SqlParameter("@JobDesc", SqlDbType.NText) ,            
                        new SqlParameter("@OrderNum", SqlDbType.Int,4) ,
                        new SqlParameter("@Keywords", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Description", SqlDbType.NText) ,            
                        new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,225) 
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Guid;
            parameters[2].Value = model.LangGuid;
            parameters[3].Value = model.LanguageCode;
            parameters[4].Value = model.JobTitle;
            parameters[5].Value = model.NeedNum;
            parameters[6].Value = model.Workplace;
            parameters[7].Value = model.Salary;
            parameters[8].Value = model.LanguageRequired;
            parameters[9].Value = model.JobBligation;
            parameters[10].Value = model.JobDesc;
            parameters[11].Value = model.OrderNum;
            parameters[12].Value = model.Keywords;
            parameters[13].Value = model.Description;
            parameters[14].Value = model.SeoTitle;
            parameters[15].Value = model.Url;
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
        public bool UpdateSeo(Model.CMS.Job model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsJob set ");
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
            strSql.Append("delete from CmsJob ");
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
            strSql.Append("delete from CmsJob ");
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
            strSql.Append("delete from CmsJob ");
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
        public Model.CMS.Job GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsJob ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;


            Model.CMS.Job model = new Model.CMS.Job();
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
                if (ds.Tables[0].Rows[0]["JobTitle"] != null && ds.Tables[0].Rows[0]["JobTitle"].ToString() != "")
                {
                    model.JobTitle = ds.Tables[0].Rows[0]["JobTitle"].ToString();
                }
                model.NeedNum = int.Parse(ds.Tables[0].Rows[0]["NeedNum"].ToString());
                model.Workplace = ds.Tables[0].Rows[0]["Workplace"].ToString();
                model.Salary = ds.Tables[0].Rows[0]["Salary"].ToString();
                model.LanguageRequired = ds.Tables[0].Rows[0]["LanguageRequired"].ToString();

                if (ds.Tables[0].Rows[0]["JobBligation"] != null && ds.Tables[0].Rows[0]["JobBligation"].ToString() != "")
                {
                    model.JobBligation = ds.Tables[0].Rows[0]["JobBligation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["JobDesc"] != null && ds.Tables[0].Rows[0]["JobDesc"].ToString() != "")
                {
                    model.JobDesc = ds.Tables[0].Rows[0]["JobDesc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderNum"].ToString() != "")
                {
                    model.OrderNum = int.Parse(ds.Tables[0].Rows[0]["OrderNum"].ToString());
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public Model.CMS.Job GetModelByGuid(string langGuid, string languageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsJob ");
            strSql.Append(" where LangGuid=@LangGuid ");
            strSql.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LangGuid", SqlDbType.NVarChar,1000) ,
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,
            };
            parameters[0].Value = langGuid;
            parameters[1].Value = languageId;


            Model.CMS.Job model = new Model.CMS.Job();
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
                if (ds.Tables[0].Rows[0]["JobTitle"] != null && ds.Tables[0].Rows[0]["JobTitle"].ToString() != "")
                {
                    model.JobTitle = ds.Tables[0].Rows[0]["JobTitle"].ToString();
                }
                model.NeedNum = int.Parse(ds.Tables[0].Rows[0]["NeedNum"].ToString());
                model.Workplace = ds.Tables[0].Rows[0]["Workplace"].ToString();
                model.Salary = ds.Tables[0].Rows[0]["Salary"].ToString();
                model.LanguageRequired = ds.Tables[0].Rows[0]["LanguageRequired"].ToString();

                if (ds.Tables[0].Rows[0]["JobBligation"] != null && ds.Tables[0].Rows[0]["JobBligation"].ToString() != "")
                {
                    model.JobBligation = ds.Tables[0].Rows[0]["JobBligation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["JobDesc"] != null && ds.Tables[0].Rows[0]["JobDesc"].ToString() != "")
                {
                    model.JobDesc = ds.Tables[0].Rows[0]["JobDesc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderNum"].ToString() != "")
                {
                    model.OrderNum = int.Parse(ds.Tables[0].Rows[0]["OrderNum"].ToString());
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public Model.CMS.Job GetDefaultModelByLang(string LanguageCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsJob ");
            strSql.Append(" where LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = LanguageCode;

            Model.CMS.Job model = new Model.CMS.Job();
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
                if (ds.Tables[0].Rows[0]["JobTitle"] != null && ds.Tables[0].Rows[0]["JobTitle"].ToString() != "")
                {
                    model.JobTitle = ds.Tables[0].Rows[0]["JobTitle"].ToString();
                }
                model.NeedNum = int.Parse(ds.Tables[0].Rows[0]["NeedNum"].ToString());
                model.Workplace = ds.Tables[0].Rows[0]["Workplace"].ToString();
                model.Salary = ds.Tables[0].Rows[0]["Salary"].ToString();
                model.LanguageRequired = ds.Tables[0].Rows[0]["LanguageRequired"].ToString();

                if (ds.Tables[0].Rows[0]["JobBligation"] != null && ds.Tables[0].Rows[0]["JobBligation"].ToString() != "")
                {
                    model.JobBligation = ds.Tables[0].Rows[0]["JobBligation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["JobDesc"] != null && ds.Tables[0].Rows[0]["JobDesc"].ToString() != "")
                {
                    model.JobDesc = ds.Tables[0].Rows[0]["JobDesc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderNum"].ToString() != "")
                {
                    model.OrderNum = int.Parse(ds.Tables[0].Rows[0]["OrderNum"].ToString());
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
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
        public Model.CMS.Job GetModelByCache(int ID)
        {
            string CacheKey = "JobModel-" + ID;
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
            return (Model.CMS.Job)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.Job> GetList(string strWhere)
        {
            DataSet ds = GetDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Job> modelList = new List<Model.CMS.Job>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Job model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.Job();

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
                    if (dt.Rows[n]["JobTitle"] != null && dt.Rows[n]["JobTitle"].ToString() != "")
                    {
                        model.JobTitle = dt.Rows[n]["JobTitle"].ToString();
                    }
                    model.NeedNum = int.Parse(dt.Rows[0]["NeedNum"].ToString());
                    model.Workplace = dt.Rows[0]["Workplace"].ToString();
                    model.Salary = dt.Rows[0]["Salary"].ToString();
                    model.LanguageRequired = dt.Rows[0]["LanguageRequired"].ToString();
                    if (dt.Rows[n]["JobBligation"] != null && dt.Rows[n]["JobBligation"].ToString() != "")
                    {
                        model.JobBligation = dt.Rows[n]["JobBligation"].ToString();
                    }
                    if (dt.Rows[n]["JobDesc"] != null && dt.Rows[n]["JobDesc"].ToString() != "")
                    {
                        model.JobDesc = dt.Rows[n]["JobDesc"].ToString();
                    }
                    model.OrderNum = int.Parse(dt.Rows[n]["OrderNum"].ToString());
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
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
            strSql.Append(" FROM CmsJob ");
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
            strSql.Append("select count(1) FROM CmsJob ");
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
        public IList<Model.CMS.Job> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = GetListDataSetByPage(strWhere, startIndex, endIndex);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Job> modelList = new List<Model.CMS.Job>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Job model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ECP.Model.CMS.Job();

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
                    if (dt.Rows[n]["JobTitle"] != null && dt.Rows[n]["JobTitle"].ToString() != "")
                    {
                        model.JobTitle = dt.Rows[n]["JobTitle"].ToString();
                    }
                    model.NeedNum = int.Parse(dt.Rows[n]["NeedNum"].ToString());
                    model.Workplace = dt.Rows[n]["Workplace"].ToString();
                    model.Salary = dt.Rows[n]["Salary"].ToString();
                    model.LanguageRequired = dt.Rows[n]["LanguageRequired"].ToString();
                    if (dt.Rows[n]["JobBligation"] != null && dt.Rows[n]["JobBligation"].ToString() != "")
                    {
                        model.JobBligation = dt.Rows[n]["JobBligation"].ToString();
                    }
                    if (dt.Rows[n]["JobDesc"] != null && dt.Rows[n]["JobDesc"].ToString() != "")
                    {
                        model.JobDesc = dt.Rows[n]["JobDesc"].ToString();
                    }
                    model.OrderNum = int.Parse(dt.Rows[n]["OrderNum"].ToString());
                    model.CreateDate = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString());
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
            strSql.Append(")AS Row, T.*  from CmsJob T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        public IList<Model.CMS.Job> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Job> modelList = new List<Model.CMS.Job>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Job model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ECP.Model.CMS.Job();

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
                    if (dt.Rows[n]["JobTitle"] != null && dt.Rows[n]["JobTitle"].ToString() != "")
                    {
                        model.JobTitle = dt.Rows[n]["JobTitle"].ToString();
                    }
                    model.NeedNum = int.Parse(dt.Rows[n]["NeedNum"].ToString());
                    model.Workplace = dt.Rows[n]["Workplace"].ToString();
                    model.Salary = dt.Rows[n]["Salary"].ToString();
                    model.LanguageRequired = dt.Rows[n]["LanguageRequired"].ToString();
                    if (dt.Rows[n]["JobBligation"] != null && dt.Rows[n]["JobBligation"].ToString() != "")
                    {
                        model.JobBligation = dt.Rows[n]["JobBligation"].ToString();
                    }
                    if (dt.Rows[n]["JobDesc"] != null && dt.Rows[n]["JobDesc"].ToString() != "")
                    {
                        model.JobDesc = dt.Rows[n]["JobDesc"].ToString();
                    }
                    model.OrderNum = int.Parse(dt.Rows[n]["OrderNum"].ToString());
                    model.CreateDate = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString());
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from CmsJob T ");
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
        public IList<Model.CMS.Job> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(Top, orderby, LangCode);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.Job> modelList = new List<Model.CMS.Job>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.Job model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ECP.Model.CMS.Job();

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
                    if (dt.Rows[n]["JobTitle"] != null && dt.Rows[n]["JobTitle"].ToString() != "")
                    {
                        model.JobTitle = dt.Rows[n]["JobTitle"].ToString();
                    }
                    model.NeedNum = int.Parse(dt.Rows[n]["NeedNum"].ToString());
                    model.Workplace = dt.Rows[n]["Workplace"].ToString();
                    model.Salary = dt.Rows[n]["Salary"].ToString();
                    model.LanguageRequired = dt.Rows[n]["LanguageRequired"].ToString();
                    if (dt.Rows[n]["JobBligation"] != null && dt.Rows[n]["JobBligation"].ToString() != "")
                    {
                        model.JobBligation = dt.Rows[n]["JobBligation"].ToString();
                    }
                    if (dt.Rows[n]["JobDesc"] != null && dt.Rows[n]["JobDesc"].ToString() != "")
                    {
                        model.JobDesc = dt.Rows[n]["JobDesc"].ToString();
                    }
                    model.OrderNum = int.Parse(dt.Rows[n]["OrderNum"].ToString());
                    model.CreateDate = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString());
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
            strSql.Append(" FROM CmsJob ");
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
