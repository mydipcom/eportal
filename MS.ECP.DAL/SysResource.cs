using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.ECP.IDAL;
using MS.ECP.Utility;

namespace MS.ECP.DAL
{
    /// <summary>
    /// 数据访问类:SysResource
    /// </summary>
    public partial class SysResource : ISysResource
    {
        public SysResource()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "SysResource");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysResource");
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
        public bool Add(Model.SysResource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysResource(");
            strSql.Append("LanguageCode,ResourcePage,ResourceType,ResourceKey,ResourceValue)");
            strSql.Append(" values (");
            strSql.Append("@LanguageCode,@ResourcePage,@ResourceType,@ResourceKey,@ResourceValue)");
            SqlParameter[] parameters = {
					new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourcePage", SqlDbType.NVarChar,200),
					new SqlParameter("@ResourceType", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourceKey", SqlDbType.NVarChar,200),
					new SqlParameter("@ResourceValue", SqlDbType.NText)
            };
            parameters[0].Value = model.LanguageCode;
            parameters[1].Value = model.ResourcePage;
            parameters[2].Value = model.ResourceType;
            parameters[3].Value = model.ResourceKey;
            parameters[4].Value = model.ResourceValue;

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
        public bool Update(Model.SysResource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysResource set ");
            strSql.Append(" LanguageCode = @LanguageCode , ");
            strSql.Append(" ResourcePage = @ResourcePage , ");
            strSql.Append(" ResourceType = @ResourceType , ");
            strSql.Append(" ResourceKey = @ResourceKey , ");
            strSql.Append(" ResourceValue = @ResourceValue ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4) ,
					new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourcePage", SqlDbType.NVarChar,200),
					new SqlParameter("@ResourceType", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourceKey", SqlDbType.NVarChar,200),
					new SqlParameter("@ResourceValue", SqlDbType.NText)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LanguageCode;
            parameters[2].Value = model.ResourcePage;
            parameters[3].Value = model.ResourceType;
            parameters[4].Value = model.ResourceKey;
            parameters[5].Value = model.ResourceValue;
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
        /// 得到一个对象实体
        /// </summary>
        public Model.SysResource GetModel(int ID, string LanguageCode, string ResourcePage, string ResourceType, string ResourceKey, string ResourceValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, LanguageCode, ResourcePage, ResourceType, ResourceKey, ResourceValue  ");
            strSql.Append("  from SysResource ");
            strSql.Append(" where ID=@ID and LanguageCode=@LanguageCode and ResourcePage=@ResourcePage and ResourceType=@ResourceType and ResourceKey=@ResourceKey and ResourceValue=@ResourceValue ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4) ,
					new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourcePage", SqlDbType.NVarChar,200),
					new SqlParameter("@ResourceType", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourceKey", SqlDbType.NVarChar,200),
					new SqlParameter("@ResourceValue", SqlDbType.NText)
            };
            parameters[0].Value = ID;
            parameters[1].Value = LanguageCode;
            parameters[2].Value = ResourcePage;
            parameters[3].Value = ResourceType;
            parameters[4].Value = ResourcePage;
            parameters[5].Value = ResourceType;


            Model.SysResource model = new Model.SysResource();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                model.ResourcePage = ds.Tables[0].Rows[0]["ResourcePage"].ToString();
                model.ResourceType = ds.Tables[0].Rows[0]["ResourceType"].ToString();
                model.ResourceKey = ds.Tables[0].Rows[0]["ResourceKey"].ToString(); 
                model.ResourceValue = ds.Tables[0].Rows[0]["ResourceValue"].ToString();

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
        public Model.SysResource GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, LanguageCode, ResourcePage, ResourceType, ResourceKey, ResourceValue  ");
            strSql.Append("  from SysResource ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4) ,
            };
            parameters[0].Value = ID;

            Model.SysResource model = new Model.SysResource();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ResourcePage"] != null && ds.Tables[0].Rows[0]["ResourcePage"].ToString() != "")
                {
                    model.ResourcePage = ds.Tables[0].Rows[0]["ResourcePage"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ResourceType"] != null && ds.Tables[0].Rows[0]["ResourceType"].ToString() != "")
                {
                    model.ResourceType = ds.Tables[0].Rows[0]["ResourceType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ResourceKey"] != null && ds.Tables[0].Rows[0]["ResourceKey"].ToString() != "")
                {
                    model.ResourceKey = ds.Tables[0].Rows[0]["ResourceKey"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ResourceValue"] != null && ds.Tables[0].Rows[0]["ResourceValue"].ToString() != "")
                {
                    model.ResourceValue = ds.Tables[0].Rows[0]["ResourceValue"].ToString();
                }
                
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysResource ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysResource ");
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

        public IList<Model.SysResource> GetList(string strWhere)
        {
            DataSet ds = GetDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.SysResource> modelList = new List<Model.SysResource>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysResource model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysResource();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["ResourcePage"] != null && dt.Rows[n]["ResourcePage"].ToString() != "")
                    {
                        model.ResourcePage = dt.Rows[n]["ResourcePage"].ToString();
                    }
                    if (dt.Rows[n]["ResourceType"] != null && dt.Rows[n]["ResourceType"].ToString() != "")
                    {
                        model.ResourceType = dt.Rows[n]["ResourceType"].ToString();
                    }
                    if (dt.Rows[n]["ResourceKey"] != null && dt.Rows[n]["ResourceKey"].ToString() != "")
                    {
                        model.ResourceKey = dt.Rows[n]["ResourceKey"].ToString();
                    }
                    if (dt.Rows[n]["ResourceValue"] != null && dt.Rows[n]["ResourceValue"].ToString() != "")
                    {
                        model.ResourceValue = dt.Rows[n]["ResourceValue"].ToString();
                    }

                    modelList.Add(model);
                }
            }

            return modelList;
        }

        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SysResource ");
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
            strSql.Append("select count(1) FROM SysResource ");
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
        /// 分页获取数据列表
        /// </summary>
        /// 

        public IList<Model.SysResource> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = GetListDataSetByPage(strWhere, startIndex, endIndex);
            DataTable dt = ds.Tables[0];

            IList<Model.SysResource> modelList = new List<Model.SysResource>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysResource model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysResource();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["ResourcePage"] != null && dt.Rows[n]["ResourcePage"].ToString() != "")
                    {
                        model.ResourcePage = dt.Rows[n]["ResourcePage"].ToString();
                    }
                    if (dt.Rows[n]["ResourceType"] != null && dt.Rows[n]["ResourceType"].ToString() != "")
                    {
                        model.ResourceType = dt.Rows[n]["ResourceType"].ToString();
                    }
                    if (dt.Rows[n]["ResourceKey"] != null && dt.Rows[n]["ResourceKey"].ToString() != "")
                    {
                        model.ResourceKey = dt.Rows[n]["ResourceKey"].ToString();
                    }
                    if (dt.Rows[n]["ResourceValue"] != null && dt.Rows[n]["ResourceValue"].ToString() != "")
                    {
                        model.ResourceValue = dt.Rows[n]["ResourceValue"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public DataSet GetListDataSetByPage(string strWhere, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.ID desc");
            strSql.Append(")AS Row, T.*  from SysResource T ");
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
        public IList<Model.SysResource> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode);
            DataTable dt = ds.Tables[0];

            IList<Model.SysResource> modelList = new List<Model.SysResource>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysResource model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysResource();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["ResourcePage"] != null && dt.Rows[n]["ResourcePage"].ToString() != "")
                    {
                        model.ResourcePage = dt.Rows[n]["ResourcePage"].ToString();
                    }
                    if (dt.Rows[n]["ResourceType"] != null && dt.Rows[n]["ResourceType"].ToString() != "")
                    {
                        model.ResourceType = dt.Rows[n]["ResourceType"].ToString();
                    }
                    if (dt.Rows[n]["ResourceKey"] != null && dt.Rows[n]["ResourceKey"].ToString() != "")
                    {
                        model.ResourceKey = dt.Rows[n]["ResourceKey"].ToString();
                    }
                    if (dt.Rows[n]["ResourceValue"] != null && dt.Rows[n]["ResourceValue"].ToString() != "")
                    {
                        model.ResourceValue = dt.Rows[n]["ResourceValue"].ToString();
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
            strSql.Append(")AS Row, T.*  from SysResource T ");
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
        /// 根据Resourcepage和ResourceValue获得分页数据列表
        /// </summary>
        public IList<Model.SysResource> GetPagingByPageAndValue(int startIndex, int endIndex, string orderby, string resourcePage, string resourceValue)
        {
            DataSet ds = GetDataSetByPageAndValue(startIndex, endIndex, orderby, resourcePage, resourceValue);
            DataTable dt = ds.Tables[0];

            IList<Model.SysResource> modelList = new List<Model.SysResource>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysResource model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysResource();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["ResourcePage"] != null && dt.Rows[n]["ResourcePage"].ToString() != "")
                    {
                        model.ResourcePage = dt.Rows[n]["ResourcePage"].ToString();
                    }
                    if (dt.Rows[n]["ResourceType"] != null && dt.Rows[n]["ResourceType"].ToString() != "")
                    {
                        model.ResourceType = dt.Rows[n]["ResourceType"].ToString();
                    }
                    if (dt.Rows[n]["ResourceKey"] != null && dt.Rows[n]["ResourceKey"].ToString() != "")
                    {
                        model.ResourceKey = dt.Rows[n]["ResourceKey"].ToString();
                    }
                    if (dt.Rows[n]["ResourceValue"] != null && dt.Rows[n]["ResourceValue"].ToString() != "")
                    {
                        model.ResourceValue = dt.Rows[n]["ResourceValue"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public DataSet GetDataSetByPageAndValue(int startIndex, int endIndex, string orderby, string resourcePage, string resourceValue)
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
            strSql.Append(")AS Row, T.*  from SysResource T ");
            if (string.IsNullOrEmpty(resourcePage))
            {
                strSql.AppendFormat(" WHERE (T.ResourcePage='{0}' OR T.ResourcePage is not null ) ", resourcePage);
            }
            else
            {
                strSql.AppendFormat(" WHERE (T.ResourcePage='{0}' AND T.ResourcePage is not null ) ", resourcePage);
            }
            if (string.IsNullOrEmpty(resourceValue))
            {
                strSql.AppendFormat(" and (T.ResourceValue like N'%{0}%' OR T.ResourceValue is not null ) ", resourceValue);
            }
            else
            {
                strSql.AppendFormat(" and (T.ResourceValue like N'%{0}%' AND T.ResourceValue is not null ) ", resourceValue);
            } 

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public IList<Model.SysResource> GetResourcePageList(string strWhere)
        {
            DataSet ds = GetResourcePageDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.SysResource> modelList = new List<Model.SysResource>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysResource model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysResource();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["ResourcePage"] != null && dt.Rows[n]["ResourcePage"].ToString() != "")
                    {
                        model.ResourcePage = dt.Rows[n]["ResourcePage"].ToString();
                    }
                    if (dt.Rows[n]["ResourceType"] != null && dt.Rows[n]["ResourceType"].ToString() != "")
                    {
                        model.ResourceType = dt.Rows[n]["ResourceType"].ToString();
                    }
                    if (dt.Rows[n]["ResourceKey"] != null && dt.Rows[n]["ResourceKey"].ToString() != "")
                    {
                        model.ResourceKey = dt.Rows[n]["ResourceKey"].ToString();
                    }
                    if (dt.Rows[n]["ResourceValue"] != null && dt.Rows[n]["ResourceValue"].ToString() != "")
                    {
                        model.ResourceValue = dt.Rows[n]["ResourceValue"].ToString();
                    }

                    modelList.Add(model);
                }
            }

            return modelList;
        }

        public DataSet GetResourcePageDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct ResourcePage ");
            strSql.Append(" FROM SysResource ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        ///  根据Resourcepage和ResourceValue获取总记录数
        /// </summary>
        public int GetRecordCountByPageAndValue(string resourcePage, string resourceValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SysResource ");
            if (string.IsNullOrEmpty(resourcePage))
            {
                strSql.AppendFormat(" WHERE (ResourcePage='{0}' OR ResourcePage is not null ) ", resourcePage);
            }
            else
            {
                strSql.AppendFormat(" WHERE (ResourcePage='{0}' AND ResourcePage is not null ) ", resourcePage);
            }
            if (string.IsNullOrEmpty(resourceValue))
            {
                strSql.AppendFormat(" and (ResourceValue like N'%{0}%' OR ResourceValue is not null ) ", resourceValue);
            }
            else 
            {
                strSql.AppendFormat(" and (ResourceValue like N'%{0}%' AND ResourceValue is not null ) ", resourceValue);
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

        //public DataSet GetDataSetBy(int startIndex, int endIndex, string orderby, string LangCode, string ResourcePage, string ResourceType)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby + " desc ");
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.ID desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from SysResource T ");
        //    if (!string.IsNullOrEmpty(LangCode.Trim()))
        //    {
        //        strSql.Append(" WHERE T.LanguageCode=@LanguageCode ");
        //        strSql.Append(" WHERE T.ResourcePage=@ResourcePage ");
        //        strSql.Append(" WHERE T.ResourceType=@ResourceType ");
        //        SqlParameter[] parameters = {
        //            new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ResourcePage", SqlDbType.NVarChar,200),
        //            new SqlParameter("@ResourceType", SqlDbType.NVarChar,10)
        //         };
        //        parameters[0].Value = LangCode;
        //        parameters[0].Value = ResourcePage;
        //        parameters[0].Value = ResourceType;
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetDataSet(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,Code,Text,WebRegion,PageName,CodeType,CodeState,CodeOrder ");
            strSql.Append(" FROM SysResource ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  Method
    }
}
