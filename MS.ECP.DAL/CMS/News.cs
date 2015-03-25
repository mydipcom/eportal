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

    public class News : INews
    {
        public bool Add(MS.ECP.Model.CMS.News model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CmsNews(");
            builder.Append("Guid,LangGuid,LanguageCode,Title,Content,CreateDate,ModifyDate,Status,IssueDate,Level,Keywords,Description,SeoTitle,Url,Specification)");
            builder.Append(" values (");
            builder.Append("@Guid,@LangGuid,@LanguageCode,@Title,@Content,@CreateDate,@ModifyDate,@Status,@IssueDate,@Level,@Keywords,@Description,@SeoTitle,@Url,@Specification)");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@Title", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@CreateDate", SqlDbType.DateTime), new SqlParameter("@ModifyDate", SqlDbType.DateTime), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@IssueDate", SqlDbType.DateTime), new SqlParameter("@Level", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1), new SqlParameter("@Specification", SqlDbType.NVarChar) };
            cmdParms[0].Value = Guid.NewGuid().ToString();
            if ((model.LangGuid == null) || (model.LangGuid == ""))
            {
                cmdParms[1].Value = Guid.NewGuid().ToString();
            }
            else
            {
                cmdParms[1].Value = model.LangGuid;
            }
            cmdParms[2].Value = model.LanguageCode;
            cmdParms[3].Value = model.Title;
            cmdParms[4].Value = model.Content;
            cmdParms[5].Value = DateTime.Now;
            cmdParms[6].Value = DateTime.Now;
            cmdParms[7].Value = 1;
            cmdParms[8].Value = DateTime.Now;
            cmdParms[9].Value = 0;
            cmdParms[10].Value = model.Keywords;
            cmdParms[11].Value = model.Description;
            cmdParms[12].Value = model.SeoTitle;
            cmdParms[13].Value = model.Url;
            cmdParms[14].Value = model.Specification;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Add(NewsInput model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CmsNews_Campaign(");
            builder.Append("[LangGuid],[Inputtitle],[InputType],[IsAllowNull],[InputName],[InputValue])");
            builder.Append(" values (");
            builder.Append("@LangGuid,@Inputtitle,@InputType,@IsAllowNull,@InputName,@InputValue)");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar), new SqlParameter("@Inputtitle", SqlDbType.NVarChar), new SqlParameter("@InputType", SqlDbType.Int), new SqlParameter("@IsAllowNull", SqlDbType.Bit), new SqlParameter("@InputName", SqlDbType.NVarChar), new SqlParameter("@InputValue", SqlDbType.NVarChar) };
            cmdParms[0].Value = model.LangGuid;
            cmdParms[1].Value = model.Inputtitle;
            cmdParms[2].Value = model.InputType;
            cmdParms[3].Value = model.IsAllowNull;
            cmdParms[4].Value = model.InputName;
            cmdParms[5].Value = model.InputValue;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsNews ");
            builder.Append(" where ID=@ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteByLangGuid(string langGuid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsNews ");
            builder.Append(" where LangGuid=@LangGuid ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8) };
            cmdParms[0].Value = langGuid;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteInput(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsNews_Campaign ");
            builder.Append(" where ID=@ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsNews ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (DbHelperSQL.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CmsNews");
            builder.Append(" where ID=@ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return DbHelperSQL.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM CmsNews ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by CreateDate desc");
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
            builder.Append(" FROM CmsNews ");
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
            builder.Append(")AS Row, T.*  from CmsNews T ");
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

        public MS.ECP.Model.CMS.News GetDefaultModelByLang(string LanguageCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsNews ");
            builder.Append(" where LanguageCode=@LanguageCode ");
            builder.Append(" order by CreateDate desc  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = LanguageCode;
            MS.ECP.Model.CMS.News news = new MS.ECP.Model.CMS.News();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                news.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                news.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                news.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                news.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Title"] != null) && (set.Tables[0].Rows[0]["Title"].ToString() != ""))
            {
                news.Title = set.Tables[0].Rows[0]["Title"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                news.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            news.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            news.ModifyDate = DateTime.Parse(set.Tables[0].Rows[0]["ModifyDate"].ToString());
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                news.Status = int.Parse(set.Tables[0].Rows[0]["Status"].ToString());
            }
            if (set.Tables[0].Rows[0]["IssueDate"] == null)
            {
                news.IssueDate = DateTime.Parse(set.Tables[0].Rows[0]["IssueDate"].ToString());
            }
            if (set.Tables[0].Rows[0]["Level"].ToString() != "")
            {
                news.Level = int.Parse(set.Tables[0].Rows[0]["Level"].ToString());
            }
            news.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            news.Description = set.Tables[0].Rows[0]["Description"].ToString();
            news.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            news.Url = set.Tables[0].Rows[0]["Url"].ToString();
            news.Specification = set.Tables[0].Rows[0]["Specification"].ToString();
            return news;
        }

        public IList<MS.ECP.Model.CMS.News> GetList(string strWhere)
        {
            DataTable table = this.GetDataSet(strWhere).Tables[0];
            IList<MS.ECP.Model.CMS.News> list = new List<MS.ECP.Model.CMS.News>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.News item = new MS.ECP.Model.CMS.News();
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
                    if ((table.Rows[i]["Title"] != null) && (table.Rows[i]["Title"].ToString() != ""))
                    {
                        item.Title = table.Rows[i]["Title"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    item.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                    item.ModifyDate = DateTime.Parse(table.Rows[i]["ModifyDate"].ToString());
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = int.Parse(table.Rows[i]["Status"].ToString());
                    }
                    if ((table.Rows[i]["IssueDate"] == null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.IssueDate = DateTime.Parse(table.Rows[i]["IssueDate"].ToString());
                    }
                    if ((table.Rows[i]["Level"] != null) && (table.Rows[i]["Level"].ToString() != ""))
                    {
                        item.Level = int.Parse(table.Rows[i]["Level"].ToString());
                    }
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    item.Specification = table.Rows[i]["Specification"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<MS.ECP.Model.CMS.News> GetList(int Top, string strWhere)
        {
            DataTable table = this.GetListDataSet(Top, strWhere).Tables[0];
            IList<MS.ECP.Model.CMS.News> list = new List<MS.ECP.Model.CMS.News>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.News item = new MS.ECP.Model.CMS.News();
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
                    if ((table.Rows[i]["Title"] != null) && (table.Rows[i]["Title"].ToString() != ""))
                    {
                        item.Title = table.Rows[i]["Title"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    item.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                    item.ModifyDate = DateTime.Parse(table.Rows[i]["ModifyDate"].ToString());
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = int.Parse(table.Rows[i]["Status"].ToString());
                    }
                    if ((table.Rows[i]["IssueDate"] == null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.IssueDate = DateTime.Parse(table.Rows[i]["IssueDate"].ToString());
                    }
                    if ((table.Rows[i]["Level"] != null) && (table.Rows[i]["Level"].ToString() != ""))
                    {
                        item.Level = int.Parse(table.Rows[i]["Level"].ToString());
                    }
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    item.Specification = table.Rows[i]["Specification"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<MS.ECP.Model.CMS.News> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataTable table = this.GetListDataSetByPage(strWhere, startIndex, endIndex).Tables[0];
            IList<MS.ECP.Model.CMS.News> list = new List<MS.ECP.Model.CMS.News>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.News item = new MS.ECP.Model.CMS.News();
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
                    if ((table.Rows[i]["Title"] != null) && (table.Rows[i]["Title"].ToString() != ""))
                    {
                        item.Title = table.Rows[i]["Title"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    item.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                    item.ModifyDate = DateTime.Parse(table.Rows[i]["ModifyDate"].ToString());
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = int.Parse(table.Rows[i]["Status"].ToString());
                    }
                    if ((table.Rows[i]["IssueDate"] == null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.IssueDate = DateTime.Parse(table.Rows[i]["IssueDate"].ToString());
                    }
                    if ((table.Rows[i]["Level"] != null) && (table.Rows[i]["Level"].ToString() != ""))
                    {
                        item.Level = int.Parse(table.Rows[i]["Level"].ToString());
                    }
                    StringBuilder builder = new StringBuilder();
                    builder.Append("select *  ");
                    builder.Append(" from CmsNews_Campaign ");
                    builder.Append(string.Format(" where LangGuid='{0}' ", item.LangGuid));
                    DataTable table2 = DbHelperSQL.Query(builder.ToString()).Tables[0];
                    for (int j = 0; j < table2.Rows.Count; j++)
                    {
                        DataRow row = table2.Rows[j];
                        NewsInput input = new NewsInput
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            Inputtitle = row["Inputtitle"].ToString(),
                            InputType = int.Parse(row["InputType"].ToString()),
                            IsAllowNull = bool.Parse(row["IsAllowNull"].ToString()),
                            InputName = row["InputName"].ToString(),
                            InputValue = (row["InputValue"] ?? "").ToString()
                        };
                        item.Inputs.Add(input);
                    }
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    item.Specification = table.Rows[i]["Specification"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public DataSet GetListDataSet(int Top, string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            if (Top > 0)
            {
                builder.Append(" top " + Top.ToString());
            }
            builder.Append(" * ");
            builder.Append(" FROM CmsNews ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by CreateDate desc");
            return DbHelperSQL.Query(builder.ToString());
        }

        public DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT  *  FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            builder.Append("order by T.CreateDate desc");
            builder.Append(")AS Row, T.*  from CmsNews T ");
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
            return DbHelperSQL.GetMaxID("ID", "CmsNews");
        }

        public MS.ECP.Model.CMS.News GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsNews ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            MS.ECP.Model.CMS.News news = new MS.ECP.Model.CMS.News();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                news.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                news.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                news.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                news.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Title"] != null) && (set.Tables[0].Rows[0]["Title"].ToString() != ""))
            {
                news.Title = set.Tables[0].Rows[0]["Title"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                news.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            news.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            news.ModifyDate = DateTime.Parse(set.Tables[0].Rows[0]["ModifyDate"].ToString());
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                news.Status = int.Parse(set.Tables[0].Rows[0]["Status"].ToString());
            }
            if (set.Tables[0].Rows[0]["IssueDate"] == null)
            {
                news.IssueDate = DateTime.Parse(set.Tables[0].Rows[0]["IssueDate"].ToString());
            }
            if (set.Tables[0].Rows[0]["Level"].ToString() != "")
            {
                news.Level = int.Parse(set.Tables[0].Rows[0]["Level"].ToString());
            }
            news.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            news.Description = set.Tables[0].Rows[0]["Description"].ToString();
            news.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            news.Url = set.Tables[0].Rows[0]["Url"].ToString();
            news.Specification = set.Tables[0].Rows[0]["Specification"].ToString();
            return news;
        }

        public MS.ECP.Model.CMS.News GetModelByCache(int ID)
        {
            string cacheKey = "NewsModel-" + ID;
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
            return (MS.ECP.Model.CMS.News)cache;
        }

        public MS.ECP.Model.CMS.News GetModelByGuid(string langGuid, string languageId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsNews ");
            builder.Append(" where LangGuid=@LangGuid ");
            builder.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = langGuid;
            cmdParms[1].Value = languageId;
            MS.ECP.Model.CMS.News news = new MS.ECP.Model.CMS.News();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                news.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                news.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                news.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                news.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Title"] != null) && (set.Tables[0].Rows[0]["Title"].ToString() != ""))
            {
                news.Title = set.Tables[0].Rows[0]["Title"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                news.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            news.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            news.ModifyDate = DateTime.Parse(set.Tables[0].Rows[0]["ModifyDate"].ToString());
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                news.Status = int.Parse(set.Tables[0].Rows[0]["Status"].ToString());
            }
            if (set.Tables[0].Rows[0]["IssueDate"] == null)
            {
                news.IssueDate = DateTime.Parse(set.Tables[0].Rows[0]["IssueDate"].ToString());
            }
            if (set.Tables[0].Rows[0]["Level"].ToString() != "")
            {
                news.Level = int.Parse(set.Tables[0].Rows[0]["Level"].ToString());
            }
            news.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            news.Description = set.Tables[0].Rows[0]["Description"].ToString();
            news.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            news.Url = set.Tables[0].Rows[0]["Url"].ToString();
            news.Specification = set.Tables[0].Rows[0]["Specification"].ToString();
            builder.Clear();
            builder.Append("select *  ");
            builder.Append(" from CmsNews_Campaign ");
            builder.Append(string.Format(" where LangGuid='{0}' ", langGuid));
            DataTable table = DbHelperSQL.Query(builder.ToString()).Tables[0];
            if (table.Rows.Count != 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    NewsInput item = new NewsInput
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Inputtitle = row["Inputtitle"].ToString(),
                        InputType = int.Parse(row["InputType"].ToString()),
                        IsAllowNull = bool.Parse(row["IsAllowNull"].ToString()),
                        InputName = row["InputName"].ToString(),
                        InputValue = (row["InputValue"] ?? "").ToString()
                    };
                    news.Inputs.Add(item);
                }
            }
            return news;
        }

        public MS.ECP.Model.CMS.News GetNewestModelByLangCode(string LanguageCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select top 1 *  ");
            builder.Append("  from CmsNews ");
            builder.Append(" where LanguageCode=@LanguageCode ");
            builder.Append(" order by CreateDate desc  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = LanguageCode;
            MS.ECP.Model.CMS.News news = new MS.ECP.Model.CMS.News();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                news.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                news.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                news.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                news.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Title"] != null) && (set.Tables[0].Rows[0]["Title"].ToString() != ""))
            {
                news.Title = set.Tables[0].Rows[0]["Title"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                news.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            news.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            news.ModifyDate = DateTime.Parse(set.Tables[0].Rows[0]["ModifyDate"].ToString());
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                news.Status = int.Parse(set.Tables[0].Rows[0]["Status"].ToString());
            }
            if (set.Tables[0].Rows[0]["IssueDate"] == null)
            {
                news.IssueDate = DateTime.Parse(set.Tables[0].Rows[0]["IssueDate"].ToString());
            }
            if (set.Tables[0].Rows[0]["Level"].ToString() != "")
            {
                news.Level = int.Parse(set.Tables[0].Rows[0]["Level"].ToString());
            }
            news.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            news.Description = set.Tables[0].Rows[0]["Description"].ToString();
            news.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            news.Url = set.Tables[0].Rows[0]["Url"].ToString();
            news.Specification = set.Tables[0].Rows[0]["Specification"].ToString();
            return news;
        }

        public NewsInput GetNewsInputModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsNews_Campaign ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            NewsInput input = new NewsInput();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                input.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Inputtitle"] != null) && (set.Tables[0].Rows[0]["Inputtitle"].ToString() != ""))
            {
                input.Inputtitle = set.Tables[0].Rows[0]["Inputtitle"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                input.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["InputType"] != null) && (set.Tables[0].Rows[0]["InputType"].ToString() != ""))
            {
                input.InputType = int.Parse(set.Tables[0].Rows[0]["InputType"].ToString());
            }
            if ((set.Tables[0].Rows[0]["IsAllowNull"] != null) && (set.Tables[0].Rows[0]["IsAllowNull"].ToString() != ""))
            {
                input.IsAllowNull = bool.Parse(set.Tables[0].Rows[0]["IsAllowNull"].ToString());
            }
            if ((set.Tables[0].Rows[0]["InputName"] != null) && (set.Tables[0].Rows[0]["InputName"].ToString() != ""))
            {
                input.InputName = set.Tables[0].Rows[0]["InputName"].ToString();
            }
            if ((set.Tables[0].Rows[0]["InputValue"] != null) && (set.Tables[0].Rows[0]["InputValue"].ToString() != ""))
            {
                input.InputValue = set.Tables[0].Rows[0]["InputValue"].ToString();
            }
            return input;
        }

        public IList<MS.ECP.Model.CMS.News> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            DataTable table = this.GetDataSetByLangCode(Top, orderby, LangCode).Tables[0];
            IList<MS.ECP.Model.CMS.News> list = new List<MS.ECP.Model.CMS.News>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.News item = new MS.ECP.Model.CMS.News();
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
                    if ((table.Rows[i]["Title"] != null) && (table.Rows[i]["Title"].ToString() != ""))
                    {
                        item.Title = table.Rows[i]["Title"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    item.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                    item.ModifyDate = DateTime.Parse(table.Rows[i]["ModifyDate"].ToString());
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = int.Parse(table.Rows[i]["Status"].ToString());
                    }
                    if ((table.Rows[i]["IssueDate"] == null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.IssueDate = DateTime.Parse(table.Rows[i]["IssueDate"].ToString());
                    }
                    if ((table.Rows[i]["Level"] != null) && (table.Rows[i]["Level"].ToString() != ""))
                    {
                        item.Level = int.Parse(table.Rows[i]["Level"].ToString());
                    }
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    item.Specification = table.Rows[i]["Specification"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<MS.ECP.Model.CMS.News> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataTable table = this.GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode).Tables[0];
            IList<MS.ECP.Model.CMS.News> list = new List<MS.ECP.Model.CMS.News>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.News item = new MS.ECP.Model.CMS.News();
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
                    if ((table.Rows[i]["Title"] != null) && (table.Rows[i]["Title"].ToString() != ""))
                    {
                        item.Title = table.Rows[i]["Title"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    item.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                    item.ModifyDate = DateTime.Parse(table.Rows[i]["ModifyDate"].ToString());
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = int.Parse(table.Rows[i]["Status"].ToString());
                    }
                    if ((table.Rows[i]["IssueDate"] == null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.IssueDate = DateTime.Parse(table.Rows[i]["IssueDate"].ToString());
                    }
                    if ((table.Rows[i]["Level"] != null) && (table.Rows[i]["Level"].ToString() != ""))
                    {
                        item.Level = int.Parse(table.Rows[i]["Level"].ToString());
                    }
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    item.Specification = table.Rows[i]["Specification"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM CmsNews ");
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

        public bool Update(MS.ECP.Model.CMS.News model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsNews set ");
            builder.Append(" Guid = @Guid , ");
            builder.Append(" LangGuid = @LangGuid , ");
            builder.Append(" LanguageCode = @LanguageCode , ");
            builder.Append(" Title = @Title , ");
            builder.Append(" Content = @Content , ");
            builder.Append(" ModifyDate = @ModifyDate , ");
            builder.Append(" Status = @Status , ");
            builder.Append(" IssueDate = @IssueDate , ");
            builder.Append(" Level = @Level , ");
            builder.Append(" Keywords = @Keywords , ");
            builder.Append(" Description = @Description , ");
            builder.Append(" SeoTitle = @SeoTitle ,  ");
            builder.Append(" Url = @Url , ");
            builder.Append(" Specification = @Specification  ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.VarChar, 50), new SqlParameter("@Title", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@ModifyDate", SqlDbType.DateTime), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@IssueDate", SqlDbType.DateTime), new SqlParameter("@Level", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 50), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1), new SqlParameter("@Specification", SqlDbType.NVarChar) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Guid;
            cmdParms[2].Value = model.LangGuid;
            cmdParms[3].Value = model.LanguageCode;
            cmdParms[4].Value = model.Title;
            cmdParms[5].Value = model.Content;
            cmdParms[6].Value = DateTime.Now;
            cmdParms[7].Value = 1;
            cmdParms[8].Value = DateTime.Now;
            cmdParms[9].Value = 0;
            cmdParms[10].Value = model.Keywords;
            cmdParms[11].Value = model.Description;
            cmdParms[12].Value = model.SeoTitle;
            cmdParms[13].Value = model.Url;
            cmdParms[14].Value = model.Specification;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Update(NewsInput model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsNews_Campaign set ");
            builder.Append(" Inputtitle = @Inputtitle , ");
            builder.Append(" InputType = @InputType , ");
            builder.Append(" IsAllowNull = @IsAllowNull ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Inputtitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@InputType", SqlDbType.Int), new SqlParameter("@IsAllowNull", SqlDbType.Bit) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Inputtitle;
            cmdParms[2].Value = model.InputType;
            cmdParms[3].Value = model.IsAllowNull;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateSeo(MS.ECP.Model.CMS.News model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsNews set ");
            builder.Append(" Keywords = @Keywords , ");
            builder.Append(" Description = @Description , ");
            builder.Append(" SeoTitle = @SeoTitle ,  ");
            builder.Append(" Url = @Url , Specification= @Specification ");
            builder.Append(" where ID=@ID  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1), new SqlParameter("@Specification", SqlDbType.NVarChar) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Keywords;
            cmdParms[2].Value = model.Description;
            cmdParms[3].Value = model.SeoTitle;
            cmdParms[4].Value = model.Url;
            cmdParms[5].Value = model.Specification;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
