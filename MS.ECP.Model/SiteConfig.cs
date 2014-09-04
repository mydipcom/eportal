using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.Model
{
    [Serializable]
    public class SiteConfig
    {
        public SiteConfig() { }

    //        <webname>Mission sky</webname>
    //<webcompany>Mssion Sky Company</webcompany>
    //<weburl>http://www.missionsky.com</weburl>
    //<webtel>123456</webtel>
    //<webfax>123456798</webfax>
    //<webmail>lucker.xia@missionsky.com</webmail>
    //<webcopyright>CopyRight @2013 - 2015 MissionSky.Com All Rights Reserved.</webcopyright>
    //<emailsmtp>smtp.exmail.qq.com</emailsmtp>
    //<emailport>465</emailport>
    //<emailfrom>lucker</emailfrom>
    //<emailusername>lucker.xia@missionsky.com</emailusername>
    //<emailpassword>lucker20131104</emailpassword>
    //<emailnickname>Mission Sky</emailnickname>

        private string _webname = "";

        public string webname
        {
            get { return _webname; }
            set { _webname = value; }
        }

        private string _webcompany = "";

        public string webcompany
        {
            get { return _webcompany; }
            set { _webcompany = value; }
        }

        private string _weburl = "";

        public string weburl
        {
            get { return _weburl; }
            set { _weburl = value; }
        }

        private string _webtel = "";

        public string webtel
        {
            get { return _webtel; }
            set { _webtel = value; }
        }

        private string _webfax = "";

        public string webfax
        {
            get { return _webfax; }
            set { _webfax = value; }
        }

        private string _webmail = "";

        public string webmail
        {
            get { return _webmail; }
            set { _webmail = value; }
        }

        private string _webcopyright = "";

        public string webcopyright
        {
            get { return _webcopyright; }
            set { _webcopyright = value; }
        }

        private string _emailsmtp = "";

        public string emailsmtp
        {
            get { return _emailsmtp; }
            set { _emailsmtp = value; }
        }

        private string _emailport = "";

        public string emailport
        {
            get { return _emailport; }
            set { _emailport = value; }
        }

        private string _emailfrom = "";

        public string emailfrom
        {
            get { return _emailfrom; }
            set { _emailfrom = value; }
        }

        private string _emailusername = "";

        public string emailusername
        {
            get { return _emailusername; }
            set { _emailusername = value; }
        }

        private string _emailpassword = "";

        public string emailpassword
        {
            get { return _emailpassword; }
            set { _emailpassword = value; }
        }

        private string _emailnickname = "";

        public string emailnickname
        {
            get { return _emailnickname; }
            set { _emailnickname = value; }
        }

    }
}
