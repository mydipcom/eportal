namespace MS.ECP.Model
{
    using System;

    [Serializable]
    public class SysResource
    {
        private int? _codeorder = 0;
        private string _codestate = "1";
        private int _id;
        private string _languagecode;
        private string _resourcekey;
        private string _resourcepage;
        private string _resourcetype;
        private string _resourcevalue;
        private string _webregion = "en-us";

        public int? CodeOrder
        {
            get
            {
                return this._codeorder;
            }
            set
            {
                this._codeorder = value;
            }
        }

        public string CodeState
        {
            get
            {
                return this._codestate;
            }
            set
            {
                this._codestate = value;
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

        public string LanguageCode
        {
            get
            {
                return this._languagecode;
            }
            set
            {
                this._languagecode = value;
            }
        }

        public string ResourceKey
        {
            get
            {
                return this._resourcekey;
            }
            set
            {
                this._resourcekey = value;
            }
        }

        public string ResourcePage
        {
            get
            {
                return this._resourcepage;
            }
            set
            {
                this._resourcepage = value;
            }
        }

        public string ResourceType
        {
            get
            {
                return this._resourcetype;
            }
            set
            {
                this._resourcetype = value;
            }
        }

        public string ResourceValue
        {
            get
            {
                return this._resourcevalue;
            }
            set
            {
                this._resourcevalue = value;
            }
        }

        public string WebRegion
        {
            get
            {
                return this._webregion;
            }
            set
            {
                this._webregion = value;
            }
        }
    }
}
