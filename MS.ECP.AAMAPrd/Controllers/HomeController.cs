
    using MS.ECP.AAMAPrd.Models;
    using MS.ECP.AAMAPrd.WebPager;
    using MS.ECP.BLL;
    using MS.ECP.BLL.CMS;
    using MS.ECP.Bll.EntityContext;
    using MS.ECP.Common;
    using MS.ECP.Model;
    using MS.ECP.Model.CMS;
    using MS.ECP.Utility;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;

namespace MS.ECP.AAMAPrd.Controllers
{
    public class HomeController : Controller
    {
        private readonly AboutusBll _aboutusBll = new AboutusBll();
        private readonly AAMAPrdContext _context = new AAMAPrdContext();
        private readonly Event _eEvent = new Event();
        private readonly MS.ECP.BLL.CMS.News _news = new MS.ECP.BLL.CMS.News();
        private readonly MS.ECP.BLL.UserInfo _userinfoBLL = new MS.ECP.BLL.UserInfo();
        private const int Pagesize = 15;
        private string strguid = Guid.NewGuid().ToString();

        public ActionResult About()
        {
            return base.View(this._aboutusBll.GetList(this.SqlLanWhere) ?? new List<Aboutus>(0));
        }

        [HttpPost]
        public ActionResult BaoMing()
        {
            string str = base.Request["LangGuid"];
            if (string.IsNullOrEmpty(str))
            {
                return base.Json(new {result = "0", errMsg = "邮件保存失败"});
            }
            MS.ECP.Model.CMS.News modelByLangGuidAndLangCode = this._news.GetModelByLangGuidAndLangCode(str,
                ResourcesHelper.GetLang());
            IDictionary<string, string> listKeys = new Dictionary<string, string>();
            foreach (NewsInput input in modelByLangGuidAndLangCode.Inputs)
            {
                string str2 = base.Request[input.InputName];
                if (!input.IsAllowNull && string.IsNullOrEmpty(str2))
                {
                    return base.Json(new {result = "0", errMsg = input.Inputtitle + "不能为空"});
                }
                listKeys.Add(input.Inputtitle, str2);
            }
            MailModel model = new MailModel
            {
                ToAddress = ConfigurationManager.AppSettings["EmailTo"],
                UserCode = Guid.NewGuid().ToString(),
                MailName = "baoming2"
            };
            FrontUtility.SendMail(model, listKeys, "来自网上的报名");
            return base.Json(new {result = "1", errMsg = "报名成功"});
        }

        public ActionResult Contact()
        {
            return base.View();
        }

        public ActionResult EventDetail(string langGuid)
        {
            CmsEvent modelByLangGuidAndLangCode = this._eEvent.GetModelByLangGuidAndLangCode(langGuid,
                ResourcesHelper.GetLang());
            return base.View(modelByLangGuidAndLangCode ?? new CmsEvent());
        }

        public ActionResult Events(string langGuid, int id = 1)
        {
            IList<CmsEvent> currentPageItems = this._eEvent.GetListByPage(this.SqlLanWhere,
                (id == 1) ? id : (((id - 1)*15) + 1), id*15);
            int recordCount = this._eEvent.GetRecordCount(this.SqlLanWhere);
            EventViewModel model = new EventViewModel
            {
                EventTitles = new PagedList<CmsEvent>(currentPageItems, id, 15, recordCount)
            };
            if (base.Request.IsAjaxRequest())
            {
                return this.PartialView("_EventsPagerPartialPage", model);
            }
            return base.View(model);
        }

        public ActionResult Index()
        {
            ((dynamic) base.ViewBag).Message = "修改此模板以快速启动你的 ASP.NET MVC 应用程序。";
            IndexViewModel model = new IndexViewModel
            {
                MultiNews = (from m in this._context.AAMANews
                    where m.LanguageCode == this.LanCode
                    orderby m.CreateDate descending
                    select m).Take<MS.ECP.Model.MultiNews>(3).ToList<MS.ECP.Model.MultiNews>(),
                News = this._news.GetList(3, this.SqlLanWhere)
            };
            return base.View(model);
        }

        public PartialViewResult JoinPary()
        {
            return this.PartialView("JoinPary", new JoinPart());
        }

        [HttpPost]
        public ActionResult JoinPary(JoinPart joinPart, string returnUrl)
        {
            if (base.ModelState.IsValid)
            {
                if (this.RuHui(joinPart))
                {
                    return base.RedirectToAction("About");
                }
                base.ModelState.AddModelError("", "入会失败");
            }
            return base.View("JoinPary", joinPart);
        }

        public ActionResult MemberProgram()
        {
            return base.View(this._aboutusBll.GetList(this.SqlLanWhere) ?? new List<Aboutus>(0));
        }

