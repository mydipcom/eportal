using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS.ECP.Web.WebPager
{
    public interface IPagedList : IEnumerable
    {
        // Properties
        int CurrentPageIndex { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
    }
}