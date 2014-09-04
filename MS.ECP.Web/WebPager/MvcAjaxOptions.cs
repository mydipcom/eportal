using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;

namespace MS.ECP.Web.WebPager
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