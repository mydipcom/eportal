namespace MS.ECP.Model.CMS
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class News
    {
        private string _content;
        private DateTime _createdate;
        private string _description;
        private string _guid;
        private int _id;
        private DateTime _issuedate;
        private string _keywords;
        private string _langguid;
        private string _languagecode;
        private int _level;
        private DateTime _modifydate;
        private string _seotitle;
        private int _status;
        private string _title;
        private string _url;

        public News()
        {
            this.Inputs = new List<NewsInput>();
        }

        public string Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public DateTime CreateDate
        {
            get { return this._createdate; }
            set { this._createdate = value; }
        }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public string Guid
        {
            get { return this._guid; }
            set { this._guid = value; }
        }

        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public IList<NewsInput> Inputs { get; set; }

        public DateTime IssueDate
        {
            get { return this._issuedate; }
            set { this._issuedate = value; }
        }

        public string Keywords
        {
            get { return this._keywords; }
            set { this._keywords = value; }
        }

        public string LangGuid
        {
            get { return this._langguid; }
            set { this._langguid = value; }
        }

        public string LanguageCode
        {
            get { return this._languagecode; }
            set { this._languagecode = value; }
        }

        public int Level
        {
            get { return this._level; }
            set { this._level = value; }
        }

        public DateTime ModifyDate
        {
            get { return this._modifydate; }
            set { this._modifydate = value; }
        }

        public string SeoTitle
        {
            get { return this._seotitle; }
            set { this._seotitle = value; }
        }

        public string Specification { get; set; }

        public int Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }
    }



    public class NewsInput
    {
        public int ID { get; set; }

        public string InputName { get; set; }

        public string Inputtitle { get; set; }

        public int InputType { get; set; }

        public string InputValue { get; set; }

        public bool IsAllowNull { get; set; }

        public string LangGuid { get; set; }
    }


}
