using System;
using System.Collections.Generic;
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
            MultiNews = new List<MultiNews>();
            News = new List<News>();
        }

        public IList<MultiNews> MultiNews { get; set; }
        public IList<News> News { get; set; }
    }


    public class EventViewModel
    {
        public EventViewModel()
        {
            CurrentEvent = new Event();
            EventTitles = new PagedList<Event>(new Event[0], 0, 0);
        }

        public Event CurrentEvent { get; set; }
        public PagedList<Event> EventTitles { get; set; }
    }


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



    public class MultiNewsViewModel
    {
        public MultiNewsViewModel()
        { 
            CurrentNews = new MultiNews();
            NewsTitles = new PagedList<MultiNews>(new MultiNews[0], 0, 0);
        }

        public MultiNews CurrentNews { get; set; }
        public PagedList<MultiNews> NewsTitles { get; set; }
    } 
}