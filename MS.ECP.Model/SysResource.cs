using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.ECP.Model
{
    /// <summary>
    /// SysResource:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysResource
    {
        public SysResource()
        { }
        #region Model
        private int _id;
        private string _languagecode;
        private string _resourcepage;
        private string _resourcetype;
        private string _resourcekey;
        private string _resourcevalue;
        private string _webregion = "en-us";
        private string _codestate = "1";
        private int? _codeorder = 0;
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
        public string LanguageCode
        {
            set { _languagecode = value; }
            get { return _languagecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResourcePage
        {
            set { _resourcepage = value; }
            get { return _resourcepage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WebRegion
        {
            set { _webregion = value; }
            get { return _webregion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResourceType
        {
            set { _resourcetype = value; }
            get { return _resourcetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResourceKey
        {
            set { _resourcekey = value; }
            get { return _resourcekey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResourceValue
        {
            set { _resourcevalue = value; }
            get { return _resourcevalue; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CodeState
        {
            set { _codestate = value; }
            get { return _codestate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CodeOrder
        {
            set { _codeorder = value; }
            get { return _codeorder; }
        }
        #endregion Model

    }
}

