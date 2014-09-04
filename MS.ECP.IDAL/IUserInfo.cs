using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MS.ECP.IDAL
{
    public interface IUserInfo
    {
        bool ValidateUserName(string username, string password);

        bool ValidatePassword(string username, string password);

        bool ExistUserName(string username);

        bool ExistEmail(string email);

        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Model.UserInfo model);
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        bool Update(Model.UserInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);
        //bool DeleteList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.UserInfo GetModel(int ID);
        /// <summary>
        /// 根据Guid得到一个对象实体
        /// </summary>
        //Model.UserInfo GetModelByGuid(string guid, string languageId);
        /// <summary>
        /// 根据语言得到一个对象实体
        /// </summary>
        // Model.UserInfo GetDefaultModelByLang(string LanguageCode);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

    }
}
