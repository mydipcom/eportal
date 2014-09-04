using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using MS.ECP.IDAL;
using MS.ECP.Utility;
using System.Collections.Generic;

namespace MS.ECP.DAL
{
    /// <summary>
    /// 数据访问类:SysLanguage
    /// </summary>
    public partial class SysLanguage : ISysLanguage
    {
        public SysLanguage()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "SysLanguage");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LanguageID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysLanguage");
            strSql.Append(" where ID=@LanguageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LanguageID", SqlDbType.Int,4)			};
            parameters[0].Value = LanguageID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.SysLanguage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysLanguage(");
            strSql.Append("Guid,LangCode,LangText,LangStatus,LangOrder,Status)");
            strSql.Append(" values (");
            strSql.Append("@Guid,@LangCode,@LangText,@LangStatus,@LangOrder,@Status)");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,1000),
					new SqlParameter("@LangCode", SqlDbType.NVarChar,50),
					new SqlParameter("@LangText", SqlDbType.NVarChar,200),
					new SqlParameter("@LangStatus", SqlDbType.Int,4),
					new SqlParameter("@LangOrder", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.Guid;
            parameters[1].Value = model.LanguageCode;
            parameters[2].Value = model.LanguageText;
            parameters[3].Value = model.LanguageStatus;
            parameters[4].Value = model.LanguageOrder;
            parameters[5].Value = model.Status;

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
        public bool Update(Model.SysLanguage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysLanguage set ");
            strSql.Append("Guid=@Guid,");
            strSql.Append("LangCode=@LanguageCode,");
            strSql.Append("LangText=@LanguageText,");
            strSql.Append("LangStatus=@LanguageStatus,");
            strSql.Append("LangOrder=@LanguageOrder,");
            strSql.Append("Status=@Status");
            strSql.Append(" where ID=@LanguageID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Guid", SqlDbType.VarChar,1000),
					new SqlParameter("@LanguageCode", SqlDbType.VarChar,50),
					new SqlParameter("@LanguageText", SqlDbType.NVarChar,200),
					new SqlParameter("@LanguageStatus", SqlDbType.Int,4),
					new SqlParameter("@LanguageOrder", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@LanguageID", SqlDbType.VarChar,40)};
            parameters[0].Value = model.Guid;
            parameters[1].Value = model.LanguageCode;
            parameters[2].Value = model.LanguageText;
            parameters[3].Value = model.LanguageStatus;
            parameters[4].Value = model.LanguageOrder;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.LanguageID;

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
        public bool Delete(int LanguageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysLanguage ");
            strSql.Append(" where ID=@LanguageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LanguageID", SqlDbType.Int,4)			};
            parameters[0].Value = LanguageID;

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
            strSql.Append("delete from SysLanguage ");
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
        public bool DeleteList(string LanguageIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysLanguage ");
            strSql.Append(" where ID in (" + LanguageIDlist + ")  ");
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
        /// 根据LangCode和WebRegion得到一个对象实体
        /// </summary>
        public Model.SysLanguage GetModelByLangCodeAndWebRegion(string LanguageCode, string WebRegion)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SysLanguage ");
            strSql.Append(" where LangCode=@LanguageCode ");
            strSql.Append(" and WebRegion=@WebRegion ");
            SqlParameter[] parameters = {
					new SqlParameter("@LanguageCode", SqlDbType.VarChar,40),	
                    new SqlParameter("@WebRegion", SqlDbType.VarChar,40)	
            };

            parameters[0].Value = LanguageCode;

            Model.SysLanguage model = new Model.SysLanguage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.LanguageID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangCode"] != null && ds.Tables[0].Rows[0]["LangCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LangCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangText"] != null && ds.Tables[0].Rows[0]["LangText"].ToString() != "")
                {
                    model.LanguageText = ds.Tables[0].Rows[0]["LangText"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangStatus"] != null && ds.Tables[0].Rows[0]["LangStatus"].ToString() != "")
                {
                    model.LanguageStatus = ds.Tables[0].Rows[0]["LangStatus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangOrder"] != null && ds.Tables[0].Rows[0]["LangOrder"].ToString() != "")
                {
                    model.LanguageOrder = int.Parse(ds.Tables[0].Rows[0]["LangOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        public Model.SysLanguage GetModelByID(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from SysLanguage ");
            strSql.Append(" where ID=@LanguageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LanguageID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            Model.SysLanguage model = new Model.SysLanguage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.LanguageID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangCode"] != null && ds.Tables[0].Rows[0]["LangCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LangCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangText"] != null && ds.Tables[0].Rows[0]["LangText"].ToString() != "")
                {
                    model.LanguageText = ds.Tables[0].Rows[0]["LangText"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangStatus"] != null && ds.Tables[0].Rows[0]["LangStatus"].ToString() != "")
                {
                    model.LanguageStatus = ds.Tables[0].Rows[0]["LangStatus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangOrder"] != null && ds.Tables[0].Rows[0]["LangOrder"].ToString() != "")
                {
                    model.LanguageOrder = int.Parse(ds.Tables[0].Rows[0]["LangOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据LangCode到一个对象实体
        /// </summary>
        public Model.SysLanguage GetModelByLangCode(string LangCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from SysLanguage ");
            strSql.Append(" where LangCode=@LangCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@LangCode", SqlDbType.VarChar,40)			};
            parameters[0].Value = LangCode;

            Model.SysLanguage model = new Model.SysLanguage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.LanguageID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangCode"] != null && ds.Tables[0].Rows[0]["LangCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LangCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangText"] != null && ds.Tables[0].Rows[0]["LangText"].ToString() != "")
                {
                    model.LanguageText = ds.Tables[0].Rows[0]["LangText"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangStatus"] != null && ds.Tables[0].Rows[0]["LangStatus"].ToString() != "")
                {
                    model.LanguageStatus = ds.Tables[0].Rows[0]["LangStatus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LangOrder"] != null && ds.Tables[0].Rows[0]["LangOrder"].ToString() != "")
                {
                    model.LanguageOrder = int.Parse(ds.Tables[0].Rows[0]["LangOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
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
        public IList<Model.SysLanguage> GetList(string strWhere)
        {
            DataSet ds = GetDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.SysLanguage> modelList = new List<Model.SysLanguage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysLanguage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysLanguage();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.LanguageID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangCode"] != null && dt.Rows[n]["LangCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LangCode"].ToString();
                    }
                    if (dt.Rows[n]["LangText"] != null && dt.Rows[n]["LangText"].ToString() != "")
                    {
                        model.LanguageText = dt.Rows[n]["LangText"].ToString();
                    }
                    if (dt.Rows[n]["LangStatus"] != null && dt.Rows[n]["LangStatus"].ToString() != "")
                    {
                        model.LanguageStatus = dt.Rows[n]["LangStatus"].ToString();
                    }
                    if (dt.Rows[n]["LangOrder"] != null && dt.Rows[n]["LangOrder"].ToString() != "")
                    {
                        model.LanguageOrder = int.Parse(dt.Rows[n]["LangOrder"].ToString());
                    }
                    model.Status = int.Parse(dt.Rows[0]["Status"].ToString());

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SysLanguage ");
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
            strSql.Append("select count(1) FROM SysLanguage ");
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
        public IList<Model.SysLanguage> GetListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = GetListDataSetByPage(strWhere, startIndex, endIndex);
            DataTable dt = ds.Tables[0];

            IList<Model.SysLanguage> modelList = new List<Model.SysLanguage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysLanguage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysLanguage();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.LanguageID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangCode"] != null && dt.Rows[n]["LangCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LangCode"].ToString();
                    }
                    if (dt.Rows[n]["LangText"] != null && dt.Rows[n]["LangText"].ToString() != "")
                    {
                        model.LanguageText = dt.Rows[n]["LangText"].ToString();
                    }
                    if (dt.Rows[n]["LangStatus"] != null && dt.Rows[n]["LangStatus"].ToString() != "")
                    {
                        model.LanguageStatus = dt.Rows[n]["LangStatus"].ToString();
                    }
                    if (dt.Rows[n]["LangOrder"] != null && dt.Rows[n]["LangOrder"].ToString() != "")
                    {
                        model.LanguageOrder = int.Parse(dt.Rows[n]["LangOrder"].ToString());
                    }
                    model.Status = int.Parse(dt.Rows[0]["Status"].ToString());

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
            strSql.Append(")AS Row, T.*  from SysLanguage T ");
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
        public IList<Model.SysLanguage> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode);
            DataTable dt = ds.Tables[0];

            IList<Model.SysLanguage> modelList = new List<Model.SysLanguage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysLanguage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysLanguage();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.LanguageID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangCode"] != null && dt.Rows[n]["LangCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LangCode"].ToString();
                    }
                    if (dt.Rows[n]["LangText"] != null && dt.Rows[n]["LangText"].ToString() != "")
                    {
                        model.LanguageText = dt.Rows[n]["LangText"].ToString();
                    }
                    if (dt.Rows[n]["LangStatus"] != null && dt.Rows[n]["LangStatus"].ToString() != "")
                    {
                        model.LanguageStatus = dt.Rows[n]["LangStatus"].ToString();
                    }
                    if (dt.Rows[n]["LangOrder"] != null && dt.Rows[n]["LangOrder"].ToString() != "")
                    {
                        model.LanguageOrder = int.Parse(dt.Rows[n]["LangOrder"].ToString());
                    }
                    model.Status = int.Parse(dt.Rows[0]["Status"].ToString());

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
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from SysLanguage T ");
            if (!string.IsNullOrEmpty(LangCode.Trim()))
            {
                strSql.Append(" WHERE T.LangCode=@LanguageCode ");
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
        public IList<Model.SysLanguage> GetTopByLangCode(int Top, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(Top, orderby, LangCode);
            DataTable dt = ds.Tables[0];

            IList<Model.SysLanguage> modelList = new List<Model.SysLanguage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.SysLanguage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.SysLanguage();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.LanguageID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangCode"] != null && dt.Rows[n]["LangCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LangCode"].ToString();
                    }
                    if (dt.Rows[n]["LangText"] != null && dt.Rows[n]["LangText"].ToString() != "")
                    {
                        model.LanguageText = dt.Rows[n]["LangText"].ToString();
                    }
                    if (dt.Rows[n]["LangStatus"] != null && dt.Rows[n]["LangStatus"].ToString() != "")
                    {
                        model.LanguageStatus = dt.Rows[n]["LangStatus"].ToString();
                    }
                    if (dt.Rows[n]["LangOrder"] != null && dt.Rows[n]["LangOrder"].ToString() != "")
                    {
                        model.LanguageOrder = int.Parse(dt.Rows[n]["LangOrder"].ToString());
                    }
                    model.Status = int.Parse(dt.Rows[0]["Status"].ToString());

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
            strSql.Append(" FROM SysLanguage ");
            if (LangCode.Trim() != "")
            {
                strSql.Append(" WHERE LangCode=@LanguageCode ");
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


        public DataTable GetPageList(int pageIndex, int pageCount, ref int total, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top " + pageCount.ToString() + " * from ( ");
            strSql.Append(" select ROW_NUMBER() OVER(ORDER BY WebRegion) RowNum,LanguageID, LanguageCode, LanguageText, LanguageStatus, LanguageOrder, WebRegion from SysLanguages");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" where RowNum between " + ((pageIndex - 1) * pageCount + 1).ToString() + " and " + ((pageIndex - 1) * pageCount + pageCount).ToString());
            strSql.Append(" Order by RowNum ASC; ");
            strSql.Append(" select Count(*) Total from SysLanguage");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet dsSet = DbHelperSQL.Query(strSql.ToString());
            total = Convert.ToInt32(dsSet.Tables[1].Rows[0]["Total"]);
            return dsSet.Tables[0];
        }
    }
}