        public ActionResult MultiNews(string langGuid, int id = 1)
        {
            DbSet<MS.ECP.Model.MultiNews> aAMANews = this._context.AAMANews;
            string lancode = ResourcesHelper.GetLang();
            IOrderedQueryable<MS.ECP.Model.MultiNews> source = from m in aAMANews
                where m.LanguageCode == lancode
                orderby m.ModifyDate descending
                select m;
            List<MS.ECP.Model.MultiNews> list =
                source.Skip<MS.ECP.Model.MultiNews>(((id - 1)*15))
                    .Take<MS.ECP.Model.MultiNews>(15)
                    .ToList<MS.ECP.Model.MultiNews>();
            int totalItemCount = source.Count<MS.ECP.Model.MultiNews>();
            if ((1 == list.Count) && (totalItemCount == 1))
            {
                MS.ECP.Model.MultiNews news = list.FirstOrDefault<MS.ECP.Model.MultiNews>();
                if (news != null)
                {
                    return base.RedirectToAction("MultiNewsDetail", new {langGuid = news.LangGuid});
                }
            }
            MultiNewsViewModel model = new MultiNewsViewModel
            {
                CurrentNews =
                    (string.IsNullOrEmpty(langGuid) && (id == 1))
                        ? list.FirstOrDefault<MS.ECP.Model.MultiNews>()
                        : list.FirstOrDefault<MS.ECP.Model.MultiNews>(d => (d.LangGuid == langGuid)),
                NewsTitles = new PagedList<MS.ECP.Model.MultiNews>(list, id, 15, totalItemCount)
            };
            model.CurrentNews = model.CurrentNews ?? new MS.ECP.Model.MultiNews();
            if (base.Request.IsAjaxRequest())
            {
                return this.PartialView("MultiNewsPartialPage", model);
            }
            return base.View(model);
        }

        public ActionResult MultiNewsDetail(string langGuid)
        {
            MS.ECP.Model.MultiNews news =
                this._context.AAMANews.FirstOrDefault<MS.ECP.Model.MultiNews>(
                    m => (m.LanguageCode == this.LanCode) && (m.LangGuid == langGuid));
            return base.View(news ?? new MS.ECP.Model.MultiNews());
        }

        public ActionResult News(string langGuid, int id = 1)
        {
            IList<MS.ECP.Model.CMS.News> source = this._news.GetListByPage(this.SqlLanWhere,
                (id == 1) ? id : (((id - 1)*15) + 1), id*15);
            int recordCount = this._news.GetRecordCount(this.SqlLanWhere);
            if ((1 == source.Count) && (recordCount == 1))
            {
                return base.RedirectToAction("NewsDetail",
                    new {langGuid = source.FirstOrDefault<MS.ECP.Model.CMS.News>().LangGuid});
            }
            NewsViewModel model = new NewsViewModel
            {
                CurrentNews =
                    (string.IsNullOrEmpty(langGuid) && (id == 1))
                        ? source.FirstOrDefault<MS.ECP.Model.CMS.News>()
                        : source.FirstOrDefault<MS.ECP.Model.CMS.News>(d => (d.LangGuid == langGuid)),
                NewsTitles = new PagedList<MS.ECP.Model.CMS.News>(source, id, 15, recordCount)
            };
            model.CurrentNews = model.CurrentNews ?? new MS.ECP.Model.CMS.News();
            if (base.Request.IsAjaxRequest())
            {
                return this.PartialView("_NewsPagerPartialPage", model);
            }
            return base.View(model);
        }

        public ActionResult NewsDetail(string langGuid)
        {
            MS.ECP.Model.CMS.News modelByLangGuidAndLangCode = this._news.GetModelByLangGuidAndLangCode(langGuid,
                ResourcesHelper.GetLang());
            return base.View(modelByLangGuidAndLangCode ?? new MS.ECP.Model.CMS.News());
        }

        public ActionResult Register(string email)
        {
            ResourcesHelper helper = new ResourcesHelper("Default");
            ResourcesHelper helper2 = new ResourcesHelper("Register");
            if (!string.IsNullOrWhiteSpace(email) && (email != helper.GetString("tip_Email")))
            {
                ((dynamic) base.ViewBag).strEmail = email;
                ((dynamic) base.ViewBag).strReEmail = email;
            }
            else
            {
                ((dynamic) base.ViewBag).strEmail = helper2.GetString("tip_EmailAddress");
                ((dynamic) base.ViewBag).strReEmail = helper2.GetString("tip_ReEmailAddress");
            }
            return base.View();
        }

