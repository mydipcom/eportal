namespace MS.ECP.Model.CMS
{
    using System;

    [Serializable]
    public class Category
    {
        private string _categoryName;
        private string _description;
        private string _guid;
        private int _id;
        private string _keywords;
        private string _languageCode;
        private string _parentGuid;
        private string _seotitle;
        private string _url;

        public string CategoryName
        {
            get
            {
                return this._categoryName;
            }
            set
            {
                this._categoryName = value;
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

        public string ParentGuid
        {
            get
            {
                return this._parentGuid;
            }
            set
            {
                this._parentGuid = value;
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
