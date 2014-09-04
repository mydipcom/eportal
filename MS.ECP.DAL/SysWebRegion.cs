using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MS.ECP.IDAL;
using MS.ECP.Utility;

namespace MS.ECP.DAL
{
    public class SysWebRegion : ISysWebRegion
    {
        public SysWebRegion()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LangCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysWebRegion");
            strSql.Append(" where LangCode=@LangCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@LangCode", SqlDbType.VarChar,10)			};
            parameters[0].Value = LangCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MS.ECP.Model.SysWebRegion GetModel(string LangCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LangCode,LangText,Status,DisplayOrder from SysWebRegion ");
            strSql.Append(" where LangCode=@LangCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@LangCode", SqlDbType.VarChar,10)			};
            parameters[0].Value = LangCode;

            MS.ECP.Model.SysWebRegion model = new MS.ECP.Model.SysWebRegion();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                if (ds.Tables[0].Rows[0]["LangCode"] != null && ds.Tables[0].Rows[0]["LangCode"].ToString() != "")
                {
                    model.LangCode = ds.Tables[0].Rows[0]["LangCode"].ToString();
                }

                if (ds.Tables[0].Rows[0]["LangText"] != null && ds.Tables[0].Rows[0]["LangText"].ToString() != "")
                {
                    model.LangText = ds.Tables[0].Rows[0]["LangText"].ToString();
                }

                if (ds.Tables[0].Rows[0]["DisplayOrder"] != null && ds.Tables[0].Rows[0]["DisplayOrder"].ToString() != "")
                {
                    model.DisplayOrder = int.Parse(ds.Tables[0].Rows[0]["DisplayOrder"].ToString());
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LangCode,LangText,Status,LangOrder ");
            strSql.Append(" FROM SysLanguage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by LangOrder ASC ");
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
            strSql.Append(" LangCode,LangText,Status,LangOrder ");
            strSql.Append(" FROM SysLanguage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SysWebRegion ");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.LangCode desc");
            }
            strSql.Append(")AS Row, T.*  from SysWebRegion T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        #endregion  Method
    }
}

