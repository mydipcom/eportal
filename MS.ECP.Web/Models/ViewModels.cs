using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MS.ECP.Model.CMS;
using MS.ECP.Web.Filters;
using MS.ECP.Web.WebPager;


namespace MS.ECP.Web.Models
{
    public class NewsViewModel
    {
        public NewsViewModel()
        {
            CurrentNews = new News();
            NewsTitles = new PagedList<News>(new News[0], 0, 0);
        }

        public News CurrentNews { get; set; }
        public PagedList<News> NewsTitles { get; set; }
    }


    public class JobViewModel
    {
        public JobViewModel()
        {
            CurrentJob = new Job();
            JobTitles = new PagedList<Job>(new Job[0], 0, 0);
        }

        public Job CurrentJob { get; set; }
        public PagedList<Job> JobTitles { get; set; }
    }


    public class IndexViewModel
    {
        public string SolutionsLanGuid { get; set; }
    }


    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            TitlViewModel = new List<TitleListViewModel>();
            CurrentPageContent = new PageContent();
        }

        public string CaridLanguid { get; set; }
        public PageContent CurrentPageContent { get; set; }
        public IList<TitleListViewModel> TitlViewModel { get; set; }
    }

    public class TitleListViewModel
    {
        public TitleListViewModel()
        {
            TitleList = new List<PageContent>();
        }

        public Category TitleCategory { get; set; }
        public IList<ECP.Model.CMS.PageContent> TitleList { get; set; }
    }

    public class Feedback
    {
        public Feedback()
        {
            IsValidBack = false;
        }

        [Required(ErrorMessage = "不能为空")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "不能为空")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "不能为空")]
        public string Body { get; set; }

        public bool IsValidBack { get; set; }
    }


    public class FooterPartialViewModel
    {
        public FooterPartialViewModel()
        {
            Categories = new List<Category>();
            Newses = new List<News>();
        }

        public IList<Category> Categories { get; set; }
        public IList<News> Newses { get; set; }
    }


    public class MenuPartialViewModel
    {
        public MenuPartialViewModel()
        {
            Categories = new List<Category>();
            _title5Css = "menu_last";
        }

        public IList<Category> Categories { get; set; }
        public string Title1Css { get; set; }
        public string Title2Css { get; set; } 
        public string Title3Css { get; set; }
        public string Title4Css { get; set; }

        private string _title5Css;  
        public string Title5Css {
            get
            {
                return _title5Css;
            }
            set
            {
                _title5Css = "menu_last " + value;
            }
        }
    }

}