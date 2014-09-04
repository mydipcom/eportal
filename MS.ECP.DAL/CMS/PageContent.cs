using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using MS.ECP.Utility;
using MS.ECP.IDAL.CMS;
using System.Collections.Generic;

namespace MS.ECP.DAL.CMS
{
    public partial class PageContent : IPageContent
    {
        public PageContent() { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CmsPageContent");
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CmsPageContent");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.CMS.PageContent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CmsPageContent(Guid,PageNumber,Item,ItemContent,LanguageCode,CategoryID,CreateDate,Keywords,Description,SeoTitle,Url ");
            strSql.Append(") values (");
            strSql.Append("@Guid,@PageNumber,@Item,@ItemContent,@LanguageCode,@CategoryID,@CreateDate,@Keywords,@Description,@SeoTitle,@Url");
            strSql.Append(") ");

            SqlParameter[] parameters = { 
                        new SqlParameter("@Guid",SqlDbType.NVarChar,1000), 
                        new SqlParameter("@PageNumber",SqlDbType.Int, 4),
                        new SqlParameter("@Item",SqlDbType.NVarChar,1000),
                        new SqlParameter("@ItemContent",SqlDbType.NText),
                        new SqlParameter("@LanguageCode",SqlDbType.NVarChar,50),
                        new SqlParameter("@CategoryID",SqlDbType.Int,4),
                        new SqlParameter("@CreateDate",SqlDbType.DateTime),
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
            parameters[1].Value = model.PageNumber;
            parameters[2].Value = model.Item;
            parameters[3].Value = model.ItemContent;
            parameters[4].Value = model.LanguageCode;
            parameters[5].Value = model.CategoryID;
            parameters[6].Value = DateTime.Now;
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
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.CMS.PageContent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsPageContent set ");
            strSql.Append(" Guid = @Guid , ");
            strSql.Append("LanguageCode = @LanguageCode , ");
            strSql.Append("PageNumber=@PageNumber, "); 
            strSql.Append("Item=@Item , "); 
            strSql.Append("ItemContent=@ItemContent, "); 
            strSql.Append("CategoryID=@CategoryID , ");
            strSql.Append(" Keywords = @Keywords , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" SeoTitle = @SeoTitle ,  ");
            strSql.Append(" Url = @Url  ");
            strSql.Append("where ID=@id");

            SqlParameter[] parameters = { 
                       new SqlParameter("@id", SqlDbType.Int, 4),
                       new SqlParameter("@Guid",SqlDbType.NVarChar,1000),
                       new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50),
                       new SqlParameter("@PageNumber",SqlDbType.Int,4),
                       new SqlParameter("@Item",SqlDbType.NVarChar,1000),
                       new SqlParameter("@ItemContent",SqlDbType.NText),
                       new SqlParameter("@CategoryID",SqlDbType.Int,4),
                       new SqlParameter("@Keywords", SqlDbType.NVarChar,50) ,            
                       new SqlParameter("@Description", SqlDbType.NText) ,            
                       new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                       new SqlParameter("@Url", SqlDbType.NVarChar,225) 
             };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Guid;
            parameters[2].Value = model.LanguageCode;
            parameters[3].Value = model.PageNumber;
            parameters[4].Value = model.Item;
            parameters[5].Value = model.ItemContent;
            parameters[6].Value = model.CategoryID;
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
        public bool UpdateSeo(Model.CMS.PageContent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsPageContent set ");
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
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CmsPageContent ");
            strSql.Append("where ID=@id");

            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;

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
            strSql.Append("delete from CmsPageContent ");
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
        /// <param name="PageContentIDList"></param>
        /// <returns></returns>
        public bool DeleteList(string PageContentIDList)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("delete from CmsPageContent ");
            strSql.Append("where ID in (" + PageContentIDList + ")");

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

        //获取一个实体
        public Model.CMS.PageContent GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * from CmsPageContent ");
            strSql.Append("where id=@id");

            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int, 4) };

            parameters[0].Value = id;

