namespace MS.ECP.DAL.CMS
{
    using MS.ECP.Common;
    using MS.ECP.IDAL.CMS;
    using MS.ECP.Model.CMS;
    using MS.ECP.Utility;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class Job : IJob
    {
        public bool Add(MS.ECP.Model.CMS.Job model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CmsJob(");
            builder.Append("Guid,LangGuid,LanguageCode,JobTitle,NeedNum,Workplace,Salary,LanguageRequired,JobBligation,JobDesc,OrderNum,CreateDate,Keywords,Description,SeoTitle,Url");
            builder.Append(") values (");
            builder.Append("@Guid,@LangGuid,@LanguageCode,@JobTitle,@NeedNum,@Workplace,@Salary,@LanguageRequired,@JobBligation,@JobDesc,@OrderNum,@CreateDate,@Keywords,@Description,@SeoTitle,@Url");
            builder.Append(") ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@JobTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@NeedNum", SqlDbType.Int, 4), new SqlParameter("@Workplace", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Salary", SqlDbType.NVarChar, 200), new SqlParameter("@LanguageRequired", SqlDbType.NVarChar, 200), new SqlParameter("@JobBligation", SqlDbType.NText), new SqlParameter("@JobDesc", SqlDbType.NText), new SqlParameter("@OrderNum", SqlDbType.Int, 4), new SqlParameter("@CreateDate", SqlDbType.DateTime), new SqlParameter("@Keywords", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            cmdParms[0].Value = Guid.NewGuid().ToString();
            if (model.LangGuid == null)
            {
                cmdParms[1].Value = Guid.NewGuid().ToString();
            }
            else
            {
                cmdParms[1].Value = model.LangGuid;
            }
            cmdParms[2].Value = model.LanguageCode;
            cmdParms[3].Value = model.JobTitle;
            cmdParms[4].Value = model.NeedNum;
            cmdParms[5].Value = model.Workplace;
            cmdParms[6].Value = model.Salary;
            cmdParms[7].Value = model.LanguageRequired;
            cmdParms[8].Value = model.JobBligation;
            cmdParms[9].Value = model.JobDesc;
            cmdParms[10].Value = model.OrderNum;
            cmdParms[11].Value = DateTime.Now;
            cmdParms[12].Value = model.Keywords;
            cmdParms[13].Value = model.Description;
            cmdParms[14].Value = model.SeoTitle;
            cmdParms[15].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsJob ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteByLangGuid(string langGuid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsJob ");
            builder.Append(" where LangGuid=@LangGuid ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8) };
            cmdParms[0].Value = langGuid;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsJob ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (DbHelperSQL.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CmsJob");
            builder.Append(" where ");
            builder.Append(" ID = @ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return DbHelperSQL.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM CmsJob ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(builder.ToString());
        }

        public DataSet GetDataSetByLangCode(int Top, string orderby, string LangCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            if (Top > 0)
            {
                builder.Append(" top " + Top.ToString());
            }
            builder.Append(" * ");
            builder.Append(" FROM CmsJob ");
            if (LangCode.Trim() != "")
            {
                builder.Append(" WHERE LanguageCode=@LanguageCode ");
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
                parameterArray[0].Value = LangCode;
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append("order by " + orderby + " desc ");
            }
            else
            {
                builder.Append("order by ID desc");
            }
            return DbHelperSQL.Query(builder.ToString());
        }

        public DataSet GetDataSetByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append("order by T." + orderby + " desc ");
            }
            else
            {
                builder.Append("order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from CmsJob T ");
            if (!string.IsNullOrEmpty(LangCode.Trim()))
            {
                builder.Append(" WHERE T.LanguageCode=@LanguageCode ");
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
                parameterArray[0].Value = LangCode;
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(builder.ToString());
        }

        public MS.ECP.Model.CMS.Job GetDefaultModelByLang(string LanguageCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsJob ");
            builder.Append(" where LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = LanguageCode;
            MS.ECP.Model.CMS.Job job = new MS.ECP.Model.CMS.Job();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                job.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                job.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                job.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                job.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["JobTitle"] != null) && (set.Tables[0].Rows[0]["JobTitle"].ToString() != ""))
            {
                job.JobTitle = set.Tables[0].Rows[0]["JobTitle"].ToString();
            }
            job.NeedNum = int.Parse(set.Tables[0].Rows[0]["NeedNum"].ToString());
            job.Workplace = set.Tables[0].Rows[0]["Workplace"].ToString();
            job.Salary = set.Tables[0].Rows[0]["Salary"].ToString();
            job.LanguageRequired = set.Tables[0].Rows[0]["LanguageRequired"].ToString();
            if ((set.Tables[0].Rows[0]["JobBligation"] != null) && (set.Tables[0].Rows[0]["JobBligation"].ToString() != ""))
            {
                job.JobBligation = set.Tables[0].Rows[0]["JobBligation"].ToString();
            }
            if ((set.Tables[0].Rows[0]["JobDesc"] != null) && (set.Tables[0].Rows[0]["JobDesc"].ToString() != ""))
            {
                job.JobDesc = set.Tables[0].Rows[0]["JobDesc"].ToString();
            }
            if (set.Tables[0].Rows[0]["OrderNum"].ToString() != "")
            {
                job.OrderNum = int.Parse(set.Tables[0].Rows[0]["OrderNum"].ToString());
            }
            job.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            job.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            job.Description = set.Tables[0].Rows[0]["Description"].ToString();
            job.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            job.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return job;
        }

        public IList<MS.ECP.Model.CMS.Job> GetList(string strWhere)
        {
            DataTable table = this.GetDataSet(strWhere).Tables[0];
            IList<MS.ECP.Model.CMS.Job> list = new List<MS.ECP.Model.CMS.Job>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.Job item = new MS.ECP.Model.CMS.Job();
                    if ((table.Rows[i]["ID"] != null) && (table.Rows[i]["ID"].ToString() != ""))
                    {
                        item.ID = int.Parse(table.Rows[i]["ID"].ToString());
                    }
                    if ((table.Rows[i]["Guid"] != null) && (table.Rows[i]["Guid"].ToString() != ""))
                    {
                        item.Guid = table.Rows[i]["Guid"].ToString();
                    }
                    if ((table.Rows[i]["LangGuid"] != null) && (table.Rows[i]["LangGuid"].ToString() != ""))
                    {
                        item.LangGuid = table.Rows[i]["LangGuid"].ToString();
                    }
                    if ((table.Rows[i]["LanguageCode"] != null) && (table.Rows[i]["LanguageCode"].ToString() != ""))
                    {
                        item.LanguageCode = table.Rows[i]["LanguageCode"].ToString();
                    }
                    if ((table.Rows[i]["JobTitle"] != null) && (table.Rows[i]["JobTitle"].ToString() != ""))
                    {
                        item.JobTitle = table.Rows[i]["JobTitle"].ToString();
                    }
                    item.NeedNum = int.Parse(table.Rows[0]["NeedNum"].ToString());
                    item.Workplace = table.Rows[0]["Workplace"].ToString();
                    item.Salary = table.Rows[0]["Salary"].ToString();
                    item.LanguageRequired = table.Rows[0]["LanguageRequired"].ToString();
                    if ((table.Rows[i]["JobBligation"] != null) && (table.Rows[i]["JobBligation"].ToString() != ""))
                    {
                        item.JobBligation = table.Rows[i]["JobBligation"].ToString();
                    }
                    if ((table.Rows[i]["JobDesc"] != null) && (table.Rows[i]["JobDesc"].ToString() != ""))
                    {
                        item.JobDesc = table.Rows[i]["JobDesc"].ToString();
                    }
                    item.OrderNum = int.Parse(table.Rows[i]["OrderNum"].ToString());
                    item.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<MS.ECP.Model.CMS.Job> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataTable table = this.GetListDataSetByPage(strWhere, startIndex, endIndex).Tables[0];
            IList<MS.ECP.Model.CMS.Job> list = new List<MS.ECP.Model.CMS.Job>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.Job item = new MS.ECP.Model.CMS.Job();
                    if ((table.Rows[i]["ID"] != null) && (table.Rows[i]["ID"].ToString() != ""))
                    {
                        item.ID = int.Parse(table.Rows[i]["ID"].ToString());
                    }
                    if ((table.Rows[i]["Guid"] != null) && (table.Rows[i]["Guid"].ToString() != ""))
                    {
                        item.Guid = table.Rows[i]["Guid"].ToString();
                    }
                    if ((table.Rows[i]["LangGuid"] != null) && (table.Rows[i]["LangGuid"].ToString() != ""))
                    {
                        item.LangGuid = table.Rows[i]["LangGuid"].ToString();
                    }
                    if ((table.Rows[i]["LanguageCode"] != null) && (table.Rows[i]["LanguageCode"].ToString() != ""))
                    {
                        item.LanguageCode = table.Rows[i]["LanguageCode"].ToString();
                    }
                    if ((table.Rows[i]["JobTitle"] != null) && (table.Rows[i]["JobTitle"].ToString() != ""))
                    {
                        item.JobTitle = table.Rows[i]["JobTitle"].ToString();
                    }
                    item.NeedNum = int.Parse(table.Rows[i]["NeedNum"].ToString());
                    item.Workplace = table.Rows[i]["Workplace"].ToString();
                    item.Salary = table.Rows[i]["Salary"].ToString();
                    item.LanguageRequired = table.Rows[i]["LanguageRequired"].ToString();
                    if ((table.Rows[i]["JobBligation"] != null) && (table.Rows[i]["JobBligation"].ToString() != ""))
                    {
                        item.JobBligation = table.Rows[i]["JobBligation"].ToString();
                    }
                    if ((table.Rows[i]["JobDesc"] != null) && (table.Rows[i]["JobDesc"].ToString() != ""))
                    {
                        item.JobDesc = table.Rows[i]["JobDesc"].ToString();
                    }
                    item.OrderNum = int.Parse(table.Rows[i]["OrderNum"].ToString());
                    item.CreateDate = DateTime.Parse(table.Rows[0]["CreateDate"].ToString());
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT  *  FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            builder.Append("order by T.ID desc");
            builder.Append(")AS Row, T.*  from CmsJob T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CmsJob");
        }

        public MS.ECP.Model.CMS.Job GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsJob ");
            builder.Append(" where ID=@ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            MS.ECP.Model.CMS.Job job = new MS.ECP.Model.CMS.Job();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                job.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                job.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                job.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                job.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["JobTitle"] != null) && (set.Tables[0].Rows[0]["JobTitle"].ToString() != ""))
            {
                job.JobTitle = set.Tables[0].Rows[0]["JobTitle"].ToString();
            }
            job.NeedNum = int.Parse(set.Tables[0].Rows[0]["NeedNum"].ToString());
            job.Workplace = set.Tables[0].Rows[0]["Workplace"].ToString();
            job.Salary = set.Tables[0].Rows[0]["Salary"].ToString();
            job.LanguageRequired = set.Tables[0].Rows[0]["LanguageRequired"].ToString();
            if ((set.Tables[0].Rows[0]["JobBligation"] != null) && (set.Tables[0].Rows[0]["JobBligation"].ToString() != ""))
            {
                job.JobBligation = set.Tables[0].Rows[0]["JobBligation"].ToString();
            }
            if ((set.Tables[0].Rows[0]["JobDesc"] != null) && (set.Tables[0].Rows[0]["JobDesc"].ToString() != ""))
            {
                job.JobDesc = set.Tables[0].Rows[0]["JobDesc"].ToString();
            }
            if (set.Tables[0].Rows[0]["OrderNum"].ToString() != "")
            {
                job.OrderNum = int.Parse(set.Tables[0].Rows[0]["OrderNum"].ToString());
            }
            job.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            job.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            job.Description = set.Tables[0].Rows[0]["Description"].ToString();
            job.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            job.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return job;
        }

        public MS.ECP.Model.CMS.Job GetModelByCache(int ID)
        {
            string cacheKey = "JobModel-" + ID;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.GetModel(ID);
                    if (cache != null)
                    {
                        int configInt = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(cacheKey, cache, DateTime.Now.AddMinutes((double)configInt), TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (MS.ECP.Model.CMS.Job)cache;
        }

        public MS.ECP.Model.CMS.Job GetModelByGuid(string langGuid, string languageId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsJob ");
            builder.Append(" where LangGuid=@LangGuid ");
            builder.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = langGuid;
            cmdParms[1].Value = languageId;
            MS.ECP.Model.CMS.Job job = new MS.ECP.Model.CMS.Job();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                job.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                job.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                job.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                job.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["JobTitle"] != null) && (set.Tables[0].Rows[0]["JobTitle"].ToString() != ""))
            {
                job.JobTitle = set.Tables[0].Rows[0]["JobTitle"].ToString();
            }
            job.NeedNum = int.Parse(set.Tables[0].Rows[0]["NeedNum"].ToString());
            job.Workplace = set.Tables[0].Rows[0]["Workplace"].ToString();
            job.Salary = set.Tables[0].Rows[0]["Salary"].ToString();
            job.LanguageRequired = set.Tables[0].Rows[0]["LanguageRequired"].ToString();
            if ((set.Tables[0].Rows[0]["JobBligation"] != null) && (set.Tables[0].Rows[0]["JobBligation"].ToString() != ""))
            {
                job.JobBligation = set.Tables[0].Rows[0]["JobBligation"].ToString();
            }
            if ((set.Tables[0].Rows[0]["JobDesc"] != null) && (set.Tables[0].Rows[0]["JobDesc"].ToString() != ""))
            {
                job.JobDesc = set.Tables[0].Rows[0]["JobDesc"].ToString();
            }
            if (set.Tables[0].Rows[0]["OrderNum"].ToString() != "")
            {
                job.OrderNum = int.Parse(set.Tables[0].Rows[0]["OrderNum"].ToString());
            }
            job.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            job.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            job.Description = set.Tables[0].Rows[0]["Description"].ToString();
            job.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            job.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return job;
        }

        public IList<MS.ECP.Model.CMS.Job> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            DataTable table = this.GetDataSetByLangCode(Top, orderby, LangCode).Tables[0];
            IList<MS.ECP.Model.CMS.Job> list = new List<MS.ECP.Model.CMS.Job>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.Job item = new MS.ECP.Model.CMS.Job();
                    if ((table.Rows[i]["ID"] != null) && (table.Rows[i]["ID"].ToString() != ""))
                    {
                        item.ID = int.Parse(table.Rows[i]["ID"].ToString());
                    }
                    if ((table.Rows[i]["Guid"] != null) && (table.Rows[i]["Guid"].ToString() != ""))
                    {
                        item.Guid = table.Rows[i]["Guid"].ToString();
                    }
                    if ((table.Rows[i]["LangGuid"] != null) && (table.Rows[i]["LangGuid"].ToString() != ""))
                    {
                        item.LangGuid = table.Rows[i]["LangGuid"].ToString();
                    }
                    if ((table.Rows[i]["LanguageCode"] != null) && (table.Rows[i]["LanguageCode"].ToString() != ""))
                    {
                        item.LanguageCode = table.Rows[i]["LanguageCode"].ToString();
                    }
                    if ((table.Rows[i]["JobTitle"] != null) && (table.Rows[i]["JobTitle"].ToString() != ""))
                    {
                        item.JobTitle = table.Rows[i]["JobTitle"].ToString();
                    }
                    item.NeedNum = int.Parse(table.Rows[i]["NeedNum"].ToString());
                    item.Workplace = table.Rows[i]["Workplace"].ToString();
                    item.Salary = table.Rows[i]["Salary"].ToString();
                    item.LanguageRequired = table.Rows[i]["LanguageRequired"].ToString();
                    if ((table.Rows[i]["JobBligation"] != null) && (table.Rows[i]["JobBligation"].ToString() != ""))
                    {
                        item.JobBligation = table.Rows[i]["JobBligation"].ToString();
                    }
                    if ((table.Rows[i]["JobDesc"] != null) && (table.Rows[i]["JobDesc"].ToString() != ""))
                    {
                        item.JobDesc = table.Rows[i]["JobDesc"].ToString();
                    }
                    item.OrderNum = int.Parse(table.Rows[i]["OrderNum"].ToString());
                    item.CreateDate = DateTime.Parse(table.Rows[0]["CreateDate"].ToString());
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<MS.ECP.Model.CMS.Job> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataTable table = this.GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode).Tables[0];
            IList<MS.ECP.Model.CMS.Job> list = new List<MS.ECP.Model.CMS.Job>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.Job item = new MS.ECP.Model.CMS.Job();
                    if ((table.Rows[i]["ID"] != null) && (table.Rows[i]["ID"].ToString() != ""))
                    {
                        item.ID = int.Parse(table.Rows[i]["ID"].ToString());
                    }
                    if ((table.Rows[i]["Guid"] != null) && (table.Rows[i]["Guid"].ToString() != ""))
                    {
                        item.Guid = table.Rows[i]["Guid"].ToString();
                    }
                    if ((table.Rows[i]["LangGuid"] != null) && (table.Rows[i]["LangGuid"].ToString() != ""))
                    {
                        item.LangGuid = table.Rows[i]["LangGuid"].ToString();
                    }
                    if ((table.Rows[i]["LanguageCode"] != null) && (table.Rows[i]["LanguageCode"].ToString() != ""))
                    {
                        item.LanguageCode = table.Rows[i]["LanguageCode"].ToString();
                    }
                    if ((table.Rows[i]["JobTitle"] != null) && (table.Rows[i]["JobTitle"].ToString() != ""))
                    {
                        item.JobTitle = table.Rows[i]["JobTitle"].ToString();
                    }
                    item.NeedNum = int.Parse(table.Rows[i]["NeedNum"].ToString());
                    item.Workplace = table.Rows[i]["Workplace"].ToString();
                    item.Salary = table.Rows[i]["Salary"].ToString();
                    item.LanguageRequired = table.Rows[i]["LanguageRequired"].ToString();
                    if ((table.Rows[i]["JobBligation"] != null) && (table.Rows[i]["JobBligation"].ToString() != ""))
                    {
                        item.JobBligation = table.Rows[i]["JobBligation"].ToString();
                    }
                    if ((table.Rows[i]["JobDesc"] != null) && (table.Rows[i]["JobDesc"].ToString() != ""))
                    {
                        item.JobDesc = table.Rows[i]["JobDesc"].ToString();
                    }
                    item.OrderNum = int.Parse(table.Rows[i]["OrderNum"].ToString());
                    item.CreateDate = DateTime.Parse(table.Rows[0]["CreateDate"].ToString());
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM CmsJob ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = DbHelperSQL.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(MS.ECP.Model.CMS.Job model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsJob set ");
            builder.Append(" Guid = @Guid , ");
            builder.Append(" LangGuid = @LangGuid , ");
            builder.Append(" LanguageCode = @LanguageCode , ");
            builder.Append(" JobTitle = @JobTitle , ");
            builder.Append(" NeedNum = @NeedNum ,  ");
            builder.Append(" Workplace = @Workplace , ");
            builder.Append(" Salary = @Salary , ");
            builder.Append(" LanguageRequired = @LanguageRequired , ");
            builder.Append(" JobBligation = @JobBligation , ");
            builder.Append(" JobDesc = @JobDesc , ");
            builder.Append(" OrderNum = @OrderNum , ");
            builder.Append(" Keywords = @Keywords , ");
            builder.Append(" Description = @Description , ");
            builder.Append(" SeoTitle = @SeoTitle ,  ");
            builder.Append(" Url = @Url  ");
            builder.Append(" where ID=@ID  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@JobTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@NeedNum", SqlDbType.Int, 4), new SqlParameter("@Workplace", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Salary", SqlDbType.NVarChar, 200), new SqlParameter("@LanguageRequired", SqlDbType.NVarChar, 200), new SqlParameter("@JobBligation", SqlDbType.NText), new SqlParameter("@JobDesc", SqlDbType.NText), new SqlParameter("@OrderNum", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 50), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Guid;
            cmdParms[2].Value = model.LangGuid;
            cmdParms[3].Value = model.LanguageCode;
            cmdParms[4].Value = model.JobTitle;
            cmdParms[5].Value = model.NeedNum;
            cmdParms[6].Value = model.Workplace;
            cmdParms[7].Value = model.Salary;
            cmdParms[8].Value = model.LanguageRequired;
            cmdParms[9].Value = model.JobBligation;
            cmdParms[10].Value = model.JobDesc;
            cmdParms[11].Value = model.OrderNum;
            cmdParms[12].Value = model.Keywords;
            cmdParms[13].Value = model.Description;
            cmdParms[14].Value = model.SeoTitle;
            cmdParms[15].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateSeo(MS.ECP.Model.CMS.Job model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsJob set ");
            builder.Append(" Keywords = @Keywords , ");
            builder.Append(" Description = @Description , ");
            builder.Append(" SeoTitle = @SeoTitle ,  ");
            builder.Append(" Url = @Url  ");
            builder.Append(" where ID=@ID  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 50), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Keywords;
            cmdParms[2].Value = model.Description;
            cmdParms[3].Value = model.SeoTitle;
            cmdParms[4].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
