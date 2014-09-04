using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Model.CMS;
using MS.ECP.Web.Models;

namespace MS.ECP.Web.Areas.Admin.Models
{

    #region new viewmodel

    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            EnParentCategory = new Category();
            ZhParentCategory = new Category();
            EnChildCategories = new List<Category>();
            ZhChildCategories = new List<Category>();
        }

        public int Id { get; set; }
        public string LanGuid { get; set; }
        public Category EnParentCategory { get; set; }
        public IList<Category> EnChildCategories { get; set; }

        public Category ZhParentCategory { get; set; }
        public IList<Category> ZhChildCategories { get; set; }
    }


    public class CategoryaeModel
    {
        public CategoryaeModel()
        {
            CategoryItems = new SelectList(new List<OptoinItem>(0), "Value", "Text");
        }

        [Display(Name = "Category Name")]
        public string CategoryLanGuid { get; set; }

        public SelectList CategoryItems { get; set; }

        public void SetCategoryItems(IList<OptoinItem> categories)
        {
            CategoryItems = new SelectList(categories, "Value", "Text");
        }

        [Required]
        [Display(Name = "SubCategory Name(EN)")]
        public string EnCategoryName { get; set; }


        [Required]
        [Display(Name = "SubCategory Name(CN)")]
        public string CnCategoryName { get; set; }
    }


    public class CategorEditItem
    {
        public int EnId { get; set; } 
        public string EnText { get; set; }
        public int CnId { get; set; }  
        public string CnText { get; set; }
    }


    public class CategorEditModel
    {
        public CategorEditModel()
        {
            CategoryItems = new List<CategorEditItem>();
        }

        public int EnId { get; set; }

        public int CnId { get; set; }   

        [Required]
        [Display(Name = "Category Name(EN)")]
        public string EnCategoryname { get; set; }

        [Display(Name = "Category Name(CN)")]
        public string CnCategoryname { get; set; }

        [Display(Name = "Sub Category(EN)")]
        public IList<CategorEditItem> CategoryItems { get; set; }
    }


    public class InputVal
    {
        public string InputId { get; set; }
        public string LanCode { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }
    }


    #endregion



}