            Model.CMS.PageContent model = new Model.CMS.PageContent();

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PageNumber"] != null && ds.Tables[0].Rows[0]["PageNumber"].ToString() != "")
                {
                    model.PageNumber = Convert.ToInt32(ds.Tables[0].Rows[0]["PageNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Item"] != null && ds.Tables[0].Rows[0]["Item"].ToString() != "")
                {
                    model.Item = ds.Tables[0].Rows[0]["Item"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ItemContent"] != null && ds.Tables[0].Rows[0]["ItemContent"].ToString() != "")
                {
                    model.ItemContent = ds.Tables[0].Rows[0]["ItemContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryID"] != null && ds.Tables[0].Rows[0]["CategoryID"].ToString() != "")
                {
                    model.CategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryID"].ToString());
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
        /// 通过类别ID获取当前第一个实体
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public Model.CMS.PageContent GetFirstModelByCategory(int categoryID)
        {
            Model.CMS.PageContent model = new Model.CMS.PageContent();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select top 1 * from CmsPageContent ");
            strSql.Append("where CategoryID=" + categoryID);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PageNumber"] != null && ds.Tables[0].Rows[0]["PageNumber"].ToString() != "")
                {
                    model.PageNumber = Convert.ToInt32(ds.Tables[0].Rows[0]["PageNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Item"] != null && ds.Tables[0].Rows[0]["Item"].ToString() != "")
                {
                    model.Item = ds.Tables[0].Rows[0]["Item"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ItemContent"] != null && ds.Tables[0].Rows[0]["ItemContent"].ToString() != "")
                {
                    model.ItemContent = ds.Tables[0].Rows[0]["ItemContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryID"] != null && ds.Tables[0].Rows[0]["CategoryID"].ToString() != "")
                {
                    model.CategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryID"].ToString());
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

        //根据Guid&&Language获取一个实体
        public Model.CMS.PageContent GetModelByGuid(string guid, string languageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CmsPageContent ");
            strSql.Append(" where Guid=@Guid ");
            strSql.Append(" and LanguageCode=@LanguageCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Guid", SqlDbType.NVarChar,1000) ,
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) ,
            };
            parameters[0].Value = guid;
            parameters[1].Value = languageId;

            Model.CMS.PageContent model = new Model.CMS.PageContent();

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PageNumber"] != null && ds.Tables[0].Rows[0]["PageNumber"].ToString() != "")
                {
                    model.PageNumber = Convert.ToInt32(ds.Tables[0].Rows[0]["PageNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Item"] != null && ds.Tables[0].Rows[0]["Item"].ToString() != "")
                {
                    model.Item = ds.Tables[0].Rows[0]["Item"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ItemContent"] != null && ds.Tables[0].Rows[0]["ItemContent"].ToString() != "")
                {
                    model.ItemContent = ds.Tables[0].Rows[0]["ItemContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CategoryID"] != null && ds.Tables[0].Rows[0]["CategoryID"].ToString() != "")
                {
                    model.CategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryID"].ToString());
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

        //根据ParentGuid得到一个对象实体
        public Model.CMS.PageContent GetDefaultModel(string ParentGuid)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select p.CategoryID,p.Guid,p.LanguageCode,p.Item,p.ItemContent,c.Categoryname,p.PageNumber,p.CreateDate from CmsPageContent p ");
            strSql.Append(" left join CmsCategory c  ");
            strSql.Append(" on p.CategoryID = c.ID ");
            strSql.Append(" where c.ParentGuid =@ParentGuid ");

            SqlParameter[] parameters = {
                    new SqlParameter("@ParentGuid", SqlDbType.NVarChar,1000) ,

            };
            parameters[0].Value = ParentGuid;

            Model.CMS.Category cmodel = new Model.CMS.Category();
            Model.CMS.PageContent model = new Model.CMS.PageContent();

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CategoryID"] != null && ds.Tables[0].Rows[0]["CategoryID"].ToString() != "")
                {
                    model.CategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Item"] != null && ds.Tables[0].Rows[0]["Item"].ToString() != "")
                {
                    model.Item = ds.Tables[0].Rows[0]["Item"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ItemContent"] != null && ds.Tables[0].Rows[0]["ItemContent"].ToString() != "")
                {
                    model.ItemContent = ds.Tables[0].Rows[0]["ItemContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Categoryname"] != null && ds.Tables[0].Rows[0]["Categoryname"].ToString() != "")
                {
                    cmodel.CategoryName = ds.Tables[0].Rows[0]["Categoryname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PageNumber"] != null && ds.Tables[0].Rows[0]["PageNumber"].ToString() != "")
                {
                    model.PageNumber = Convert.ToInt32(ds.Tables[0].Rows[0]["PageNumber"].ToString());
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
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
        public IList<Model.CMS.PageContent> GetList(string strWhere)
        {
            DataSet ds = GetDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.PageContent> modelList = new List<Model.CMS.PageContent>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.PageContent model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.PageContent();

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
                    if (dt.Rows[n]["Item"] != null && dt.Rows[n]["Item"].ToString() != "")
                    {
                        model.Item = dt.Rows[n]["Item"].ToString();
                    }
                    if (dt.Rows[n]["ItemContent"] != null && dt.Rows[n]["ItemContent"].ToString() != "")
                    {
                        model.ItemContent = dt.Rows[n]["ItemContent"].ToString();
                    }
                    if (dt.Rows[n]["CategoryID"] != null && dt.Rows[n]["CategoryID"].ToString() != "")
                    {
                        model.CategoryID = int.Parse(dt.Rows[n]["CategoryID"].ToString());
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.PageNumber = int.Parse(dt.Rows[n]["PageNumber"].ToString());
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
            strSql.Append(" FROM CmsPageContent ");
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
            strSql.Append("select count(1) FROM CmsPageContent ");
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
        public IList<Model.CMS.PageContent> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = GetListDataSetByPage(strWhere, startIndex, endIndex);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.PageContent> modelList = new List<Model.CMS.PageContent>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.PageContent model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.PageContent();

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
                    if (dt.Rows[n]["Item"] != null && dt.Rows[n]["Item"].ToString() != "")
                    {
                        model.Item = dt.Rows[n]["Item"].ToString();
                    }
                    if (dt.Rows[n]["ItemContent"] != null && dt.Rows[n]["ItemContent"].ToString() != "")
                    {
                        model.ItemContent = dt.Rows[n]["ItemContent"].ToString();
                    }
                    if (dt.Rows[n]["CategoryID"] != null && dt.Rows[n]["CategoryID"].ToString() != "")
                    {
                        model.CategoryID = int.Parse(dt.Rows[n]["CategoryID"].ToString());
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.PageNumber = int.Parse(dt.Rows[n]["PageNumber"].ToString());
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
            strSql.Append(")AS Row, T.*  from CmsPageContent T ");
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
            strSql.Append(" ID,Guid,PageNumber,Item,ItemContent,LanguageCode,CategoryID ");
            strSql.Append(" FROM CmsPageContent ");
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
        public Model.CMS.PageContent GetModelByCache(int ID)
        {
            string CacheKey = "PageContentModel-" + ID;
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
            return (Model.CMS.PageContent)objModel;
        }

    }
    #endregion 
}
