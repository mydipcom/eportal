namespace MS.ECP.Model.CMS
{
    using System;

    [Serializable]
    public class Job
    {
        private DateTime _createdate;
        private string _description;
        private string _guid;
        private int _id;
        private string _jobBligation;
        private string _jobDesc;
        private string _jobTitle;
        private string _keywords;
        private string _langguid;
        private string _languageCode;
        private string _languageRequired;
        private int _needNum;
        private int _orderNum;
        private string _salary;
        private string _seotitle;
        private string _url;
        private string _workplace;

        public DateTime CreateDate
        {
            get
            {
                return this._createdate;
            }
            set
            {
                this._createdate = value;
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

        public string JobBligation
        {
            get
            {
                return this._jobBligation;
            }
            set
            {
                this._jobBligation = value;
            }
        }

        public string JobDesc
        {
            get
            {
                return this._jobDesc;
            }
            set
            {
                this._jobDesc = value;
            }
        }

        public string JobTitle
        {
            get
            {
                return this._jobTitle;
            }
            set
            {
                this._jobTitle = value;
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

        public string LanguageRequired
        {
            get
            {
                return this._languageRequired;
            }
            set
            {
                this._languageRequired = value;
            }
        }

        public int NeedNum
        {
            get
            {
                return this._needNum;
            }
            set
            {
                this._needNum = value;
            }
        }

        public int OrderNum
        {
            get
            {
                return this._orderNum;
            }
            set
            {
                this._orderNum = value;
            }
        }

        public string Salary
        {
            get
            {
                return this._salary;
            }
            set
            {
                this._salary = value;
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

        public string Workplace
        {
            get
            {
                return this._workplace;
            }
            set
            {
                this._workplace = value;
            }
        }
    }
}
