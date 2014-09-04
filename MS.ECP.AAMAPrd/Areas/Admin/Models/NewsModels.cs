using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    public class NewsViewModel
    {
        [Required]
        public int EnId { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "Title")]
        public string EnTitle { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "Content")]
        public string EnContent { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "Specification")]
        public string EnSpecification { get; set; }

        public int ZhId { get; set; }

        [Display(Name = "标题")]
        public string ZhTitle { get; set; }

        [Display(Name = "内容")]
        public string ZhContent { get; set; }


        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "参加活动说明")]
        public string ZhSpecification { get; set; } 


        [Display(Name = "keywords")]
        public string TxtKeywords { get; set; }

        [Display(Name = "description")]
        public string TxtDesc { get; set; }

        [Display(Name = "click")]
        public string TxtHits { get; set; }

    }


    public class NewsInputViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "字段名")]
        public string Inputtitle { get; set; }

        [Display(Name = "是否允许为空")]
        public bool IsAllowNull { get; set; }


        [Display(Name = "字段值")]
        public string InputValue { get; set; }


        [Required]
        public int InputType { get; set; }

        [Required]
        public string LangGuid { get; set; }
    }



}