using System;

namespace MS.ECP.Model
{
   public class MultiNews
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string LangGuid { get; set; }
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int Status { get; set; } 
        public DateTime? IssueDate { get; set; }
        public int Level { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string SeoTitle { get; set; }
        public string Url { get; set; }
        public string Specification { get; set; }
    }
}
