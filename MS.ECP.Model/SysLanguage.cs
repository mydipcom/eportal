namespace MS.ECP.Model
{
    using System;

    [Serializable]
    public class SysLanguage
    {
        private string _guid;
        private string _languagecode;
        private string _languageguid;
        private int _languageid;
        private int? _languageorder = 0;
        private string _languagestatus = "0";
        private string _languagetext;
        private int? _status = 0;
        private string _webregion = "EN";

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

        public string LanguageCode
        {
            get
            {
                return this._languagecode;
            }
            set
            {
                this._languagecode = value;
            }
        }

        public string LanguageGuid
        {
            get
            {
                return this._languageguid;
            }
            set
            {
                this._languageguid = value;
            }
        }

        public int LanguageID
        {
            get
            {
                return this._languageid;
            }
            set
            {
                this._languageid = value;
            }
        }

        public int? LanguageOrder
        {
            get
            {
                return this._languageorder;
            }
            set
            {
                this._languageorder = value;
            }
        }

        public string LanguageStatus
        {
            get
            {
                return this._languagestatus;
            }
            set
            {
                this._languagestatus = value;
            }
        }

        public string LanguageText
        {
            get
            {
                return this._languagetext;
            }
            set
            {
                this._languagetext = value;
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

        public string WebRegion
        {
            get
            {
                return this._webregion;
            }
            set
            {
                this._webregion = value;
            }
        }
    }
}
