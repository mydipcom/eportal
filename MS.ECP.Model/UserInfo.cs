namespace MS.ECP.Model
{
    using System;

    [Serializable]
    public class UserInfo
    {
        private DateTime? _createtime = new DateTime?(DateTime.Now);
        private string _email;
        private string _firstname;
        private string _guid;
        private int _id;
        private string _lastname;
        private string _phonenumber;
        private string _psd;
        private int _status;
        private DateTime? _updatetime = new DateTime?(DateTime.Now);
        private string _userName;
        private int _userType;

        public DateTime? CreateTime
        {
            get
            {
                return this._createtime;
            }
            set
            {
                this._createtime = value;
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this._firstname;
            }
            set
            {
                this._firstname = value;
            }
        }

        public string Guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                this._guid = value;
            }
        }

        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastname;
            }
            set
            {
                this._lastname = value;
            }
        }

        public string Password
        {
            get
            {
                return this._psd;
            }
            set
            {
                this._psd = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this._phonenumber;
            }
            set
            {
                this._phonenumber = value;
            }
        }

        public int Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        public DateTime? UpdateTime
        {
            get
            {
                return this._updatetime;
            }
            set
            {
                this._updatetime = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
            }
        }

        public int UserType
        {
            get
            {
                return this._userType;
            }
            set
            {
                this._userType = value;
            }
        }
    }
}
