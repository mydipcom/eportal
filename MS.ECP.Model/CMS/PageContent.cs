namespace MS.ECP.Model.CMS
{
    using System;

    [Serializable]
    public class PageContent
    {
        private int _categoryID;
        private DateTime _createdate;
        private string _description;
        private string _guid;
        private int _id;
        private string _item;
        private string _itemContent;
        private string _keywords;
        private string _languageCode;
        private int _pageNumber;
        private string _seotitle;
        private string _url;

        public int CategoryID
        {
            get
            {
                return this._categoryID;
            }
            set
            {
                this._categoryID = value;
            }
        }

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

        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        public string ItemContent
        {
            get
            {
                return this._itemContent;
            }
            set
            {
                this._itemContent = value;
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

        public int PageNumber
        {
            get
            {
                return this._pageNumber;
            }
            set
            {
                this._pageNumber = value;
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
    }
}
