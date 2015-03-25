namespace MS.ECP.Model.CMS
{
    using System;

    [Serializable]
    public class Aboutus
    {
        private string _content;
        private string _description;
        private string _guid;
        private int _id;
        private string _keywords;
        private string _langguid;
        private string _languageCode;
        private string _linkTitle;
        private string _seotitle;
        private int? _sortorder;
        private int? _status;
        private string _url;

        public string Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
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

        public string Keywords
        {
            get
            {
                return this._keywords;
            }
            set
            {
                this._keywords = value;
            }
        }

        public string LangGuid
        {
            get
            {
                return this._langguid;
            }
            set
            {
                this._langguid = value;
            }
        }

        public string LanguageCode
        {
            get
            {
                return this._languageCode;
            }
            set
            {
                this._languageCode = value;
            }
        }

        public string LinkTitle
        {
            get
            {
                return this._linkTitle;
            }
            set
            {
                this._linkTitle = value;
            }
        }

        public string SeoTitle
        {
            get
            {
                return this._seotitle;
            }
            set
            {
                this._seotitle = value;
            }
        }

        public int? SortOrder
        {
            get
            {
                return this._sortorder;
            }
            set
            {
                this._sortorder = value;
            }
        }

        public int? Status
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

        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
            }
        }
    }
}
