using MS.ECP.DALFactory;
using MS.ECP.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MS.ECP.BLL
{
    public class UserInfo
    {
        private readonly IUserInfo dal = DataAccess.CreateUserInfo();

        public UserInfo() { }

        #region  Method
        public bool ValidateUserName(string UserName, string Password)
        {
            return dal.ValidateUserName(UserName, Password);
        }

        public bool ValidatePassword(string UserName, string Password)
        {
            return dal.ValidatePassword(UserName, Password);
        }

        public bool ExistUserName(string UserName)
        {
            return dal.ExistUserName(UserName);
        }

        public bool ExistEmail(string Email)
        {
            return dal.ExistEmail(Email);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.UserInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.UserInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UserInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion
    }
}
