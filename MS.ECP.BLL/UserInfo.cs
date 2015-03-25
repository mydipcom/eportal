using MS.ECP.DALFactory;

namespace MS.ECP.BLL
{
    using MS.ECP.IDAL;
    using MS.ECP.Model;
    using System;
    using System.Data;

    public class UserInfo
    {
        private readonly IUserInfo dal = DataAccess.CreateUserInfo();

        public bool Add(MS.ECP.Model.UserInfo model)
        {
            return this.dal.Add(model);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        public bool ExistEmail(string Email)
        {
            return this.dal.ExistEmail(Email);
        }

        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }

        public bool ExistUserName(string UserName)
        {
            return this.dal.ExistUserName(UserName);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public MS.ECP.Model.UserInfo GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }

        public bool Update(MS.ECP.Model.UserInfo model)
        {
            return this.dal.Update(model);
        }

        public bool ValidatePassword(string UserName, string Password)
        {
            return this.dal.ValidatePassword(UserName, Password);
        }

        public bool ValidateUserName(string UserName, string Password)
        {
            return this.dal.ValidateUserName(UserName, Password);
        }
    }
}
