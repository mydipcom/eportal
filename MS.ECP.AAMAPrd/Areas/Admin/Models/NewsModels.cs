using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    public class NewsViewModel
    {
        [Display(Name = "Content"), Required(ErrorMessage = "{0}不能为空")]
        public string EnContent { get; set; }

        [Display(Name = "Create Time")]
        public string EnCreateTime { get; set; }

        [Required]
        public int EnId { get; set; }

        [Display(Name = "Specification"), Required(ErrorMessage = "{0}不能为空")]
        public string EnSpecification { get; set; }

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

        [Required(ErrorMessage = "{0}不能为空"), Display(Name = "参加活动说明")]
        public string ZhSpecification { get; set; }

        [Display(Name = "标题")]
        public string ZhTitle { get; set; }
    }



    public class NewsInputViewModel
    {
        public int Id { get; set; }

        [Display(Name = "字段名"), Required(ErrorMessage = "{0}不能为空")]
        public string Inputtitle { get; set; }

        [Required]
        public int InputType { get; set; }

        [Display(Name = "字段值")]
        public string InputValue { get; set; }

        [Display(Name = "是否允许为空")]
        public bool IsAllowNull { get; set; }

        [Required]
        public string LangGuid { get; set; }
    }

}