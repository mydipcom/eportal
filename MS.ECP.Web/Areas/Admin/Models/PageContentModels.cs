using System.Net;
using MS.ECP.Model.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Web.Models;

namespace MS.ECP.Web.Areas.Admin.Models
{

    public class PageContents
    {
        public int Id { get; set; }
        public string LanageId { get; set; }
        public string Title { get; set; }
        public string CreateDate { get; set; }
        public string Category { get; set; }
        public string LanCode { get; set; }
    }


    public class PageContentViewModel
    {
        #region .ctr
        public PageContentViewModel()
        {
            _enContentDivId = Guid.NewGuid().ToString();
            _zhContentDivId = Guid.NewGuid().ToString();
            SetEnParentGuidItems(new List<Category>());
            SetEnTopParEnToptGuidItems(new List<Category>());
            SetZhParentGuidItems(new List<Category>());
            SetCnTopParentGuidItems(new List<Category>());
        }
        #endregion

        #region En

        [Display(Name = "ID")]
        public int EnID { get; set; }


        [Display(Name = "Title")]
        [Required]
        public string EnItem { get; set; }


        [Display(Name = "Content Info")]
        [Required]
        [AllowHtml]
        public string EnItemContent { get; set; }

        private readonly string _enContentDivId;   
        public string EnContentDivId {
            get
            {
                return _enContentDivId;
            }
        }


        public string EnTopCategoryID { get; set; }

        public SelectList EnTopCategoryIDItems { get; set; }

        public void SetEnTopParEnToptGuidItems(IList<Category> categories)
        {
            EnTopCategoryIDItems = GetSelectList(categories);
        }


        [Required]
        [Display(Name = "Category")]
        public string EnCategoryID { get; set; }

        public SelectList EnCategoryIDItems { get; set; }

        public void SetEnParentGuidItems(IList<Category> categories)
        {
            EnCategoryIDItems = GetSelectList(categories);
        }



        [Display(Name = "keywords")]
        public string EnTxtKeywords { get; set; }

        [Display(Name = "Description")]
        public string EnTxtDesc { get; set; }

        [Display(Name = "Page Title")]
        public string EnTxtHits { get; set; }

        #endregion


        #region Cn


        [Display(Name = "ID")]
        public int ZhID { get; set; }


        [Display(Name = "标题")]
        public string ZhItem { get; set; }


        [Display(Name = "内容信息")]
        [AllowHtml]
        public string ZhItemContent { get; set; }

        private readonly string _zhContentDivId; 
        public string ZhContentDivId {
            get
            {
                return _zhContentDivId;
            }
        }

        public string CnTopCategoryID { get; set; }

        public SelectList CnTopCategoryIDItems { get; set; }

        public void SetCnTopParentGuidItems(IList<Category> categories)
        {
            CnTopCategoryIDItems = GetSelectList(categories);
        }



        [Required]
        [Display(Name = "类别")]
        public string ZhCategoryID { get; set; }

        public SelectList ZhCategoryIDItems { get; set; }

        public void SetZhParentGuidItems(IList<Category> categories)
        {
            ZhCategoryIDItems = GetSelectList(categories);
        }



        [Display(Name = "SEO关键字")]
        public string TxtKeywords { get; set; }

        [Display(Name = "SEO内容")]
        public string TxtDesc { get; set; }

        [Display(Name = "SEO标题")]
        public string TxtHits { get; set; }


        #endregion

        private SelectList GetSelectList(IEnumerable<Category> categories)
        {
            IList<DropListItem> dropListItems = categories.Select(caitem => new DropListItem()
            {
                Text = caitem.CategoryName,
                Value = caitem.ID
            }).ToList();
            return new SelectList(dropListItems, "Value", "Text");
        }
    }
}