        [HttpPost]
        public ActionResult Register2()
        {
            new PageValidate();
            new ResourcesHelper("Register");
            string str = base.Request.Form["Password"].ToString();
            string str2 = base.Request.Form["RePassword"].ToString();
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(str2))
            {
                if (!str.Equals(str2))
                {
                    return base.Json(new {result = "0", errMsg = "密码不一致"});
                }
            }
            else
            {
                return base.Json(new {result = "0", errMsg = "请输入密码"});
            }
            string str3 = base.Request.Form["UserName"].ToString().Trim();
            string str4 = base.Request.Form["Email"].ToString().Trim();
            if (!string.IsNullOrEmpty(str3))
            {
                if (this._userinfoBLL.ExistUserName(str3))
                {
                    return base.Json(new {result = "0", errMsg = "UserName 不唯一"});
                }
            }
            else
            {
                return base.Json(new {result = "0", errMsg = "UserName 不能为空"});
            }
            if (string.IsNullOrEmpty(str4))
            {
                return base.Json(new {result = "0", errMsg = "email 不能为空"});
            }
            if (!PageValidate.IsEmail2(str4))
            {
                return base.Json(new {result = "0", errMsg = "Email格式不正确"});
            }
            if (this._userinfoBLL.ExistEmail(str4))
            {
                return base.Json(new {result = "0", errMsg = "Email 不唯一"});
            }
            try
            {
                MS.ECP.Model.UserInfo info = new MS.ECP.Model.UserInfo();
                string str5 = Guid.NewGuid().ToString();
                info.Guid = str5;
                info.UserName = base.Request.Form["UserName"].Trim();
                info.CreateTime = new DateTime?(DateTime.Now);
                info.UpdateTime = new DateTime?(DateTime.Now);
                info.Email = base.Request.Form["Email"];
                string text = base.Request.Form["Password"].Trim();
                info.Password = DESEncrypt.Encrypt(text);
                info.UserType = 1;
                if (this._userinfoBLL.Add(info))
                {
                    MailModel model = new MailModel
                    {
                        ToAddress = info.Email,
                        UserCode = str5,
                        MailName = "activemail",
                        IsActionCode = true
                    };
                    List<ListItem> listKeys = new List<ListItem>();
                    ListItem item = new ListItem
                    {
                        Value = "{$data_Code$}"
                    };
                    listKeys.Add(item);
                    FrontUtility.SendMail(model, listKeys, "激活邮件");
                }
                else
                {
                    return base.Json(new {result = "0", errMsg = "用户注册失败"});
                }
                return base.Json(new {result = "1", errMsg = "用户注册成功", find = base.Url.Action("index", "home")});
            }
            catch (Exception)
            {
                return base.Json(new {result = "0", errMsg = "用户注册失败"});
            }
        }

        public bool RuHui(JoinPart joinPart)
        {
            try
            {
                MS.ECP.Model.UserInfo info = new MS.ECP.Model.UserInfo();
                string str = Guid.NewGuid().ToString();
                info.Guid = str;
                info.UserName = joinPart.UserName;
                info.Email = joinPart.Email;
                MailModel model = new MailModel
                {
                    ToAddress = ConfigurationManager.AppSettings["EmailTo"],
                    UserCode = str,
                    MailName = "ruhui",
                    IsActionCode = true
                };
                List<ListItem> list2 = new List<ListItem>();
                ListItem item = new ListItem
                {
                    Value = "{$data_RHName$}",
                    Text = joinPart.UserName
                };
                list2.Add(item);
                ListItem item2 = new ListItem
                {
                    Value = "{$data_RHSex$}",
                    Text = joinPart.Sex
                };
                list2.Add(item2);
                ListItem item3 = new ListItem
                {
                    Value = "{$data_RHDW$}",
                    Text = joinPart.WorkPlace
                };
                list2.Add(item3);
                ListItem item4 = new ListItem
                {
                    Value = "{$data_RHZW$}",
                    Text = joinPart.Position
                };
                list2.Add(item4);
                ListItem item5 = new ListItem
                {
                    Value = "{$data_RHDZ$}",
                    Text = joinPart.Adress
                };
                list2.Add(item5);
                ListItem item6 = new ListItem
                {
                    Value = "{$data_RHTel$}",
                    Text = joinPart.Phone
                };
                list2.Add(item6);
                ListItem item7 = new ListItem
                {
                    Value = "{$data_RHPhone$}",
                    Text = joinPart.MobliePhone
                };
                list2.Add(item7);
                ListItem item8 = new ListItem
                {
                    Value = "{$data_RHSHZW$}",
                    Text = joinPart.OthersPosition
                };
                list2.Add(item8);
                ListItem item9 = new ListItem
                {
                    Value = "{$data_RHEmail$}",
                    Text = joinPart.Email
                };
                list2.Add(item9);
                ListItem item10 = new ListItem
                {
                    Value = "{$data_RHComment$}",
                    Text = joinPart.ReMark
                };
                list2.Add(item10);
                List<ListItem> listKeys = list2;
                FrontUtility.SendMail(model, listKeys, "来自网上的入会申请");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string LanCode
        {
            get { return ResourcesHelper.GetLang(); }
        }

        private string SqlLanWhere
        {
            get { return string.Format(" LanguageCode='{0}'", ResourcesHelper.GetLang()); }
        }
    }
}