using System;
namespace MS.ECP.Model
{
	/// <summary>
    /// SysLanguage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysLanguage
	{
		public SysLanguage()
		{}
		#region Model
		private int _languageid;
        private string _guid;
        private string _languageguid;
		private string _languagecode;
		private string _languagetext;
		private string _languagestatus="0";
		private int? _languageorder=0;
        private int? _status = 0;
		private string _webregion="EN";
		/// <summary>
		/// 
		/// </summary>
		public int LanguageID
		{
			set{ _languageid=value;}
			get{return _languageid;}
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
        public string LanguageGuid
        {
            set { _languageguid = value; }
            get { return _languageguid; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string LanguageCode
		{
			set{ _languagecode=value;}
			get{return _languagecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LanguageText
		{
			set{ _languagetext=value;}
			get{return _languagetext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LanguageStatus
		{
			set{ _languagestatus=value;}
			get{return _languagestatus;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? LanguageOrder
		{
			set{ _languageorder=value;}
			get{return _languageorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebRegion
		{
			set{ _webregion=value;}
			get{return _webregion;}
		}
		#endregion Model

	}
}

