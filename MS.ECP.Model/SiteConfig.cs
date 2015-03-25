namespace MS.ECP.Model
{
    using System;

    [Serializable]
    public class SiteConfig
    {
        private string _emailfrom = "";
        private string _emailnickname = "";
        private string _emailpassword = "";
        private string _emailport = "";
        private string _emailsmtp = "";
        private string _emailusername = "";
        private string _webcompany = "";
        private string _webcopyright = "";
        private string _webfax = "";
        private string _webmail = "";
        private string _webname = "";
        private string _webtel = "";
        private string _weburl = "";

        public string emailfrom
        {
            get
            {
                return this._emailfrom;
            }
            set
            {
                this._emailfrom = value;
            }
        }

        public string emailnickname
        {
            get
            {
                return this._emailnickname;
            }
            set
            {
                this._emailnickname = value;
            }
        }

        public string emailpassword
        {
            get
            {
                return this._emailpassword;
            }
            set
            {
                this._emailpassword = value;
            }
        }

        public string emailport
        {
            get
            {
                return this._emailport;
            }
            set
            {
                this._emailport = value;
            }
        }

        public string emailsmtp
        {
            get
            {
                return this._emailsmtp;
            }
            set
            {
                this._emailsmtp = value;
            }
        }

        public string emailusername
        {
            get
            {
                return this._emailusername;
            }
            set
            {
                this._emailusername = value;
            }
        }

        public string webcompany
        {
            get
            {
                return this._webcompany;
            }
            set
            {
                this._webcompany = value;
            }
        }

        public string webcopyright
        {
            get
            {
                return this._webcopyright;
            }
            set
            {
                this._webcopyright = value;
            }
        }

        public string webfax
        {
            get
            {
                return this._webfax;
            }
            set
            {
                this._webfax = value;
            }
        }

        public string webmail
        {
            get
            {
                return this._webmail;
            }
            set
            {
                this._webmail = value;
            }
        }

        public string webname
        {
            get
            {
                return this._webname;
            }
            set
            {
                this._webname = value;
            }
        }

        public string webtel
        {
            get
            {
                return this._webtel;
            }
            set
            {
                this._webtel = value;
            }
        }

        public string weburl
        {
            get
            {
                return this._weburl;
            }
            set
            {
                this._weburl = value;
            }
        }
    }
}
