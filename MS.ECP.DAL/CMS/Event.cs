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

    public class Event : IEvent
    {
        public bool Add(CmsEvent model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CmsEvent(");
            builder.Append("Guid,LangGuid,LanguageCode,Title,Content,CreateDate,ModifyDate,Status,IssueDate,Level)");
            builder.Append(" values (");
            builder.Append("@Guid,@LangGuid,@LanguageCode,@Title,@Content,@CreateDate,@ModifyDate,@Status,@IssueDate,@Level)");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@Title", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@CreateDate", SqlDbType.DateTime), new SqlParameter("@ModifyDate", SqlDbType.DateTime), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@IssueDate", SqlDbType.DateTime), new SqlParameter("@Level", SqlDbType.Int, 4) };
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
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsEvent ");
            builder.Append(" where ID=@ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteByLangGuid(string langGuid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsEvent ");
            builder.Append(" where LangGuid=@LangGuid ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8) };
            cmdParms[0].Value = langGuid;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsEvent ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (DbHelperSQL.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CmsEvent");
            builder.Append(" where ID=@ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return DbHelperSQL.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM CmsEvent ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by CreateDate desc ");
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
            builder.Append(" FROM CmsEvent ");
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
            builder.Append(")AS Row, T.*  from CmsEvent T ");
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

        public CmsEvent GetDefaultModelByLang(string LanguageCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsEvent ");
            builder.Append(" where LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = LanguageCode;
            CmsEvent event2 = new CmsEvent();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                event2.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                event2.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                event2.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                event2.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Title"] != null) && (set.Tables[0].Rows[0]["Title"].ToString() != ""))
            {
                event2.Title = set.Tables[0].Rows[0]["Title"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                event2.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            event2.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            event2.ModifyDate = DateTime.Parse(set.Tables[0].Rows[0]["ModifyDate"].ToString());
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                event2.Status = int.Parse(set.Tables[0].Rows[0]["Status"].ToString());
            }
            if (set.Tables[0].Rows[0]["IssueDate"] == null)
            {
                event2.IssueDate = DateTime.Parse(set.Tables[0].Rows[0]["IssueDate"].ToString());
            }
            if (set.Tables[0].Rows[0]["Level"].ToString() != "")
            {
                event2.Level = int.Parse(set.Tables[0].Rows[0]["Level"].ToString());
            }
            return event2;
        }

        public IList<CmsEvent> GetList(string strWhere)
        {
            DataTable table = this.GetDataSet(strWhere).Tables[0];
            IList<CmsEvent> list = new List<CmsEvent>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    CmsEvent item = new CmsEvent();
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
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<CmsEvent> GetList(int Top, string strWhere)
        {
            DataTable table = this.GetListDataSet(Top, strWhere).Tables[0];
            IList<CmsEvent> list = new List<CmsEvent>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    CmsEvent item = new CmsEvent();
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
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<CmsEvent> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataTable table = this.GetListDataSetByPage(strWhere, startIndex, endIndex).Tables[0];
            IList<CmsEvent> list = new List<CmsEvent>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    CmsEvent item = new CmsEvent();
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
            builder.Append(" FROM CmsEvent ");
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
            builder.Append(")AS Row, T.*  from CmsEvent T ");
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
            return DbHelperSQL.GetMaxID("ID", "CmsEvent");
        }

        public CmsEvent GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsEvent ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            CmsEvent event2 = new CmsEvent();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                event2.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                event2.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                event2.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                event2.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Title"] != null) && (set.Tables[0].Rows[0]["Title"].ToString() != ""))
            {
                event2.Title = set.Tables[0].Rows[0]["Title"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                event2.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            event2.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            event2.ModifyDate = DateTime.Parse(set.Tables[0].Rows[0]["ModifyDate"].ToString());
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                event2.Status = int.Parse(set.Tables[0].Rows[0]["Status"].ToString());
            }
            if (set.Tables[0].Rows[0]["IssueDate"] == null)
            {
                event2.IssueDate = DateTime.Parse(set.Tables[0].Rows[0]["IssueDate"].ToString());
            }
            if (set.Tables[0].Rows[0]["Level"].ToString() != "")
            {
                event2.Level = int.Parse(set.Tables[0].Rows[0]["Level"].ToString());
            }
            return event2;
        }

        public CmsEvent GetModelByCache(int ID)
        {
            string cacheKey = "EventModel-" + ID;
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
            return (CmsEvent)cache;
        }

        public CmsEvent GetModelByGuid(string langGuid, string languageId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsEvent ");
            builder.Append(" where LangGuid=@LangGuid ");
            builder.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = langGuid;
            cmdParms[1].Value = languageId;
            CmsEvent event2 = new CmsEvent();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                event2.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                event2.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                event2.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                event2.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Title"] != null) && (set.Tables[0].Rows[0]["Title"].ToString() != ""))
            {
                event2.Title = set.Tables[0].Rows[0]["Title"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                event2.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            event2.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            event2.ModifyDate = DateTime.Parse(set.Tables[0].Rows[0]["ModifyDate"].ToString());
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                event2.Status = int.Parse(set.Tables[0].Rows[0]["Status"].ToString());
            }
            if (set.Tables[0].Rows[0]["IssueDate"] == null)
            {
                event2.IssueDate = DateTime.Parse(set.Tables[0].Rows[0]["IssueDate"].ToString());
            }
            if (set.Tables[0].Rows[0]["Level"].ToString() != "")
            {
                event2.Level = int.Parse(set.Tables[0].Rows[0]["Level"].ToString());
            }
            return event2;
        }

        public IList<CmsEvent> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            DataTable table = this.GetDataSetByLangCode(Top, orderby, LangCode).Tables[0];
            IList<CmsEvent> list = new List<CmsEvent>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    CmsEvent item = new CmsEvent();
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
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<CmsEvent> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataTable table = this.GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode).Tables[0];
            IList<CmsEvent> list = new List<CmsEvent>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    CmsEvent item = new CmsEvent();
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
                    list.Add(item);
                }
            }
            return list;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM CmsEvent ");
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

        public bool Update(CmsEvent model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsEvent set ");
            builder.Append(" Guid = @Guid , ");
            builder.Append(" LangGuid = @LangGuid , ");
            builder.Append(" LanguageCode = @LanguageCode , ");
            builder.Append(" Title = @Title , ");
            builder.Append(" Content = @Content , ");
            builder.Append(" ModifyDate = @ModifyDate , ");
            builder.Append(" Status = @Status , ");
            builder.Append(" IssueDate = @IssueDate , ");
            builder.Append(" Level = @Level ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.VarChar, 50), new SqlParameter("@Title", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@ModifyDate", SqlDbType.DateTime), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@IssueDate", SqlDbType.DateTime), new SqlParameter("@Level", SqlDbType.Int, 4) };
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
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateSeo(CmsEvent model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsEvent set ");
            builder.Append(" Keywords = @Keywords , ");
            builder.Append(" Description = @Description , ");
            builder.Append(" SeoTitle = @SeoTitle ,  ");
            builder.Append(" Url = @Url  ");
            builder.Append(" where ID=@ID  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 50), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            cmdParms[0].Value = model.ID;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
