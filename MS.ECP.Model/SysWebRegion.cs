using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.Model
{
    [Serializable]
    public partial class SysWebRegion
    {
        #region Model
        private string _langcode;
        private string _langtext;
        private int _displayorder = 1;
        private int _status = 1;

        /// <summary>
        /// 
        /// </summary>
        public string LangCode
        {
            set { _langcode = value; }
            get { return _langcode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LangText
        {
            set { _langtext = value; }
            get { return _langtext; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int DisplayOrder
        {
            set { _displayorder = value; }
            get { return _displayorder; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model
    }
}
