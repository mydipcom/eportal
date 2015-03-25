namespace MS.ECP.Model
{
    using System;

    [Serializable]
    public class SysWebRegion
    {
        private int _displayorder = 1;
        private string _langcode;
        private string _langtext;
        private int _status = 1;

        public int DisplayOrder
        {
            get
            {
                return this._displayorder;
            }
            set
            {
                this._displayorder = value;
            }
        }

        public string LangCode
        {
            get
            {
                return this._langcode;
            }
            set
            {
                this._langcode = value;
            }
        }

        public string LangText
        {
            get
            {
                return this._langtext;
            }
            set
            {
                this._langtext = value;
            }
        }

        public int Status
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
    }
}
