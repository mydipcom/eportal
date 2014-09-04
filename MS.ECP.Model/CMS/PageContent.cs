using System;

namespace MS.ECP.Model.CMS
{
    /// <summary>
    /// PageContent：内容实体类
    /// </summary>
    [Serializable]
    public partial class PageContent
    {
        public PageContent() { }

        #region Model
        private int _id;
        private string _guid;
        private int _pageNumber;
        private string _item;
        private string _itemContent;
        private string _languageCode;
        private int _categoryID;
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

        public int PageNumber
        {
            set { _pageNumber = value; }
            get { return _pageNumber; }
        }

        public string Item
        {
            set { _item = value; }
            get { return _item; }
        }

        public string ItemContent
        {
            set { _itemContent = value; }
            get { return _itemContent; }
        }

        public string LanguageCode
        {
            set { _languageCode = value; }
            get { return _languageCode; }
        }

        public int CategoryID
        {
            set { _categoryID = value; }
            get { return _categoryID; }
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

        #endregion
    }
}
