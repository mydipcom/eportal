using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MS.ECP.Web.WebPager;


namespace MS.ECP.Web.WebHelp
{
    public static class WebPagingHelp
    { 
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> currentItems, int pageIndex, int pagesize,
            int pagecount) 
        {
            return new PagedList<T>(currentItems, pageIndex, pagesize, pagecount);
        }
    }
}