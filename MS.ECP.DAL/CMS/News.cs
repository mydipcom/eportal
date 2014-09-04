using MS.ECP.IDAL.CMS;
using MS.ECP.Model.CMS;
using MS.ECP.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MS.ECP.DAL.CMS
{
     /// <summary>
    /// 数据访问类:News
    /// </summary>
    public partial class News : INews
    {

        public News()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CmsNews");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CmsNews");
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
        public bool Add(Model.CMS.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CmsNews(");
            strSql.Append("Guid,LangGuid,LanguageCode,Title,Content,CreateDate,ModifyDate,Status,IssueDate,Level,Keywords,Description,SeoTitle,Url,Specification)");
            strSql.Append(" values (");
            strSql.Append("@Guid,@LangGuid,@LanguageCode,@Title,@Content,@CreateDate,@ModifyDate,@Status,@IssueDate,@Level,@Keywords,@Description,@SeoTitle,@Url,@Specification)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Guid",SqlDbType.NVarChar,1000),  
                    new SqlParameter("@LangGuid",SqlDbType.NVarChar,1000),          
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@Title", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Content", SqlDbType.NText),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@ModifyDate", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@IssueDate", SqlDbType.DateTime),
                    new SqlParameter("@Level", SqlDbType.Int,4),
                    new SqlParameter("@Keywords", SqlDbType.NVarChar,1000) ,            
                    new SqlParameter("@Description", SqlDbType.NText), 
                    new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                    new SqlParameter("@Url", SqlDbType.NVarChar,225) ,
                    new SqlParameter("@Specification", SqlDbType.NVarChar) 
            };

            parameters[0].Value = Guid.NewGuid().ToString();
            if (model.LangGuid == null || model.LangGuid == "")
            {
                parameters[1].Value = Guid.NewGuid().ToString();
            }
            else
            {
                parameters[1].Value = model.LangGuid;
            }
            
            parameters[2].Value = model.LanguageCode;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Content;
            parameters[5].Value = DateTime.Now;
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = 1;
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = 0;
            parameters[10].Value = model.Keywords;
            parameters[11].Value = model.Description;
            parameters[12].Value = model.SeoTitle;
            parameters[13].Value = model.Url;
            parameters[14].Value = model.Specification; 
            int rows =  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
         /// 增加一条数据
         /// </summary>
         public bool Add(Model.CMS.NewsInput model)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("insert into CmsNews_Campaign(");
             strSql.Append("[LangGuid],[Inputtitle],[InputType],[IsAllowNull],[InputName],[InputValue])");
             strSql.Append(" values (");
             strSql.Append("@LangGuid,@Inputtitle,@InputType,@IsAllowNull,@InputName,@InputValue)");
             SqlParameter[] parameters =
             {
                 new SqlParameter("@LangGuid", SqlDbType.NVarChar),
                 new SqlParameter("@Inputtitle", SqlDbType.NVarChar),
                 new SqlParameter("@InputType", SqlDbType.Int),
                 new SqlParameter("@IsAllowNull", SqlDbType.Bit),
                 new SqlParameter("@InputName", SqlDbType.NVarChar),
                    new SqlParameter("@InputValue", SqlDbType.NVarChar)
             };


             parameters[0].Value = model.LangGuid;
             parameters[1].Value = model.Inputtitle;
             parameters[2].Value = model.InputType;
             parameters[3].Value = model.IsAllowNull;
             parameters[4].Value = model.InputName;
             parameters[5].Value = model.InputValue;

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
        public bool Update(Model.CMS.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsNews set ");
            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" LangGuid = @LangGuid , ");
            strSql.Append(" LanguageCode = @LanguageCode , ");
            strSql.Append(" Title = @Title , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" ModifyDate = @ModifyDate , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" IssueDate = @IssueDate , ");
            strSql.Append(" Level = @Level , ");
            strSql.Append(" Keywords = @Keywords , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" SeoTitle = @SeoTitle ,  ");
            strSql.Append(" Url = @Url , ");
            strSql.Append(" Specification = @Specification  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4) ,
                    new SqlParameter("@Guid",SqlDbType.NVarChar,1000),
                    new SqlParameter("@LangGuid", SqlDbType.NVarChar,1000) ,
                    new SqlParameter("@LanguageCode", SqlDbType.VarChar,50),
                    new SqlParameter("@Title", SqlDbType.NVarChar,1000), 
                    new SqlParameter("@Content", SqlDbType.NText),
                    new SqlParameter("@ModifyDate", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@IssueDate", SqlDbType.DateTime),
                    new SqlParameter("@Level", SqlDbType.Int,4),
                    new SqlParameter("@Keywords", SqlDbType.NVarChar,50) ,            
                    new SqlParameter("@Description", SqlDbType.NText) ,            
                    new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                    new SqlParameter("@Url", SqlDbType.NVarChar,225) ,
                      new SqlParameter("@Specification", SqlDbType.NVarChar) 
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Guid;
            parameters[2].Value = model.LangGuid;
            parameters[3].Value = model.LanguageCode;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Content;
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = 1;
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = 0;
            parameters[10].Value = model.Keywords;
            parameters[11].Value = model.Description;
            parameters[12].Value = model.SeoTitle;
            parameters[13].Value = model.Url;
            parameters[14].Value = model.Specification;
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
         public bool Update(Model.CMS.NewsInput model)
         {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("update CmsNews_Campaign set ");
             strSql.Append(" Inputtitle = @Inputtitle , ");
             strSql.Append(" InputType = @InputType , ");
             strSql.Append(" IsAllowNull = @IsAllowNull ");
             strSql.Append(" where ID=@ID ");
             SqlParameter[] parameters =
             {
                 new SqlParameter("@ID", SqlDbType.Int, 4),
                 new SqlParameter("@Inputtitle", SqlDbType.NVarChar, 1000),
                 new SqlParameter("@InputType", SqlDbType.Int),
                 new SqlParameter("@IsAllowNull", SqlDbType.Bit)
             };
             parameters[0].Value = model.ID;
             parameters[1].Value = model.Inputtitle;
             parameters[2].Value = model.InputType;
             parameters[3].Value = model.IsAllowNull;


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
        /// 更新一条数据 SEO
        /// </summary>
        public bool UpdateSeo(Model.CMS.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CmsNews set ");
            strSql.Append(" Keywords = @Keywords , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" SeoTitle = @SeoTitle ,  ");
             strSql.Append(" Url = @Url , Specification= @Specification ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Keywords", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Description", SqlDbType.NText) ,            
                        new SqlParameter("@SeoTitle", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,225),
                       new SqlParameter("@Specification", SqlDbType.NVarChar)   
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Keywords;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.SeoTitle;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.Specification;
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
            strSql.Append("delete from CmsNews ");
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
        /// 根据LangGuid删除数据
        /// </summary>
        public bool DeleteByLangGuid(string langGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CmsNews ");
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CmsNews ");
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

        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        public Model.CMS.News GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsNews ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4) ,
            };
            parameters[0].Value = ID;

            Model.CMS.News model = new Model.CMS.News();
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
                if (ds.Tables[0].Rows[0]["LangGuid"] != null && ds.Tables[0].Rows[0]["LangGuid"].ToString() != "")
                {
                    model.LangGuid = ds.Tables[0].Rows[0]["LangGuid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                model.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueDate"] == null)
                {
                    model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                model.Specification = ds.Tables[0].Rows[0]["Specification"].ToString();
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
         public Model.CMS.NewsInput GetNewsInputModel(int ID)
         {

             StringBuilder strSql = new StringBuilder();
             strSql.Append("select *  ");
             strSql.Append("  from CmsNews_Campaign ");
             strSql.Append(" where ID=@ID ");
             SqlParameter[] parameters =
             {
                 new SqlParameter("@ID", SqlDbType.Int, 4),
             };
             parameters[0].Value = ID;

             Model.CMS.NewsInput model = new Model.CMS.NewsInput();
             DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

             if (ds.Tables[0].Rows.Count > 0)
             {
                 if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                 {
                     model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                 }
                 if (ds.Tables[0].Rows[0]["Inputtitle"] != null && ds.Tables[0].Rows[0]["Inputtitle"].ToString() != "")
                 {
                     model.Inputtitle = ds.Tables[0].Rows[0]["Inputtitle"].ToString();
                 }
                 if (ds.Tables[0].Rows[0]["LangGuid"] != null && ds.Tables[0].Rows[0]["LangGuid"].ToString() != "")
                 {
                     model.LangGuid = ds.Tables[0].Rows[0]["LangGuid"].ToString();
                 }
                 if (ds.Tables[0].Rows[0]["InputType"] != null && ds.Tables[0].Rows[0]["InputType"].ToString() != "")
                 {
                     model.InputType = int.Parse(ds.Tables[0].Rows[0]["InputType"].ToString());
                 }
                 if (ds.Tables[0].Rows[0]["IsAllowNull"] != null && ds.Tables[0].Rows[0]["IsAllowNull"].ToString() != "")
                 {
                     model.IsAllowNull = bool.Parse(ds.Tables[0].Rows[0]["IsAllowNull"].ToString());
                 }
                 if (ds.Tables[0].Rows[0]["InputName"] != null && ds.Tables[0].Rows[0]["InputName"].ToString() != "")
                 {
                     model.InputName = ds.Tables[0].Rows[0]["InputName"].ToString();
                 }
                 if (ds.Tables[0].Rows[0]["InputValue"] != null && ds.Tables[0].Rows[0]["InputValue"].ToString() != "")
                 {
                     model.InputValue = ds.Tables[0].Rows[0]["InputValue"].ToString();
                 }

                 return model;
             }
             else
             {
                 return null;
             }
         }



         /// <summary>
         /// 根据LangGuid得到一个对象实体
         /// </summary>
         public Model.CMS.News GetModelByGuid(string langGuid, string languageId)
         {

             StringBuilder strSql = new StringBuilder();
             strSql.Append("select *  ");
             strSql.Append("  from CmsNews ");
             strSql.Append(" where LangGuid=@LangGuid ");
             strSql.Append(" and LanguageCode=@LanguageCode ");
             SqlParameter[] parameters =
             {
                 new SqlParameter("@LangGuid", SqlDbType.NVarChar, 1000),
                 new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 50),
             };
             parameters[0].Value = langGuid;
             parameters[1].Value = languageId;

             Model.CMS.News model = new Model.CMS.News();
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
                 if (ds.Tables[0].Rows[0]["LangGuid"] != null && ds.Tables[0].Rows[0]["LangGuid"].ToString() != "")
                 {
                     model.LangGuid = ds.Tables[0].Rows[0]["LangGuid"].ToString();
                 }
                 if (ds.Tables[0].Rows[0]["LanguageCode"] != null &&
                     ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                 {
                     model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                 }
                 if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                 {
                     model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                 }
                 if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                 {
                     model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                 }
                 model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                 model.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                 if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                 {
                     model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                 }
                 if (ds.Tables[0].Rows[0]["IssueDate"] == null)
                 {
                     model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                 }
                 if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                 {
                     model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                 }
                 model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                 model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                 model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                 model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                 model.Specification = ds.Tables[0].Rows[0]["Specification"].ToString();


                 strSql.Clear();
                 strSql.Append("select *  ");
                 strSql.Append(" from CmsNews_Campaign ");
                 strSql.Append(string.Format(" where LangGuid='{0}' ", langGuid));
                 DataSet dst = DbHelperSQL.Query(strSql.ToString());
                 var dt = dst.Tables[0];
                 if (dt.Rows.Count == 0) return model;
                 for (var i = 0; i < dt.Rows.Count; i++)
                 {
                     var row = dt.Rows[i];
                     var inputnew = new NewsInput
                     {
                         ID = int.Parse(row["ID"].ToString()),
                         Inputtitle = row["Inputtitle"].ToString(),
                         InputType = int.Parse(row["InputType"].ToString()),
                         IsAllowNull = bool.Parse(row["IsAllowNull"].ToString()),
                         InputName = row["InputName"].ToString(),
                         InputValue = (row["InputValue"] ?? "").ToString(),
                     };

                     model.Inputs.Add(inputnew);
                 }


                 return model;
             }
             else
             {
                 return null;
             }
         }

         /// <summary>
        /// 根据Language得到一个对象实体
        /// </summary>
        public Model.CMS.News GetDefaultModelByLang(string LanguageCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from CmsNews ");
            strSql.Append(" where LanguageCode=@LanguageCode ");
            strSql.Append(" order by CreateDate desc  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = LanguageCode;

            Model.CMS.News model = new Model.CMS.News();
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
                if (ds.Tables[0].Rows[0]["LangGuid"] != null && ds.Tables[0].Rows[0]["LangGuid"].ToString() != "")
                {
                    model.LangGuid = ds.Tables[0].Rows[0]["LangGuid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                model.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueDate"] == null)
                {
                    model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                model.Specification = ds.Tables[0].Rows[0]["Specification"].ToString();
                
                return model;
            }
            else
            {
                return null;
            }
        }

         /// <summary>
        /// 根据LanguageCode得到一个最新对象实体
        /// </summary>
        public Model.CMS.News GetNewestModelByLangCode(string LanguageCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 *  ");
            strSql.Append("  from CmsNews ");
            strSql.Append(" where LanguageCode=@LanguageCode ");
            strSql.Append(" order by CreateDate desc  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LanguageCode", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = LanguageCode;

            Model.CMS.News model = new Model.CMS.News();
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
                if (ds.Tables[0].Rows[0]["LangGuid"] != null && ds.Tables[0].Rows[0]["LangGuid"].ToString() != "")
                {
                    model.LangGuid = ds.Tables[0].Rows[0]["LangGuid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LanguageCode"] != null && ds.Tables[0].Rows[0]["LanguageCode"].ToString() != "")
                {
                    model.LanguageCode = ds.Tables[0].Rows[0]["LanguageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                model.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueDate"] == null)
                {
                    model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["SeoTitle"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                model.Specification = ds.Tables[0].Rows[0]["Specification"].ToString();
                
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 从缓存中得到一个对象实体
        /// </summary>
        public Model.CMS.News GetModelByCache(int ID)
        {
            string CacheKey = "NewsModel-" + ID;
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
            return (Model.CMS.News)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Model.CMS.News> GetList(string strWhere)
        {
            DataSet ds = GetDataSet(strWhere);
            DataTable dt = ds.Tables[0];

            IList<Model.CMS.News> modelList = new List<Model.CMS.News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.News();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }
                    model.Keywords = dt.Rows[n]["Keywords"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    model.SeoTitle = dt.Rows[n]["SeoTitle"].ToString();
                    model.Url = dt.Rows[n]["Url"].ToString();
                    model.Specification = dt.Rows[n]["Specification"].ToString();
                    
                    modelList.Add(model);
                }
            }

            return modelList;
        }
        /// <summary>
        /// 获得数据列表 DataSet
        /// </summary>
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CmsNews ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CreateDate desc");
            
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM CmsNews ");
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
         public IList<Model.CMS.News> GetListByPage(string strWhere, int startIndex, int endIndex)
         {
             DataSet ds = GetListDataSetByPage(strWhere, startIndex, endIndex);
             DataTable dt = ds.Tables[0];
             IList<Model.CMS.News> modelList = new List<Model.CMS.News>();
             int rowsCount = dt.Rows.Count;
             if (rowsCount > 0)
             {
                 Model.CMS.News model;
                 for (int n = 0; n < rowsCount; n++)
                 {
                     model = new Model.CMS.News();

                     if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                     {
                         model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                     }
                     if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                     {
                         model.Guid = dt.Rows[n]["Guid"].ToString();
                     }
                     if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                     {
                         model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                     }
                     if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                     {
                         model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                     }
                     if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                     {
                         model.Title = dt.Rows[n]["Title"].ToString();
                     }
                     if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                     {
                         model.Content = dt.Rows[n]["Content"].ToString();
                     }
                     model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                     model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                     if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                     {
                         model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                     }
                     if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                     {
                         model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                     }
                     if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                     {
                         model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                     }


                     var strSql = new StringBuilder();
                     strSql.Append("select *  ");
                     strSql.Append(" from CmsNews_Campaign ");
                     strSql.Append(string.Format(" where LangGuid='{0}' ", model.LangGuid));
                     DataSet dst = DbHelperSQL.Query(strSql.ToString());
                     var dts = dst.Tables[0];
                     for (var i = 0; i < dts.Rows.Count; i++)
                     {
                         var row = dts.Rows[i];
                         var inputnew = new NewsInput
                         {
                             ID = int.Parse(row["ID"].ToString()),
                             Inputtitle = row["Inputtitle"].ToString(),
                             InputType = int.Parse(row["InputType"].ToString()),
                             IsAllowNull = bool.Parse(row["IsAllowNull"].ToString()),
                             InputName = row["InputName"].ToString(),
                             InputValue =( row["InputValue"]??"").ToString(),
                             
                         };

                         model.Inputs.Add(inputnew);
                     }


                     model.Keywords = dt.Rows[n]["Keywords"].ToString();
                     model.Description = dt.Rows[n]["Description"].ToString();
                     model.SeoTitle = dt.Rows[n]["SeoTitle"].ToString();
                     model.Url = dt.Rows[n]["Url"].ToString();
                     model.Specification = dt.Rows[n]["Specification"].ToString();
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
             strSql.Append("order by T.CreateDate desc");
             strSql.Append(")AS Row, T.*  from CmsNews T ");
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
        public IList<Model.CMS.News> GetList(int Top, string strWhere)
        {
            DataSet ds = GetListDataSet(Top, strWhere);
            DataTable dt = ds.Tables[0];
            IList<Model.CMS.News> modelList = new List<Model.CMS.News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.News();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }
                    model.Keywords = dt.Rows[n]["Keywords"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    model.SeoTitle = dt.Rows[n]["SeoTitle"].ToString();
                    model.Url = dt.Rows[n]["Url"].ToString();
                    model.Specification = dt.Rows[n]["Specification"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public DataSet GetListDataSet(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM CmsNews ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CreateDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据Language获得分页数据列表
        /// </summary>
        public IList<Model.CMS.News> GetPagingByLangCode(int startIndex, int endIndex, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(startIndex, endIndex, orderby, LangCode);
            DataTable dt = ds.Tables[0];
            IList<Model.CMS.News> modelList = new List<Model.CMS.News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.News();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }
                    model.Keywords = dt.Rows[n]["Keywords"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    model.SeoTitle = dt.Rows[n]["SeoTitle"].ToString();
                    model.Url = dt.Rows[n]["Url"].ToString();
                    model.Specification = dt.Rows[n]["Specification"].ToString();
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
            strSql.Append(")AS Row, T.*  from CmsNews T ");
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
        /// 根据Language获得前几行数据
        /// </summary>
        public IList<Model.CMS.News> GetPagingByLangCode(int Top, string orderby, string LangCode)
        {
            DataSet ds = GetDataSetByLangCode(Top, orderby, LangCode);
            DataTable dt = ds.Tables[0];
            IList<Model.CMS.News> modelList = new List<Model.CMS.News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.CMS.News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.CMS.News();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Guid"] != null && dt.Rows[n]["Guid"].ToString() != "")
                    {
                        model.Guid = dt.Rows[n]["Guid"].ToString();
                    }
                    if (dt.Rows[n]["LangGuid"] != null && dt.Rows[n]["LangGuid"].ToString() != "")
                    {
                        model.LangGuid = dt.Rows[n]["LangGuid"].ToString();
                    }
                    if (dt.Rows[n]["LanguageCode"] != null && dt.Rows[n]["LanguageCode"].ToString() != "")
                    {
                        model.LanguageCode = dt.Rows[n]["LanguageCode"].ToString();
                    }
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    model.ModifyDate = DateTime.Parse(dt.Rows[n]["ModifyDate"].ToString());
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["IssueDate"] == null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.IssueDate = DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
                    }
                    if (dt.Rows[n]["Level"] != null && dt.Rows[n]["Level"].ToString() != "")
                    {
                        model.Level = int.Parse(dt.Rows[n]["Level"].ToString());
                    }
                    model.Keywords = dt.Rows[n]["Keywords"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    model.SeoTitle = dt.Rows[n]["SeoTitle"].ToString();
                    model.Url = dt.Rows[n]["Url"].ToString();
                    model.Specification = dt.Rows[n]["Specification"].ToString();
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
            strSql.Append(" FROM CmsNews ");
            if (LangCode.Trim() != "")
            {
                strSql.Append(" WHERE LanguageCode=@LanguageCode ");
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



        public bool DeleteInput(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CmsNews_Campaign ");
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
    }
}
