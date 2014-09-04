using System.Web.Mvc.Ajax;

namespace MS.ECP.AAMAPrd.WebPager
{
    public class MvcAjaxOptions : AjaxOptions
    {
        // Methods
        public MvcAjaxOptions()
        {
        }

        // Properties
        public string DataFormId { get; set; }
        public bool EnablePartialLoading { get; set; }
    }

}