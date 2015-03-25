namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class AboutUsModel
    {
        [Display(Name = "Content"), Required(ErrorMessage = "{0}不能为空")]
        public string EnContent { get; set; }

        public int EnId { get; set; }

        [Display(Name = "Display Sort"), Required(ErrorMessage = "{0}不能为空")]
        public int EnSortOrder { get; set; }

        [Display(Name = "Title"), Required(ErrorMessage = "{0}不能为空")]
        public string EnTitle { get; set; }

        [Display(Name = "description")]
        public string TxtDesc { get; set; }

        [Display(Name = "click")]
        public string TxtHits { get; set; }

        [Display(Name = "keywords")]
        public string TxtKeywords { get; set; }

        [Display(Name = "内容")]
        public string ZhContent { get; set; }

        public int ZhId { get; set; }

        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "显示顺序")]
        public int ZhSortOrder { get; set; }

        [Display(Name = "标题")]
        public string ZhTitle { get; set; }
    }
}
