using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.Model
{
    /// <summary>
    /// UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UserInfo
    {
        public UserInfo()
        { }

        #region Model
        private int _id;
        private string _guid;
        private string _userName;
        private string _email;
        private string _firstname;
        private string _lastname;
        private string _phonenumber;
        private int _userType;
        private int _status;
        private string _psd;
        private DateTime? _createtime = DateTime.Now;
        private DateTime? _updatetime = DateTime.Now;


        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _userName = value; }
            get { return _userName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName
        {
            set { _firstname = value; }
            get { return _firstname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LastName
        {
            set { _lastname = value; }
            get { return _lastname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber
        {
            set { _phonenumber = value; }
            get { return _phonenumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _psd = value; }
            get { return _psd; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int UserType
        {
            set { _userType = value; }
            get { return _userType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        #endregion Model

    }
}

