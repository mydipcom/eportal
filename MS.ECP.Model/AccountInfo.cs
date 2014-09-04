using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.Model
{
    /// <summary>
    /// AccountInfo：用户 实体类
    /// </summary>
    [Serializable]
    public class AccountInfo
    {
        public AccountInfo() { }

        private int _id;
       // private string _userGUID;
        private string _username; 
        private string _password;
        private string _passwordsalt;
        private string _name;
        private string _mobilephone;
        private string _email;
        private string _address;
        private string _companyname;
      //  private int _usertype;
     //   private int _active;
     //   private string _lastIPaddress;
     //   private DateTime _createonUTC ;
     //   private DateTime _lastlogindateUTC;
     //   private DateTime _modifydateUTC;
     //   private int _status;
        private bool _rememberme;


        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        public string UserName 
        {
            set { _username = value; }
            get { return _username; }
        }

        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        public string PasswordSalt
        {
            set { _passwordsalt = value; }
            get { return _passwordsalt; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string MobilePhone 
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }

        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }

        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }

        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }


        //public string UserGUID
        //{
        //    set { _userGUID = value; }
        //    get { return _userGUID; }
        //}

        //public int UserType
        //{
        //    set { _usertype = value; }
        //    get { return _usertype; }
        //}
        //public int Active
        //{
        //    set { _active = value; }
        //    get { return _active; }
        //}

        //public string LastIPAddress
        //{
        //    set { _lastIPaddress = value; }
        //    get { return _lastIPaddress; }
        //}

        //public DateTime CreateOnUTC
        //{
        //    set { _createonUTC = value; }
        //    get { return _createonUTC; }
        //}

        //public DateTime LastLoginDateUTC
        //{
        //    set { _lastlogindateUTC = value; }
        //    get { return _lastlogindateUTC; }
        //}

        //public DateTime ModifyDateUTC
        //{
        //    set { _modifydateUTC = value; }
        //    get { return _modifydateUTC; }
        //}

        //public int Status 
        //{
        //    set { _status = value; }
        //    get { return _status; }
        //}

        public bool RememberMe
        {
            set { _rememberme = value; }
            get { return _rememberme; }
        }
    }
}
