using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS.ECP.Web.WebPager
{
    public static class PageLinqExtensions
    {
        // Methods
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> allItems, int pageIndex, int pageSize)
        {
            return allItems.AsQueryable<T>().ToPagedList<T>(pageIndex, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            int count = (pageIndex - 1)*pageSize;
            int totalItemCount = allItems.Count<T>();
            while ((totalItemCount <= count) && (pageIndex > 1))
            {
                count = (--pageIndex - 1)*pageSize;
            }
            return new PagedList<T>(allItems.Skip<T>(count).Take<T>(pageSize), pageIndex, pageSize, totalItemCount);
        }


    }
}