﻿namespace MS.ECP.DAL.CMS
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

    public class Category : ICategory
    {
        public bool Add(MS.ECP.Model.CMS.Category model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into CmsCategory(");
            builder.Append("Guid, CategoryName,LanguageCode,ParentGuid,Keywords,Description,SeoTitle,Url");
            builder.Append(") values (");
            builder.Append("@Guid, @CategoryName,@LanguageCode,@ParentGuid,@Keywords,@Description,@SeoTitle,@Url");
            builder.Append(") ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@CategoryName", SqlDbType.NVarChar, 0xff), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@ParentGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Keywords", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            if ((model.Guid == "") || (model.Guid == null))
            {
                cmdParms[0].Value = Guid.NewGuid().ToString();
            }
            else
            {
                cmdParms[0].Value = model.Guid;
            }
            cmdParms[1].Value = model.CategoryName;
            cmdParms[2].Value = model.LanguageCode;
            cmdParms[3].Value = model.ParentGuid;
            cmdParms[4].Value = model.Keywords;
            cmdParms[5].Value = model.Description;
            cmdParms[6].Value = model.SeoTitle;
            cmdParms[7].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsCategory ");
            builder.Append(" where ID=@ID ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteByLangGuid(string langGuid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsCategory ");
            builder.Append(" where Guid=@Guid ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8) };
            cmdParms[0].Value = langGuid;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from CmsCategory ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (DbHelperSQL.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from CmsCategory");
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
            builder.Append(" FROM CmsCategory ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(builder.ToString());
        }

        public MS.ECP.Model.CMS.Category GetDefaultModelByLang(string LanguageCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsCategory ");
            builder.Append(" where LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = LanguageCode;
            MS.ECP.Model.CMS.Category category = new MS.ECP.Model.CMS.Category();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                category.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                category.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["CategoryName"] != null) && (set.Tables[0].Rows[0]["CategoryName"].ToString() != ""))
            {
                category.CategoryName = set.Tables[0].Rows[0]["CategoryName"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                category.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if (set.Tables[0].Rows[0]["ParentGuid"].ToString() != "")
            {
                category.ParentGuid = set.Tables[0].Rows[0]["ParentGuid"].ToString();
            }
            category.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            category.Description = set.Tables[0].Rows[0]["Description"].ToString();
            category.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            category.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return category;
        }

        public IList<MS.ECP.Model.CMS.Category> GetList(string strWhere)
        {
            DataTable table = this.GetDataSet(strWhere).Tables[0];
            IList<MS.ECP.Model.CMS.Category> list = new List<MS.ECP.Model.CMS.Category>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.Category item = new MS.ECP.Model.CMS.Category();
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
                    if ((table.Rows[i]["CategoryName"] != null) && (table.Rows[i]["CategoryName"].ToString() != ""))
                    {
                        item.CategoryName = table.Rows[i]["CategoryName"].ToString();
                    }
                    if ((table.Rows[i]["ParentGuid"] != null) && (table.Rows[i]["ParentGuid"].ToString() != ""))
                    {
                        item.ParentGuid = table.Rows[i]["ParentGuid"].ToString();
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

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            if (Top > 0)
            {
                builder.Append(" top " + Top.ToString());
            }
            builder.Append(" * ");
            builder.Append(" FROM CmsCategory ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(builder.ToString());
        }

        public IList<MS.ECP.Model.CMS.Category> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataTable table = this.GetListDataSetByPage(strWhere, startIndex, endIndex).Tables[0];
            IList<MS.ECP.Model.CMS.Category> list = new List<MS.ECP.Model.CMS.Category>();
            int count = table.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MS.ECP.Model.CMS.Category item = new MS.ECP.Model.CMS.Category();
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
                    if ((table.Rows[i]["CategoryName"] != null) && (table.Rows[i]["CategoryName"].ToString() != ""))
                    {
                        item.CategoryName = table.Rows[i]["CategoryName"].ToString();
                    }
                    if ((table.Rows[i]["ParentGuid"] != null) && (table.Rows[i]["ParentGuid"].ToString() != ""))
                    {
                        item.ParentGuid = table.Rows[i]["ParentGuid"].ToString();
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
            builder.Append("order by T.ID desc");
            builder.Append(")AS Row, T.*  from CmsCategory T ");
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
            return DbHelperSQL.GetMaxID("ID", "CmsCategory");
        }

        public MS.ECP.Model.CMS.Category GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsCategory ");
            builder.Append(" where ID=@ID");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            cmdParms[0].Value = ID;
            MS.ECP.Model.CMS.Category category = new MS.ECP.Model.CMS.Category();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                category.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                category.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["CategoryName"] != null) && (set.Tables[0].Rows[0]["CategoryName"].ToString() != ""))
            {
                category.CategoryName = set.Tables[0].Rows[0]["CategoryName"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                category.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if (set.Tables[0].Rows[0]["ParentGuid"].ToString() != "")
            {
                category.ParentGuid = set.Tables[0].Rows[0]["ParentGuid"].ToString();
            }
            category.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            category.Description = set.Tables[0].Rows[0]["Description"].ToString();
            category.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            category.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return category;
        }

        public MS.ECP.Model.CMS.Category GetModelByCache(int ID)
        {
            string cacheKey = "CategoryModel-" + ID;
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
            return (MS.ECP.Model.CMS.Category)cache;
        }

        public MS.ECP.Model.CMS.Category GetModelByGuid(string guid, string languageId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsCategory ");
            builder.Append(" where Guid=@Guid ");
            builder.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50) };
            cmdParms[0].Value = guid;
            cmdParms[1].Value = languageId;
            MS.ECP.Model.CMS.Category category = new MS.ECP.Model.CMS.Category();
            DataSet set = DbHelperSQL.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                category.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                category.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["CategoryName"] != null) && (set.Tables[0].Rows[0]["CategoryName"].ToString() != ""))
            {
                category.CategoryName = set.Tables[0].Rows[0]["CategoryName"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                category.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if (set.Tables[0].Rows[0]["ParentGuid"].ToString() != "")
            {
                category.ParentGuid = set.Tables[0].Rows[0]["ParentGuid"].ToString();
            }
            category.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            category.Description = set.Tables[0].Rows[0]["Description"].ToString();
            category.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            category.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return category;
        }

        public MS.ECP.Model.CMS.Category GetModelByWhere(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append("  from CmsCategory ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            MS.ECP.Model.CMS.Category category = new MS.ECP.Model.CMS.Category();
            DataSet set = DbHelperSQL.Query(builder.ToString());
            if (set.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            if (set.Tables[0].Rows[0]["ID"].ToString() != "")
            {
                category.ID = int.Parse(set.Tables[0].Rows[0]["ID"].ToString());
            }
            if ((set.Tables[0].Rows[0]["Guid"] != null) && (set.Tables[0].Rows[0]["Guid"].ToString() != ""))
            {
                category.Guid = set.Tables[0].Rows[0]["Guid"].ToString();
            }
            if ((set.Tables[0].Rows[0]["CategoryName"] != null) && (set.Tables[0].Rows[0]["CategoryName"].ToString() != ""))
            {
                category.CategoryName = set.Tables[0].Rows[0]["CategoryName"].ToString();
            }
            if ((set.Tables[0].Rows[0]["LanguageCode"] != null) && (set.Tables[0].Rows[0]["LanguageCode"].ToString() != ""))
            {
                category.LanguageCode = set.Tables[0].Rows[0]["LanguageCode"].ToString();
            }
            if (set.Tables[0].Rows[0]["ParentGuid"].ToString() != "")
            {
                category.ParentGuid = set.Tables[0].Rows[0]["ParentGuid"].ToString();
            }
            category.Keywords = set.Tables[0].Rows[0]["Keywords"].ToString();
            category.Description = set.Tables[0].Rows[0]["Description"].ToString();
            category.SeoTitle = set.Tables[0].Rows[0]["SeoTitle"].ToString();
            category.Url = set.Tables[0].Rows[0]["Url"].ToString();
            return category;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM CmsCategory ");
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

        public bool Update(MS.ECP.Model.CMS.Category model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsCategory set ");
            builder.Append(" Guid = @Guid , ");
            builder.Append(" CategoryName = @CategoryName , ");
            builder.Append(" LanguageCode = @LanguageCode , ");
            builder.Append(" ParentGuid = @ParentGuid , ");
            builder.Append(" Keywords = @Keywords , ");
            builder.Append(" Description = @Description , ");
            builder.Append(" SeoTitle = @SeoTitle ,  ");
            builder.Append(" Url = @Url  ");
            builder.Append(" where ID=@ID  ");
            SqlParameter[] cmdParms = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@Guid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@CategoryName", SqlDbType.NVarChar, 0xff), new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50), new SqlParameter("@ParentGuid", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Keywords", SqlDbType.NVarChar, 50), new SqlParameter("@Description", SqlDbType.NText), new SqlParameter("@SeoTitle", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Url", SqlDbType.NVarChar, 0xe1) };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Guid;
            cmdParms[2].Value = model.CategoryName;
            cmdParms[3].Value = model.LanguageCode;
            cmdParms[4].Value = model.ParentGuid;
            cmdParms[5].Value = model.Keywords;
            cmdParms[6].Value = model.Description;
            cmdParms[7].Value = model.SeoTitle;
            cmdParms[8].Value = model.Url;
            return (DbHelperSQL.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateSeo(MS.ECP.Model.CMS.Category model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update CmsCategory set ");
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
