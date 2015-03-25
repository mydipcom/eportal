using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MS.ECP.AAMAPrd.WebPager;
using MS.ECP.Model;
using MS.ECP.Model.CMS;

namespace MS.ECP.AAMAPrd.Models
{

    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.MultiNews = new List<MS.ECP.Model.MultiNews>();
            this.News = new List<MS.ECP.Model.CMS.News>();
        }

        public IList<MS.ECP.Model.MultiNews> MultiNews { get; set; }

        public IList<MS.ECP.Model.CMS.News> News { get; set; }
    }


    public class EventViewModel
    {
        public EventViewModel()
        {
            this.CurrentEvent = new CmsEvent();
            this.EventTitles = new PagedList<CmsEvent>(new CmsEvent[0], 0, 0);
        }

        public CmsEvent CurrentEvent { get; set; }

        public PagedList<CmsEvent> EventTitles { get; set; }
    }


    public class NewsViewModel
    {
        public NewsViewModel()
        {
            this.CurrentNews = new News();
            this.NewsTitles = new PagedList<News>(new News[0], 0, 0);
        }

        public News CurrentNews { get; set; }

        public PagedList<News> NewsTitles { get; set; }
    }



    public class MultiNewsViewModel
    {
        public MultiNewsViewModel()
        {
            this.CurrentNews = new MultiNews();
            this.NewsTitles = new PagedList<MultiNews>(new MultiNews[0], 0, 0);
        }

        public MultiNews CurrentNews { get; set; }

        public PagedList<MultiNews> NewsTitles { get; set; }
    }


 
}