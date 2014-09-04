using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MS.ECP.Web.Areas.Admin.Models
{
    public class NewsViewModel
    {
                #region .ctr
        public NewsViewModel()
        {
            _enContentDivId = Guid.NewGuid().ToString();
            _zhContentDivId = Guid.NewGuid().ToString();
        }
        #endregion

        #region En
        public int EnId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string EnTitle { get; set; }

        [Required]
        [Display(Name = "Content")]
        [AllowHtml]
        public string EnContent { get; set; }

        private readonly string _enContentDivId;
        public string EnContentDivId
        {
            get
            {
                return _enContentDivId;
            }
        }


        [Display(Name = "keywords")]
        public string EnTxtKeywords { get; set; }

        [Display(Name = "Description")]
        public string EnTxtDesc { get; set; }

        [Display(Name = "Page Title")]
        public string EnTxtHits { get; set; }

        #endregion




        #region Cn


        public int ZhId { get; set; }

        [Display(Name = "新闻标题")]
        public string ZhTitle { get; set; }

        [Display(Name = "新闻内容")]
        [AllowHtml]
        public string ZhContent { get; set; }

        private readonly string _zhContentDivId;
        public string ZhContentDivId
        {
            get
            {
                return _zhContentDivId;
            }
        }


        [Display(Name = "SEO关键字")]
        public string TxtKeywords { get; set; }

        [Display(Name = "SEO内容")]
        public string TxtDesc { get; set; }

        [Display(Name = "SEO标题")]
        public string TxtHits { get; set; }

        #endregion

    }
}