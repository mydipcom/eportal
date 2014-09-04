using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.Model.CMS
{
        /// <summary>
    /// Event :实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Event
    {
        public Event()
        { }
        #region Model
        private int _id;
        private string _guid;
        private string _langguid;
        private string _languagecode;
        private string _title;
        private string _content;
        private DateTime _createdate;
        private DateTime _modifydate;
        private DateTime _issuedate;
        private int _status;
        private int _level;

        private string _keywords;
        private string _description;
        private string _seotitle;
        private string _url;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LangGuid
        {
            set { _langguid = value; }
            get { return _langguid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LanguageCode
        {
            set { _languagecode = value; }
            get { return _languagecode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifyDate
        {
            set { _modifydate = value; }
            get { return _modifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime IssueDate
        {
            set { _issuedate = value; }
            get { return _issuedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Level
        {
            set { _level = value; }
            get { return _level; }
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

        #endregion Model
    }
}
