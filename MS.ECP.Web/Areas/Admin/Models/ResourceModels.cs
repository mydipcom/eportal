using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MS.ECP.Web.Areas.Admin.Models
{
    public class ResourceViewModel
    {
        [Required]
        public int EnId { get; set; }

         [Display(Name = "Resource Key")]
        [Required]
        public string EnResourceKey { get; set; }

        [Display(Name = "Resource Content")]
        [Required]
        [AllowHtml]
        public string EnResourceValue { get; set; }

        [Display(Name = "Resource Page")]
        [Required]
        public string EnResourcePage { get; set; }

        [Required]
        public int ZhId { get; set; }

        [Display(Name = "资源键")]
        [Required]
        public string ResourceKey { get; set; }

        [Display(Name = "资源值")]
        [Required]
        [AllowHtml]
        public string ResourceValue { get; set; }


        [Display(Name = "资源页面")]
        [Required]
        public string ResourcePage { get; set; }

    }
}