using System.Collections;

namespace MS.ECP.AAMAPrd.WebPager
{
    public interface IPagedList : IEnumerable
    {
        // Properties
        int CurrentPageIndex { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
    }
}