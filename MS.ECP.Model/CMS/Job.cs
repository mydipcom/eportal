using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.Model.CMS
{
    /// <summary>
    /// Job：招聘职位 实体类
    /// </summary>
    [Serializable]
    public partial class Job
    {
        public Job() { }

        private int _id;
        private string _guid;
        private string _langguid; 
        private string _languageCode;
        private string _jobTitle;
        private int _needNum;
        private string _workplace;
        private string _salary;
        private string _languageRequired;
        private string _jobBligation;
        private string _jobDesc;
        private int _orderNum;
        private DateTime _createdate;

        private string _keywords;
        private string _description;
        private string _seotitle;
        private string _url;


        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }

        public string LangGuid
        {
            set { _langguid = value; }
            get { return _langguid; }
        }

        public string LanguageCode
        {
            set { _languageCode = value; }
            get { return _languageCode; }
        }

        public string JobTitle
        {
            set { _jobTitle = value; }
            get { return _jobTitle; }
        }

        public int NeedNum
        {
            set { _needNum = value; }
            get { return _needNum; }
        }
        public string Workplace
        {
            set { _workplace = value; }
            get { return _workplace; }
        }

        public string Salary
        {
            set { _salary = value; }
            get { return _salary; }
        }

        public string LanguageRequired
        {
            set { _languageRequired = value; }
            get { return _languageRequired; }
        }

        public string JobBligation
        {
            set { _jobBligation = value; }
            get { return _jobBligation; }
        }
        public string JobDesc
        {
            set { _jobDesc = value; }
            get { return _jobDesc; }
        }

        public int OrderNum
        {
            set { _orderNum = value; }
            get { return _orderNum; }
        }

        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }

        public string Keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        public string SeoTitle
        {
            set { _seotitle = value; }
            get { return _seotitle; }
        }

        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
    }
}
