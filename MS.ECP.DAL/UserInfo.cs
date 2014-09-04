using MS.ECP.IDAL;
using MS.ECP.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MS.ECP.DAL
{
    public partial class UserInfo : IUserInfo
    {
        public UserInfo() { }

        #region Method
        public bool ValidateUserName(string UserName, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName from UserInfo ");
            strSql.Append(" where ");
            strSql.Append(" UserName = @UserName ");
            strSql.Append(" and ");
            strSql.Append(" Password = @Password ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,250),
                    new SqlParameter("@Password", SqlDbType.NVarChar,50)                   
            };
            parameters[0].Value = UserName;
            parameters[1].Value = Password;

            return DbHelperSQL.ExistsString(strSql.ToString(), parameters);
        }

        public bool ValidatePassword(string UserName, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Password from UserInfo ");
            strSql.Append(" where ");
            strSql.Append(" UserName = @UserName ");
            strSql.Append(" and ");
            strSql.Append(" Password = @Password ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,250),
                    new SqlParameter("@Password", SqlDbType.NVarChar,50)                   
            };
            parameters[0].Value = UserName;
            parameters[1].Value = Password;

            return DbHelperSQL.ExistsString(strSql.ToString(), parameters);
        }

        public bool ExistUserName(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName from UserInfo ");
            strSql.Append(" where ");
            strSql.Append(" UserName = @UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,250),        
            };
            parameters[0].Value = UserName;

            return DbHelperSQL.ExistsString(strSql.ToString(), parameters);
        }

        public bool ExistEmail(string Email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Email from UserInfo ");
            strSql.Append(" where ");
            strSql.Append(" Email = @Email ");
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.NVarChar,250),        
            };
            parameters[0].Value = Email;

            return DbHelperSQL.ExistsString(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "UserInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
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
        public bool Add(Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("Guid,UserName,Email,Password,FirstName,LastName,PhoneNumber,UserType,Status,CreateDate,ModifyDate");
            strSql.Append(") values (");
            strSql.Append("@Guid,@UserName,@Email,@Password,@FirstName,@LastName,@PhoneNumber,@UserType,@Status,@CreateDate,@ModifyDate");
            strSql.Append(") ");

            SqlParameter[] parameters = {       
                        new SqlParameter("@Guid", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@UserName", SqlDbType.NVarChar,1000) ,
                        new SqlParameter("@Email", SqlDbType.NVarChar,1000) ,  
                        new SqlParameter("@Password", SqlDbType.NText),   
                        new SqlParameter("@FirstName", SqlDbType.NVarChar,250) ,
                        new SqlParameter("@LastName", SqlDbType.NVarChar,250) ,  
                        new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UserType", SqlDbType.Int,4) , 
                        new SqlParameter("@Status", SqlDbType.Int,4) ,
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ModifyDate", SqlDbType.DateTime)                        
            };

            parameters[0].Value = Guid.NewGuid().ToString();
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Email;
            if (model.Password == null)
            {
                parameters[3].Value = Utility.DESEncrypt.Encrypt("missionsky");
            }
            else
            {
                parameters[3].Value = model.Password;
            }
            parameters[4].Value = model.FirstName;
            parameters[5].Value = model.LastName;
            parameters[6].Value = model.PhoneNumber;
            parameters[7].Value = 1;
            parameters[8].Value = 0;
            parameters[9].Value = DateTime.Now;
            parameters[10].Value = DateTime.Now;

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

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        public bool Update(Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set");
            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" Password = @Password , ");
            strSql.Append(" FirstName = @FirstName , ");
            strSql.Append(" LastName = @LastName , ");
            strSql.Append(" PhoneNumber = @PhoneNumber , ");
            strSql.Append(" UserType = @UserType , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" ModifyDate = @ModifyDate ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {   
                        new SqlParameter("@ID", SqlDbType.Int,4) ,  
                        new SqlParameter("@Guid", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@UserName", SqlDbType.NVarChar,1000) ,
                        new SqlParameter("@Email", SqlDbType.NVarChar,1000) ,  
                        new SqlParameter("@Password", SqlDbType.NText),   
                        new SqlParameter("@FirstName", SqlDbType.NVarChar,250) ,
                        new SqlParameter("@LastName", SqlDbType.NVarChar,250) ,  
                        new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UserType", SqlDbType.Int,4) , 
                        new SqlParameter("@Status", SqlDbType.Int,4) ,
                        new SqlParameter("@CreateDate", SqlDbType.DateTime),
                        new SqlParameter("@ModifyDate", SqlDbType.DateTime)                        
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Guid;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Password;
            parameters[5].Value = model.FirstName;
            parameters[6].Value = model.LastName;
            parameters[7].Value = model.PhoneNumber;
            parameters[8].Value = model.UserType;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = DateTime.Now;


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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
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
        /// 得到一个对象实体
        /// </summary>
        public Model.UserInfo GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from UserInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4) ,
            };
            parameters[0].Value = ID;

            Model.UserInfo model = new Model.UserInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Guid"] != null && ds.Tables[0].Rows[0]["Guid"].ToString() != "")
                {
                    model.Guid = ds.Tables[0].Rows[0]["Guid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                model.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                model.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                model.PhoneNumber = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());

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
            strSql.Append("select * ");
            strSql.Append(" FROM UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
