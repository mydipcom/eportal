using System;

namespace MS.ECP.Model.CMS
{
    /// <summary>
    /// Category：目录（类别）实体类
    /// </summary>
    [Serializable]
    public partial class Category
    {
        public Category() { }

        private int _id;
        private string _guid;
        private string _categoryName;
        private string _languageCode;
        private string _parentGuid;

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

        public string CategoryName
        {
            set { _categoryName = value; }
            get { return _categoryName; }
        }

        public string LanguageCode
        {
            set { _languageCode = value; }
            get { return _languageCode; }
        }

        public string ParentGuid
        {
            set { _parentGuid = value; }
            get { return _parentGuid; }
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
