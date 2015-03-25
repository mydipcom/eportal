namespace MS.ECP.Model
{
    using System;

    [Serializable]
    public class AccountInfo
    {
        private string _address;
        private string _companyname;
        private string _email;
        private int _id;
        private string _mobilephone;
        private string _name;
        private string _password;
        private string _passwordsalt;
        private bool _rememberme;
        private string _username;

        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return this._companyname;
            }
            set
            {
                this._companyname = value;
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

        public string MobilePhone
        {
            get
            {
                return this._mobilephone;
            }
            set
            {
                this._mobilephone = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string PasswordSalt
        {
            get
            {
                return this._passwordsalt;
            }
            set
            {
                this._passwordsalt = value;
            }
        }

        public bool RememberMe
        {
            get
            {
                return this._rememberme;
            }
            set
            {
                this._rememberme = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }
    }
}
