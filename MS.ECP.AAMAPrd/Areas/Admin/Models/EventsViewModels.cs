namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class EventsViewModel
    {
        [Display(Name = "Content"), Required(ErrorMessage = "{0}不能为空")]
        public string EnContent { get; set; }

        [Display(Name = "Create Time")]
        public string EnCreateTime { get; set; }

        [Required]
        public int EnId { get; set; }

        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "Title")]
        public string EnTitle { get; set; }

        [Display(Name = "description")]
        public string TxtDesc { get; set; }

        [Display(Name = "click")]
        public string TxtHits { get; set; }

        [Display(Name = "keywords")]
        public string TxtKeywords { get; set; }

        [Display(Name = "内容")]
        public string ZhContent { get; set; }

        [Display(Name = "创建时间")]
        public string ZhCreateTime { get; set; }

        public int ZhId { get; set; }

        [Display(Name = "标题")]
        public string ZhTitle { get; set; }
    }
}
