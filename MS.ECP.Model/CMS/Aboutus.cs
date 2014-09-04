using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.Model.CMS
{
    /// <summary>
    /// Aboutus：关于我们 实体类
    /// </summary>
    [Serializable]
    public partial class Aboutus
    {
        public Aboutus() { }

        private int _id;
        private string _guid;
        private string _langguid; 
        private string _languageCode;
        private string _linkTitle;
        private string _content;
        private int? _status;
        private int? _sortorder;

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

        public string LinkTitle
        {
            set { _linkTitle = value; }
            get { return _linkTitle; }
        }

        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }

        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }

        public int? SortOrder
        {
            set { _sortorder = value; }
            get { return _sortorder; }
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
