using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    public class ResourceViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Language Code:")]
        public string LanguageCode { get; set; }

        [Display(Name = "Resource Key")]
        public string ResourceKey { get; set; }


        [Display(Name = "Resource Value")]
        [Required]
        public string ResourceValue { get; set; }


        [Display(Name = "keywords")]
        [Required]
        public string TxtKeywords { get; set; }

        [Display(Name = "description")]
        public string TxtDesc { get; set; }

        [Display(Name = "click")]
        public string TxtHits { get; set; }
    }



}