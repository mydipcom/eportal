using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MS.ECP.Web.Areas.Admin.Models
{
    public class JobViewModel
    {
        #region .ctr
        public JobViewModel()
        {
            _enContentDivId = Guid.NewGuid().ToString();
            _zhContentDivId = Guid.NewGuid().ToString();
        }
        #endregion


        #region En
        public int EnId { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string EnJobTitle { get; set; }

        [Required]
        [Display(Name = "Recruiting Numbers")]
        public int EnNeedNum { get; set; }

        [Required]
        [Display(Name = "Workplace")]
        public string EnWorkplace { get; set; }

        [Required]
        [Display(Name = "Salary")]
        public string EnSalary { get; set; }

        [Required]
        [Display(Name = "Language Requirment")]
        public string EnLanguageRequired { get; set; }

        [Required]
        [Display(Name = "Order Number")]
        public int EnTOrderNum { get; set; }

        [Required]
        [Display(Name = "Functional requirements")]
        [AllowHtml]
        public string EnJobDesc { get; set; }

        [Required]
        [Display(Name = "Responsibilities")]
        public string EnJobBligation { get; set; }


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

        [Display(Name = "职位名称")]
        public string ZhJobTitle { get; set; }

        [Display(Name = "招聘人数")]
        public int ZhNeedNum { get; set; }

        [Display(Name = "工作地点")]
        public string ZhWorkplace { get; set; }

        [Display(Name = "薪资待遇")]
        public string ZhSalary { get; set; }

        [Display(Name = "语言要求")]
        public string ZhLanguageRequired { get; set; }

        [Display(Name = "排序")]
        public int ZhTOrderNum { get; set; }

        [Display(Name = "岗位职责")]
        [AllowHtml]
        public string ZhJobDesc { get; set; }

        [Display(Name = "职能要求")]
        public string ZhJobBligation { get; set; }

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