﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    public class AboutUsModel
    {
        public int EnId { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "Title")]
        public string EnTitle { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "Content")]
        public string EnContent { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "Display Sort")]
        public int EnSortOrder { get; set; }

        public int ZhId { get; set; }

        [Display(Name = "标题")]
        public string ZhTitle { get; set; }
        
        [Display(Name = "内容")]
        public string ZhContent { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "显示顺序")]
        public int ZhSortOrder { get; set; }  


        [Display(Name = "keywords")]
        public string TxtKeywords { get; set; }

        [Display(Name = "description")]
        public string TxtDesc { get; set; }

        [Display(Name = "click")]
        public string TxtHits { get; set; }
    }
}