namespace MS.ECP.AAMAPrd.Areas.Admin.Controllers
{
    using MS.ECP.Bll.EntityContext;
    using System;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected readonly AAMAPrdContext Contentx = new AAMAPrdContext();
        protected const int LanguageSelect = 2;
        protected const int Pagesize = 10;

        protected DateTime DateTimeFormat(string dateTime)
        {
            DateTime time;
            DateTime.TryParse(dateTime, out time);
            return time;
        }

        protected string DateToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        protected void SaveChange()
        {
            this.Contentx.SaveChanges();
        }
    }
}
