namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class ResourceViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Language Code:")]
        public string LanguageCode { get; set; }

        [Display(Name = "Resource Key")]
        public string ResourceKey { get; set; }

        [Display(Name = "Resource Value"), Required]
        public string ResourceValue { get; set; }

        [Display(Name = "description")]
        public string TxtDesc { get; set; }

        [Display(Name = "click")]
        public string TxtHits { get; set; }

        [Required, Display(Name = "keywords")]
        public string TxtKeywords { get; set; }
    }
}
