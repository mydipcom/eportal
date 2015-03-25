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

    public class PageContent : IPageContent
    {
        public bool Add(MS.ECP.Model.CMS.PageContent model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CmsPageContent(Guid,PageNumber,Item,ItemContent,LanguageCode,CategoryID,CreateDate,Keywords,Description,SeoTitle,Url ");
            builder.Append(") values (");
            builder.Append("@Guid,@PageNumber,@Item,@ItemContent,@LanguageCode,@CategoryID,@CreateDate,@Keywords,@Description,@SeoTitle,@Url");
            builder.Append(") ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@PageNumber", SqlDbType.Int, 4), new SqlParameter("@Item", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@ItemContent", SqlDbType.NText), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@CategoryID", SqlDbType.Int, 4), new SqlParameter("@CreateDate", SqlDbType.DateTime), new SqlParameter("@Keywords", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            if ((model.Guid == "") || (model.Guid == null))
            {
                cmdParms[0].Value = Guid.NewGuid().ToString();
            }
            else
            {
                cmdParms[0].Value = model.Guid;
            }
            cmdParms[1].Value = model.PageNumber;
            cmdParms[2].Value = model.Item;
            cmdParms[3].Value = model.ItemContent;
            cmdParms[4].Value = model.LanguageCode;
            cmdParms[5].Value = model.CategoryID;
            cmdParms[6].Value = DateTime.Now;
            cmdParms[7].Value = model.Keywords;
            cmdParms[8].Value = model.Description;
            cmdParms[9].Value = model.SeoTitle;
            cmdParms[10].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsPageContent ");
            builder.Append("where ID=@id");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            cmdParms[0].Value = id;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteByLangGuid(string langGuid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsPageContent ");
            builder.Append(" where Guid=@Guid ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8) };
            cmdParms[0].Value = langGuid;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string PageContentIDList)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsPageContent ");
            builder.Append("where ID in (" + PageContentIDList + ")");
            return (DbHelperSQL.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CmsPageContent");
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
            builder.Append(" FROM CmsPageContent ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(builder.ToString());
        }

        public MS.ECP.Model.CMS.PageContent GetDefaultModel(string ParentGuid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select p.CategoryID,p.Guid,p.LanguageCode,p.Item,p.ItemContent,c.Categoryname,p.PageNumber,p.CreateDate from CmsPageContent p ");
            builder.Append(" left join CmsCategory c  ");
            builder.Append(" on p.CategoryID = c.ID ");
            builder.Append(" where c.ParentGuid =@ParentGuid ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ParentGuid", SqlDbType.NVarChar, 0x3e8) };
            cmdParms[0].Value = ParentGuid;
            MS.ECP.Model.CMS.Category category = new MS.ECP.Model.CMS.Category();
            MS.ECP.Model.CMS.PageContent content = new MS.ECP.Model.CMS.PageContent();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["CategoryID"] != null) && (set.Tables[0].Rows[0]["CategoryID"].ToString() != ""))
            {
                content.CategoryID = Convert.ToInt32(set.Tables[0].Rows[0]["CategoryID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                content.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                content.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Item"] != null) && (set.Tables[0].Rows[0]["Item"].ToString() != ""))
            {
                content.Item = set.Tables[0].Rows[0]["Item"].ToString();
            }
            if ((set.Tables[0].Rows[0]["ItemContent"] != null) && (set.Tables[0].Rows[0]["ItemContent"].ToString() != ""))
            {
                content.ItemContent = set.Tables[0].Rows[0]["ItemContent"].ToString();
            }
            if ((set.Tables[0].Rows[0]["Categoryname"] != null) && (set.Tables[0].Rows[0]["Categoryname"].ToString() != ""))
            {
                category.CategoryName = set.Tables[0].Rows[0]["Categoryname"].ToString();
            }
            if ((set.Tables[0].Rows[0]["PageNumber"] != null) && (set.Tables[0].Rows[0]["PageNumber"].ToString() != ""))
            {
                content.PageNumber = Convert.ToInt32(set.Tables[0].Rows[0]["PageNumber"].ToString());
            }
            content.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            return content;
        }

        public MS.ECP.Model.CMS.PageContent GetFirstModelByCategory(int categoryID)
        {
            MS.ECP.Model.CMS.PageContent content = new MS.ECP.Model.CMS.PageContent();
            StringBuilder builder = new StringBuilder();
            builder.Append("select top 1 * from CmsPageContent ");
            builder.Append("where CategoryID=" + categoryID);
            DataSet set = DbHelperSQL.Query(builder.ToString());
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                content.ID = Convert.ToInt32(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                content.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["PageNumber"] != null) && (set.Tables[0].Rows[0]["PageNumber"].ToString() != ""))
            {
                content.PageNumber = Convert.ToInt32(set.Tables[0].Rows[0]["PageNumber"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Item"] != null) && (set.Tables[0].Rows[0]["Item"].ToString() != ""))
            {
                content.Item = set.Tables[0].Rows[0]["Item"].ToString();
            }
            if ((set.Tables[0].Rows[0]["ItemContent"] != null) && (set.Tables[0].Rows[0]["ItemContent"].ToString() != ""))
            {
                content.ItemContent = set.Tables[0].Rows[0]["ItemContent"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                content.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["CategoryID"] != null) && (set.Tables[0].Rows[0]["CategoryID"].ToString() != ""))
            {
                content.CategoryID = Convert.ToInt32(set.Tables[0].Rows[0]["CategoryID"].ToString());
            }
            content.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            content.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            content.Description = set.Tables[0].Rows[0]["Description"].ToString();
            content.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            content.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return content;
        }

        public IList<MS.ECP.Model.CMS.PageContent> GetList(string strWhere)
        {
            DataTable table = this.GetDataSet(strWhere).Tables[0];
            IList<MS.ECP.Model.CMS.PageContent> list = new List<MS.ECP.Model.CMS.PageContent>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.PageContent item = new MS.ECP.Model.CMS.PageContent();
                    if ((table.Rows[i]["ID"] != null) && (table.Rows[i]["ID"].ToString() != ""))
                    {
                        item.ID = int.Parse(table.Rows[i]["ID"].ToString());
                    }
                    if ((table.Rows[i]["Guid"] != null) && (table.Rows[i]["Guid"].ToString() != ""))
                    {
                        item.Guid = table.Rows[i]["Guid"].ToString();
                    }
                    if ((table.Rows[i]["LanguageCode"] != null) && (table.Rows[i]["LanguageCode"].ToString() != ""))
                    {
                        item.LanguageCode = table.Rows[i]["LanguageCode"].ToString();
                    }
                    if ((table.Rows[i]["Item"] != null) && (table.Rows[i]["Item"].ToString() != ""))
                    {
                        item.Item = table.Rows[i]["Item"].ToString();
                    }
                    if ((table.Rows[i]["ItemContent"] != null) && (table.Rows[i]["ItemContent"].ToString() != ""))
                    {
                        item.ItemContent = table.Rows[i]["ItemContent"].ToString();
                    }
                    if ((table.Rows[i]["CategoryID"] != null) && (table.Rows[i]["CategoryID"].ToString() != ""))
                    {
                        item.CategoryID = int.Parse(table.Rows[i]["CategoryID"].ToString());
                    }
                    item.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                    item.PageNumber = int.Parse(table.Rows[i]["PageNumber"].ToString());
                    item.Keywords = table.Rows[i]["Keywords"].ToString();
                    item.Description = table.Rows[i]["Description"].ToString();
                    item.SeoTitle = table.Rows[i]["SeoTitle"].ToString();
                    item.Url = table.Rows[i]["Url"].ToString();
                    list.Add(item);
                }
            }
            return list;
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            if (Top > 0)
            {
                builder.Append(" top " + Top.ToString());
            }
            builder.Append(" ID,Guid,PageNumber,Item,ItemContent,LanguageCode,CategoryID ");
            builder.Append(" FROM CmsPageContent ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(builder.ToString());
        }

        public IList<MS.ECP.Model.CMS.PageContent> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataTable table = this.GetListDataSetByPage(strWhere, startIndex, endIndex).Tables[0];
            IList<MS.ECP.Model.CMS.PageContent> list = new List<MS.ECP.Model.CMS.PageContent>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.PageContent item = new MS.ECP.Model.CMS.PageContent();
                    if ((table.Rows[i]["ID"] != null) && (table.Rows[i]["ID"].ToString() != ""))
                    {
                        item.ID = int.Parse(table.Rows[i]["ID"].ToString());
                    }
                    if ((table.Rows[i]["Guid"] != null) && (table.Rows[i]["Guid"].ToString() != ""))
                    {
                        item.Guid = table.Rows[i]["Guid"].ToString();
                    }
                    if ((table.Rows[i]["LanguageCode"] != null) && (table.Rows[i]["LanguageCode"].ToString() != ""))
                    {
                        item.LanguageCode = table.Rows[i]["LanguageCode"].ToString();
                    }
                    if ((table.Rows[i]["Item"] != null) && (table.Rows[i]["Item"].ToString() != ""))
                    {
                        item.Item = table.Rows[i]["Item"].ToString();
                    }
                    if ((table.Rows[i]["ItemContent"] != null) && (table.Rows[i]["ItemContent"].ToString() != ""))
                    {
                        item.ItemContent = table.Rows[i]["ItemContent"].ToString();
                    }
                    if ((table.Rows[i]["CategoryID"] != null) && (table.Rows[i]["CategoryID"].ToString() != ""))
                    {
                        item.CategoryID = int.Parse(table.Rows[i]["CategoryID"].ToString());
                    }
                    item.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                    item.PageNumber = int.Parse(table.Rows[i]["PageNumber"].ToString());
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
            builder.Append(")AS Row, T.*  from CmsPageContent T ");
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
            return DbHelperSQL.GetMaxID("ID", "CmsPageContent");
        }

        public MS.ECP.Model.CMS.PageContent GetModel(int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from CmsPageContent ");
            builder.Append("where id=@id");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            cmdParms[0].Value = id;
            MS.ECP.Model.CMS.PageContent content = new MS.ECP.Model.CMS.PageContent();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                content.ID = Convert.ToInt32(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                content.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["PageNumber"] != null) && (set.Tables[0].Rows[0]["PageNumber"].ToString() != ""))
            {
                content.PageNumber = Convert.ToInt32(set.Tables[0].Rows[0]["PageNumber"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Item"] != null) && (set.Tables[0].Rows[0]["Item"].ToString() != ""))
            {
                content.Item = set.Tables[0].Rows[0]["Item"].ToString();
            }
            if ((set.Tables[0].Rows[0]["ItemContent"] != null) && (set.Tables[0].Rows[0]["ItemContent"].ToString() != ""))
            {
                content.ItemContent = set.Tables[0].Rows[0]["ItemContent"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                content.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["CategoryID"] != null) && (set.Tables[0].Rows[0]["CategoryID"].ToString() != ""))
            {
                content.CategoryID = Convert.ToInt32(set.Tables[0].Rows[0]["CategoryID"].ToString());
            }
            content.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            content.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            content.Description = set.Tables[0].Rows[0]["Description"].ToString();
            content.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            content.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return content;
        }

        public MS.ECP.Model.CMS.PageContent GetModelByCache(int ID)
        {
            string cacheKey = "PageContentModel-" + ID;
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
            return (MS.ECP.Model.CMS.PageContent)cache;
        }

        public MS.ECP.Model.CMS.PageContent GetModelByGuid(string guid, string languageId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from CmsPageContent ");
            builder.Append(" where Guid=@Guid ");
            builder.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = guid;
            cmdParms[1].Value = languageId;
            MS.ECP.Model.CMS.PageContent content = new MS.ECP.Model.CMS.PageContent();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if ((set.Tables[0].Rows[0]["ID"] != null) && (set.Tables[0].Rows[0]["ID"].ToString() != ""))
            {
                content.ID = Convert.ToInt32(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                content.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["PageNumber"] != null) && (set.Tables[0].Rows[0]["PageNumber"].ToString() != ""))
            {
                content.PageNumber = Convert.ToInt32(set.Tables[0].Rows[0]["PageNumber"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Item"] != null) && (set.Tables[0].Rows[0]["Item"].ToString() != ""))
            {
                content.Item = set.Tables[0].Rows[0]["Item"].ToString();
            }
            if ((set.Tables[0].Rows[0]["ItemContent"] != null) && (set.Tables[0].Rows[0]["ItemContent"].ToString() != ""))
            {
                content.ItemContent = set.Tables[0].Rows[0]["ItemContent"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                content.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if ((set.Tables[0].Rows[0]["CategoryID"] != null) && (set.Tables[0].Rows[0]["CategoryID"].ToString() != ""))
            {
                content.CategoryID = Convert.ToInt32(set.Tables[0].Rows[0]["CategoryID"].ToString());
            }
            content.CreateDate = DateTime.Parse(set.Tables[0].Rows[0]["CreateDate"].ToString());
            content.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            content.Description = set.Tables[0].Rows[0]["Description"].ToString();
            content.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            content.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return content;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM CmsPageContent ");
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

        public bool Update(MS.ECP.Model.CMS.PageContent model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsPageContent set ");
            builder.Append(" Guid = @Guid , ");
            builder.Append("LanguageCode = @LanguageCode , ");
            builder.Append("PageNumber=@PageNumber, ");
            builder.Append("Item=@Item , ");
            builder.Append("ItemContent=@ItemContent, ");
            builder.Append("CategoryID=@CategoryID , ");
            builder.Append(" Keywords = @Keywords , ");
            builder.Append(" Description = @Description , ");
            builder.Append(" SeoTitle = @SeoTitle ,  ");
            builder.Append(" Url = @Url  ");
            builder.Append("where ID=@id");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4), new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@PageNumber", SqlDbType.Int, 4), new SqlParameter("@Item", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@ItemContent", SqlDbType.NText), new SqlParameter("@CategoryID", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 50), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Guid;
            cmdParms[2].Value = model.LanguageCode;
            cmdParms[3].Value = model.PageNumber;
            cmdParms[4].Value = model.Item;
            cmdParms[5].Value = model.ItemContent;
            cmdParms[6].Value = model.CategoryID;
            cmdParms[7].Value = model.Keywords;
            cmdParms[8].Value = model.Description;
            cmdParms[9].Value = model.SeoTitle;
            cmdParms[10].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateSeo(MS.ECP.Model.CMS.PageContent model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsPageContent set ");
            builder.Append(" Keywords = @Keywords , ");
            builder.Append(" Description = @Description , ");
            builder.Append(" SeoTitle = @SeoTitle ,  ");
            builder.Append(" Url = @Url  ");
            builder.Append(" where ID=@ID  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Keywords", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Keywords;
            cmdParms[2].Value = model.Description;
            cmdParms[3].Value = model.SeoTitle;
            cmdParms[4].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}
