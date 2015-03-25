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

    public class AboutusDal : IAboutusDal
    {
        public bool Add(Aboutus model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CmsAboutus(");
            builder.Append("Guid,LangGuid,LanguageCode,LinkTitle,Content,Status,SortOrder,Keywords,Description,SeoTitle,Url");
            builder.Append(") values (");
            builder.Append("@Guid,@LangGuid,@LanguageCode,@LinkTitle,@Content,@Status,@SortOrder,@Keywords,@Description,@SeoTitle,@Url");
            builder.Append(") ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@LinkTitle", SqlDbType.NVarChar, 250), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@SortOrder", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
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
            cmdParms[3].Value = model.LinkTitle;
            cmdParms[4].Value = model.Content;
            cmdParms[5].Value = model.Status;
            cmdParms[6].Value = model.SortOrder;
            cmdParms[7].Value = model.Keywords;
            cmdParms[8].Value = model.Description;
            cmdParms[9].Value = model.SeoTitle;
            cmdParms[10].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsAboutus ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteByLangGuid(string langGuid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsAboutus ");
            builder.Append(" where LangGuid=@LangGuid ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8) };
            cmdParms[0].Value = langGuid;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsAboutus ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (DbHelperSQL.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CmsAboutus");
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
            builder.Append(" FROM CmsAboutus ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by SortOrder ");
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
            builder.Append(" FROM CmsAboutus ");
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
                builder.Append("order by T.SortOrder desc");
            }
            builder.Append(")AS Row, T.*  from CmsAboutus T ");
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

        public IList<Aboutus> GetList(string strWhere)
        {
            DataTable table = this.GetDataSet(strWhere).Tables[0];
            IList<Aboutus> list = new List<Aboutus>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Aboutus item = new Aboutus();
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
                    if ((table.Rows[i]["LinkTitle"] != null) && (table.Rows[i]["LinkTitle"].ToString() != ""))
                    {
                        item.LinkTitle = table.Rows[i]["LinkTitle"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = new int?(int.Parse(table.Rows[i]["Status"].ToString()));
                    }
                    if ((table.Rows[i]["SortOrder"] != null) && (table.Rows[i]["SortOrder"].ToString() != ""))
                    {
                        item.SortOrder = new int?(int.Parse(table.Rows[i]["SortOrder"].ToString()));
                    }
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<Aboutus> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataTable table = this.GetListDataSetByPage(strWhere, startIndex, endIndex).Tables[0];
            IList<Aboutus> list = new List<Aboutus>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Aboutus item = new Aboutus();
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
                    if ((table.Rows[i]["LinkTitle"] != null) && (table.Rows[i]["LinkTitle"].ToString() != ""))
                    {
                        item.LinkTitle = table.Rows[i]["LinkTitle"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = new int?(int.Parse(table.Rows[i]["Status"].ToString()));
                    }
                    if ((table.Rows[i]["SortOrder"] != null) && (table.Rows[i]["SortOrder"].ToString() != ""))
                    {
                        item.SortOrder = new int?(int.Parse(table.Rows[i]["SortOrder"].ToString()));
                    }
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
            builder.Append("order by T.SortOrder ");
            builder.Append(")AS Row, T.*  from CmsAboutus T ");
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
            return DbHelperSQL.GetMaxID("ID", "CmsAboutus");
        }

        public Aboutus GetModelByCache(int ID)
        {
            string cacheKey = "AboutusModel-" + ID;
            object cache = DataCache.GetCache(cacheKey);
            if (cache == null)
            {
                try
                {
                    cache = this.GetModelByID(ID);
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
            return (Aboutus)cache;
        }

        public Aboutus GetModelByID(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsAboutus ");
            builder.Append(" where ID=@ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            Aboutus aboutus = new Aboutus();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                aboutus.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                aboutus.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                aboutus.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                aboutus.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LinkTitle"] != null) && (set.Tables[0].Rows[0]["LinkTitle"].ToString() != ""))
            {
                aboutus.LinkTitle = set.Tables[0].Rows[0]["LinkTitle"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                aboutus.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                aboutus.Status = new int?(int.Parse(set.Tables[0].Rows[0]["Status"].ToString()));
            }
            if (set.Tables[0].Rows[0]["SortOrder"].ToString() != "")
            {
                aboutus.SortOrder = new int?(int.Parse(set.Tables[0].Rows[0]["SortOrder"].ToString()));
            }
            aboutus.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            aboutus.Description = set.Tables[0].Rows[0]["Description"].ToString();
            aboutus.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            aboutus.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return aboutus;
        }

        public Aboutus GetModelByLangCode(string LanguageCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsAboutus ");
            builder.Append(" where LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = LanguageCode;
            Aboutus aboutus = new Aboutus();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                aboutus.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                aboutus.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                aboutus.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                aboutus.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LinkTitle"] != null) && (set.Tables[0].Rows[0]["LinkTitle"].ToString() != ""))
            {
                aboutus.LinkTitle = set.Tables[0].Rows[0]["LinkTitle"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                aboutus.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                aboutus.Status = new int?(int.Parse(set.Tables[0].Rows[0]["Status"].ToString()));
            }
            if (set.Tables[0].Rows[0]["SortOrder"].ToString() != "")
            {
                aboutus.SortOrder = new int?(int.Parse(set.Tables[0].Rows[0]["SortOrder"].ToString()));
            }
            aboutus.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            aboutus.Description = set.Tables[0].Rows[0]["Description"].ToString();
            aboutus.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            aboutus.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return aboutus;
        }

        public Aboutus GetModelByLangGuidAndLangCode(string langGuid, string languageId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsAboutus ");
            builder.Append(" where LangGuid=@LangGuid ");
            builder.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = langGuid;
            cmdParms[1].Value = languageId;
            Aboutus aboutus = new Aboutus();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                aboutus.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                aboutus.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LangGuid"] != null) && (set.Tables[0].Rows[0]["LangGuid"].ToString() != ""))
            {
                aboutus.LangGuid = set.Tables[0].Rows[0]["LangGuid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                aboutus.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LinkTitle"] != null) && (set.Tables[0].Rows[0]["LinkTitle"].ToString() != ""))
            {
                aboutus.LinkTitle = set.Tables[0].Rows[0]["LinkTitle"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Content"] != null) && (set.Tables[0].Rows[0]["Content"].ToString() != ""))
            {
                aboutus.Content = set.Tables[0].Rows[0]["Content"].ToString();
            }
            if (set.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                aboutus.Status = new int?(int.Parse(set.Tables[0].Rows[0]["Status"].ToString()));
            }
            if (set.Tables[0].Rows[0]["SortOrder"].ToString() != "")
            {
                aboutus.SortOrder = new int?(int.Parse(set.Tables[0].Rows[0]["SortOrder"].ToString()));
            }
            aboutus.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            aboutus.Description = set.Tables[0].Rows[0]["Description"].ToString();
            aboutus.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            aboutus.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return aboutus;
        }

        public IList<Aboutus> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataTable table = this.GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode).Tables[0];
            IList<Aboutus> list = new List<Aboutus>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Aboutus item = new Aboutus();
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
                    if ((table.Rows[i]["LinkTitle"] != null) && (table.Rows[i]["LinkTitle"].ToString() != ""))
                    {
                        item.LinkTitle = table.Rows[i]["LinkTitle"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = new int?(int.Parse(table.Rows[i]["Status"].ToString()));
                    }
                    if ((table.Rows[i]["SortOrder"] != null) && (table.Rows[i]["SortOrder"].ToString() != ""))
                    {
                        item.SortOrder = new int?(int.Parse(table.Rows[i]["SortOrder"].ToString()));
                    }
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
            builder.Append("select count(1) FROM CmsAboutus ");
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

        public IList<Aboutus> GetTop(int Top, string strWhere)
        {
            DataTable table = this.GetTopDataSet(Top, strWhere).Tables[0];
            IList<Aboutus> list = new List<Aboutus>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Aboutus item = new Aboutus();
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
                    if ((table.Rows[i]["LinkTitle"] != null) && (table.Rows[i]["LinkTitle"].ToString() != ""))
                    {
                        item.LinkTitle = table.Rows[i]["LinkTitle"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = new int?(int.Parse(table.Rows[i]["Status"].ToString()));
                    }
                    if ((table.Rows[i]["SortOrder"] != null) && (table.Rows[i]["SortOrder"].ToString() != ""))
                    {
                        item.SortOrder = new int?(int.Parse(table.Rows[i]["SortOrder"].ToString()));
                    }
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public IList<Aboutus> GetTopByLangCode(int Top, string orderby, string LangCode)
        {
            DataTable table = this.GetDataSetByLangCode(Top, orderby, LangCode).Tables[0];
            IList<Aboutus> list = new List<Aboutus>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Aboutus item = new Aboutus();
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
                    if ((table.Rows[i]["LinkTitle"] != null) && (table.Rows[i]["LinkTitle"].ToString() != ""))
                    {
                        item.LinkTitle = table.Rows[i]["LinkTitle"].ToString();
                    }
                    if ((table.Rows[i]["Content"] != null) && (table.Rows[i]["Content"].ToString() != ""))
                    {
                        item.Content = table.Rows[i]["Content"].ToString();
                    }
                    if ((table.Rows[i]["Status"] != null) && (table.Rows[i]["Status"].ToString() != ""))
                    {
                        item.Status = new int?(int.Parse(table.Rows[i]["Status"].ToString()));
                    }
                    if ((table.Rows[i]["SortOrder"] != null) && (table.Rows[i]["SortOrder"].ToString() != ""))
                    {
                        item.SortOrder = new int?(int.Parse(table.Rows[i]["SortOrder"].ToString()));
                    }
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public DataSet GetTopDataSet(int Top, string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            if (Top > 0)
            {
                builder.Append(" top " + Top.ToString());
            }
            builder.Append(" * ");
            builder.Append(" FROM CmsAboutus ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by SortOrder");
            return DbHelperSQL.Query(builder.ToString());
        }

        public bool Update(Aboutus model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsAboutus set ");
            builder.Append(" Guid = @Guid , ");
            builder.Append(" LangGuid = @LangGuid , ");
            builder.Append(" LanguageCode = @LanguageCode , ");
            builder.Append(" LinkTitle = @LinkTitle , ");
            builder.Append(" Content = @Content ,  ");
            builder.Append(" Status = @Status , ");
            builder.Append(" SortOrder = @SortOrder ");
            builder.Append(" where ID=@ID  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LangGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@LinkTitle", SqlDbType.NVarChar, 250), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@SortOrder", SqlDbType.Int, 4) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Guid;
            cmdParms[2].Value = model.LangGuid;
            cmdParms[3].Value = model.LanguageCode;
            cmdParms[4].Value = model.LinkTitle;
            cmdParms[5].Value = model.Content;
            cmdParms[6].Value = model.Status;
            cmdParms[7].Value = model.SortOrder;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateSeo(Aboutus model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsAboutus set ");
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
