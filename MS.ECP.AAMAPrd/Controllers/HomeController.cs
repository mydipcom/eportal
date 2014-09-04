using System.IO;
using MS.ECP.AAMAPrd.Models;
using MS.ECP.AAMAPrd.WebPager;
using MS.ECP.BLL.CMS;
using MS.ECP.Bll.EntityContext;
using MS.ECP.Common;
using MS.ECP.Model;
using MS.ECP.Model.CMS;
using MS.ECP.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Event = MS.ECP.BLL.Event;
using News = MS.ECP.BLL.CMS.News;

namespace MS.ECP.AAMAPrd.Controllers
{
    public class HomeController : Controller
    {
        private readonly BLL.UserInfo _userinfoBLL = new BLL.UserInfo();
        private readonly News _news = new News();
        readonly Event _eEvent=new Event();
        readonly AboutusBll _aboutusBll=new AboutusBll();
        const int Pagesize = 15;
        readonly AAMAPrdContext _context=new AAMAPrdContext(); 

        private String SqlLanWhere
        {
            get
            {
                return String.Format(" LanguageCode='{0}'", ResourcesHelper.GetLang());
            }
        }

        private String LanCode
        {
            get
            {
                return ResourcesHelper.GetLang();
            }
        }


        public ActionResult MultiNews(string langGuid, int id = 1)
        {
            var mulitenews = _context.MultiNewss;
            var lancode = ResourcesHelper.GetLang();
            var query =
                mulitenews.Where(m => m.LanguageCode == lancode).OrderByDescending(m=>m.ModifyDate);

            var dtNews = query.Skip(id -1)
                .Take(Pagesize).ToList();

            var listcount = query.Count();

            if (1 == dtNews.Count && listcount == 1)
            {
                var firstOrDefault = dtNews.FirstOrDefault();
                if (firstOrDefault != null)
                    return RedirectToAction("MultiNewsDetail", new { langGuid = firstOrDefault.LangGuid });
            }

            var viemodel = new MultiNewsViewModel
            {
                CurrentNews =
                    String.IsNullOrEmpty(langGuid) && id == 1
                        ? dtNews.FirstOrDefault()
                        : dtNews.FirstOrDefault(
                            d => d.LangGuid == langGuid),
                NewsTitles = new PagedList<MultiNews>(dtNews, id, Pagesize, listcount)
            };

            viemodel.CurrentNews = viemodel.CurrentNews ?? new MultiNews();
            if (Request.IsAjaxRequest())
                return PartialView("MultiNewsPartialPage", viemodel);
            return View(viemodel);
        }


        public ActionResult MultiNewsDetail(string langGuid)
        {
            var newsmodel = _context.MultiNewss.FirstOrDefault(m => m.LanguageCode == LanCode && m.LangGuid == langGuid);
            return View(newsmodel ?? new Model.MultiNews());
        }


        public ActionResult Index()
        {
            ViewBag.Message = "修改此模板以快速启动你的 ASP.NET MVC 应用程序。";
            const int toptitle = 3;
            var indexViewModel = new IndexViewModel()
            {
                MultiNews =
                    _context.MultiNewss.Where(m => m.LanguageCode == LanCode)
                        .OrderByDescending(m => m.CreateDate)
                        .Take(toptitle)
                        .ToList(),
                News = _news.GetList(toptitle, SqlLanWhere)

            };
            return View(indexViewModel);
        }

        public ActionResult About()
        {
            return View(_aboutusBll.GetList(SqlLanWhere) ?? new List<Aboutus>(0));
        }

        public ActionResult MemberProgram()
        {
            return View(_aboutusBll.GetList(SqlLanWhere) ?? new List<Aboutus>(0));
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult News(string langGuid, int id = 1)
        {
            var dtNews = _news.GetListByPage(SqlLanWhere, id == 1 ? id : (id - 1)*Pagesize + 1, id*Pagesize);
            var listcount = _news.GetRecordCount(SqlLanWhere);
            if (1 == dtNews.Count && listcount == 1)
                return RedirectToAction("NewsDetail", new {langGuid = dtNews.FirstOrDefault().LangGuid});
            var viemodel = new NewsViewModel
            {
                CurrentNews =
                    String.IsNullOrEmpty(langGuid) && id == 1
                        ? dtNews.FirstOrDefault()
                        : dtNews.FirstOrDefault(
                            d => d.LangGuid == langGuid),
                NewsTitles = new PagedList<Model.CMS.News>(dtNews, id, Pagesize, listcount)
            };
            viemodel.CurrentNews = viemodel.CurrentNews ?? new Model.CMS.News();
            if (Request.IsAjaxRequest())
                return PartialView("_NewsPagerPartialPage", viemodel);
            return View(viemodel);
        }

        public ActionResult NewsDetail(string langGuid)
        {
            var newsmodel = _news.GetModelByLangGuidAndLangCode(langGuid, ResourcesHelper.GetLang());
            return View(newsmodel ?? new Model.CMS.News());
        }

        public ActionResult Events(string langGuid, int id = 1)
        {
            var dtNews = _eEvent.GetListByPage(SqlLanWhere, id == 1 ? id : (id - 1)*Pagesize + 1, id*Pagesize);
            var listcount = _eEvent.GetRecordCount(SqlLanWhere);
            var viemodel = new EventViewModel
            {
                EventTitles = new PagedList<Model.CMS.Event>(dtNews, id, Pagesize, listcount)
            };
            if (Request.IsAjaxRequest())
                return PartialView("_EventsPagerPartialPage", viemodel);
            return View(viemodel);
        }



        public ActionResult EventDetail(string langGuid)
        {
            var newsmodel = _eEvent.GetModelByLangGuidAndLangCode(langGuid, ResourcesHelper.GetLang());
            return View(newsmodel ?? new Model.CMS.Event());
        }


        public PartialViewResult JoinPary() 
        {
            return PartialView("JoinPary", new JoinPart());
        }


        [HttpPost]
        public ActionResult JoinPary(JoinPart joinPart, string returnUrl)
        {
            if (!ModelState.IsValid) return View("JoinPary", joinPart);
            if (RuHui(joinPart))
                return RedirectToAction("About");
            ModelState.AddModelError("", "入会失败");
            return View("JoinPary", joinPart);
        }


        #region 入会

        public bool RuHui(JoinPart joinPart)
        {
            try
            {
                var userInfo = new UserInfo();
                var guid = Guid.NewGuid().ToString();
                userInfo.Guid = guid;
                userInfo.UserName = joinPart.UserName;
                userInfo.Email = joinPart.Email;

                //发送邮件给系统管理员
                var modMail = new MailModel
                {
                    ToAddress = ConfigurationManager.AppSettings["EmailTo"],
                    UserCode = guid,
                    MailName = "ruhui",
                    IsActionCode = true
                };

                var listitem = new List<ListItem>
                {
                    new ListItem {Value = "{$data_RHName$}", Text = joinPart.UserName},
                    new ListItem {Value = "{$data_RHSex$}", Text = joinPart.Sex},
                    new ListItem {Value = "{$data_RHDW$}", Text = joinPart.WorkPlace},
                    new ListItem {Value = "{$data_RHZW$}", Text = joinPart.Position},
                    new ListItem {Value = "{$data_RHDZ$}", Text = joinPart.Adress},
                    new ListItem {Value = "{$data_RHTel$}", Text = joinPart.Phone},
                    new ListItem {Value = "{$data_RHPhone$}", Text = joinPart.MobliePhone},
                    new ListItem {Value = "{$data_RHSHZW$}", Text = joinPart.OthersPosition},
                    new ListItem {Value = "{$data_RHEmail$}", Text = joinPart.Email},
                    new ListItem {Value = "{$data_RHComment$}", Text = joinPart.ReMark}
                };
                FrontUtility.SendMail(modMail, listitem, "来自网上的入会申请");
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }

        #endregion



        #region 注册
        public ActionResult Register(string email) 
        {
            ResourcesHelper reHelper = new ResourcesHelper("Default");
            var reRegHelper = new MS.ECP.Utility.ResourcesHelper("Register");
            if (!string.IsNullOrWhiteSpace(email) && email != reHelper.GetString("tip_Email"))
            {
                ViewBag.strEmail = email;
                ViewBag.strReEmail = email;
            }
            else
            {
                ViewBag.strEmail = reRegHelper.GetString("tip_EmailAddress");
                ViewBag.strReEmail = reRegHelper.GetString("tip_ReEmailAddress");
            }

            return View();
        }

        string strguid = Guid.NewGuid().ToString();

        [HttpPost]
        public ActionResult Register2()
        {
            Common.PageValidate val = new PageValidate();//格式验证
            ResourcesHelper reHelper = new ResourcesHelper("Register");
            #region 验证

            string pwd = Request.Form["Password"].ToString();
            string repwd = Request.Form["RePassword"].ToString();
            if (!string.IsNullOrEmpty(pwd) && !string.IsNullOrEmpty(repwd))//验证密码
            {
                if (!pwd.Equals(repwd))
                {
                    return Json(new { result = "0", errMsg = "密码不一致" });
                }
            }
            else
            {
                return Json(new { result = "0", errMsg = "请输入密码" });
            }

            string username = Request.Form["UserName"].ToString().Trim();//验证邮箱
            string email = Request.Form["Email"].ToString().Trim();//验证邮箱

            if (!string.IsNullOrEmpty(username))// username都不为空时
            {
                //判断用户唯一
                bool exist = _userinfoBLL.ExistUserName(username);
                if (exist)
                {
                    return Json(new { result = "0", errMsg = "UserName 不唯一" });
                }
            }
            else
            {
                return Json(new { result = "0", errMsg = "UserName 不能为空" });
            }

            if (!string.IsNullOrEmpty(email))// email都不为空时
            {

                if (PageValidate.IsEmail2(email) == false)//验证没通过
                {
                    return Json(new { result = "0", errMsg = "Email格式不正确" });
                }
                else
                {
                    //判断邮箱唯一
                    bool exist = _userinfoBLL.ExistEmail(email);
                    if (exist)
                    {
                        return Json(new { result = "0", errMsg = "Email 不唯一" });
                    }
                }
            }
            else
            {
                return Json(new { result = "0", errMsg = "email 不能为空" });
            }

            #endregion

            try
            {
                Model.UserInfo userInfo = new Model.UserInfo();
                string guid = Guid.NewGuid().ToString();
                userInfo.Guid = guid;
                userInfo.UserName = Request.Form["UserName"].Trim();

                userInfo.CreateTime = DateTime.Now;

                userInfo.UpdateTime = DateTime.Now;


                userInfo.Email = Request.Form["Email"];

                string enpwd = Request.Form["Password"].Trim();
                userInfo.Password = Utility.DESEncrypt.Encrypt(enpwd);
                userInfo.UserType = 1;

                string[] array = new string[] { "," };
                bool userResult = _userinfoBLL.Add(userInfo);

                if (userResult)
                {
                    //注册成功后发送邮件 激活
                    MailModel modMail = new MailModel();
                    modMail.ToAddress = userInfo.Email;
                    modMail.UserCode = guid;
                    modMail.MailName = "activemail";

                    modMail.IsActionCode = true;
                    List<ListItem> listitem = new List<ListItem>();

                    ListItem lt2 = new ListItem();
                    lt2.Value = "{$data_Code$}";
                    listitem.Add(lt2);
                    FrontUtility.SendMail(modMail, listitem, "激活邮件");
                }
                else
                {
                    return Json(new { result = "0", errMsg = "用户注册失败" });
                }

                return Json(new { result = "1", errMsg = "用户注册成功", find = Url.Action("index", "home") });

            }
            catch (Exception ee)
            {
                return Json(new { result = "0", errMsg = "用户注册失败" });
            }
        }

        #endregion

        #region 报名

        [HttpPost]
        public ActionResult BaoMing()
        {

            var lancode = Request["LangGuid"];
            if (String.IsNullOrEmpty(lancode))
                return Json(new {result = "0", errMsg = "邮件保存失败"});
            var newsmodel = _news.GetModelByLangGuidAndLangCode(lancode, ResourcesHelper.GetLang());
            IDictionary<string, string> diritems = new Dictionary<string, string>();
            foreach (var input in newsmodel.Inputs)
            {
                var requestvalue = Request[input.InputName];
                if (!input.IsAllowNull && String.IsNullOrEmpty(requestvalue))
                    return Json(new {result = "0", errMsg = input.Inputtitle + "不能为空"});
                diritems.Add(input.Inputtitle, requestvalue);
            }

            var modMail = new MailModel
            {
                ToAddress = ConfigurationManager.AppSettings["EmailTo"],
                UserCode = Guid.NewGuid().ToString(),
                MailName = "baoming2"
            };

            FrontUtility.SendMail(modMail, diritems, "来自网上的报名");
            return Json(new {result = "1", errMsg = "报名成功"}); 

            /*
            Common.PageValidate val = new PageValidate();//格式验证

            #region 验证

            string email = Request.Form["Email"].ToString().Trim();//验证邮箱 

            if (PageValidate.IsEmail2(email) == false)//验证没通过
            {
                return Json(new { result = "0", errMsg = "Email格式不正确" });
            }

            #endregion

            try
            {
                Model.UserInfo userInfo = new Model.UserInfo();
                string guid = Guid.NewGuid().ToString();
                userInfo.Guid = guid;
                userInfo.UserName = Request.Form["UserName"].Trim();

                userInfo.Email = Request.Form["Email"];

                string[] array = new string[] { "," };
                bool userResult = true;//need amanda to do, such as: 将一份报名记录保存到数据库中

                if (userResult)
                {
                    //发送邮件给系统管理员
                    MailModel modMail = new MailModel();
                    modMail.ToAddress = ConfigurationManager.AppSettings["EmailTo"].ToString();
                    modMail.UserCode = guid;
                    modMail.MailName = "baoming";

                    modMail.IsActionCode = true;
                    List<ListItem> listitem = new List<ListItem>();

                    ListItem lt2 = new ListItem();
                    lt2.Value = "{$data_UserName$}";
                    lt2.Text = Request.Form["UserName"];

                    ListItem lt3 = new ListItem();
                    lt3.Value = "{$data_ZhiWu$}";
                    lt3.Text = Request.Form["ZhiWu"];

                    ListItem lt4 = new ListItem();
                    lt4.Value = "{$data_JiGou$}";
                    lt4.Text = Request.Form["JiGou"];

                    ListItem lt5 = new ListItem();
                    lt5.Value = "{$data_Phone$}";
                    lt5.Text = Request.Form["Phone"];

                    ListItem lt6 = new ListItem();
                    lt6.Value = "{$data_Email$}";
                    lt6.Text = Request.Form["Email"];

                    ListItem lt7 = new ListItem();
                    lt7.Value = "{$data_Comment$}";
                    lt7.Text = Request.Form["Comment"];

                    listitem.Add(lt2);
                    listitem.Add(lt3);
                    listitem.Add(lt4);
                    listitem.Add(lt5);
                    listitem.Add(lt6);
                    listitem.Add(lt7);

                    FrontUtility.SendMail(modMail, listitem, "来自网上的报名");
                }
                else
                {
                    return Json(new { result = "0", errMsg = "邮件保存失败" });
                }

                return Json(new { result = "1", errMsg = "报名成功" });

            }
            catch (Exception ee)
            {
                return Json(new { result = "0", errMsg = "报名失败" });
            }*/
        }

        #endregion

  /*      #region 入会
        [HttpPost]
        public ActionResult RuHui()
        {
            Common.PageValidate val = new PageValidate();//格式验证

            #region 验证

            string email = Request.Form["rhEmail"].ToString().Trim();//验证邮箱 

            if (PageValidate.IsEmail2(email) == false)//验证没通过
            {
                return Json(new { result = "0", errMsg = "Email格式不正确" });
            }

            #endregion

            try
            {
                var userInfo = new Model.UserInfo();
                string guid = Guid.NewGuid().ToString();
                userInfo.Guid = guid;
                userInfo.UserName = Request.Form["rhName"].Trim();

                userInfo.Email = Request.Form["rhEmail"];

                string[] array = new string[] { "," };
                bool userResult = true;//need amanda to do, such as: 将一份报名记录保存到数据库中

                if (userResult)
                {
                    //发送邮件给系统管理员
                    MailModel modMail = new MailModel();
                    modMail.ToAddress = ConfigurationManager.AppSettings["EmailTo"].ToString();
                    modMail.UserCode = guid;
                    modMail.MailName = "ruhui";

                    modMail.IsActionCode = true;
                    List<ListItem> listitem = new List<ListItem>();

                    ListItem lt2 = new ListItem();
                    lt2.Value = "{$data_RHName$}";
                    lt2.Text = Request.Form["rhName"];

                    ListItem lt3 = new ListItem();
                    lt3.Value = "{$data_RHSex$}";
                    lt3.Text = Request.Form["rhSex"];

                    ListItem lt4 = new ListItem();
                    lt4.Value = "{$data_RHDW$}";
                    lt4.Text = Request.Form["rhDW"];

                    ListItem lt5 = new ListItem();
                    lt5.Value = "{$data_RHZW$}";
                    lt5.Text = Request.Form["rhZW"];

                    ListItem lt6 = new ListItem();
                    lt6.Value = "{$data_RHDZ$}";
                    lt6.Text = Request.Form["rhDZ"];

                    ListItem lt7 = new ListItem();
                    lt7.Value = "{$data_RHTel$}";
                    lt7.Text = Request.Form["rhTel"];

                    ListItem lt8 = new ListItem();
                    lt8.Value = "{$data_RHPhone$}";
                    lt8.Text = Request.Form["rhPhone"];

                    ListItem lt9 = new ListItem();
                    lt9.Value = "{$data_RHSHZW$}";
                    lt9.Text = Request.Form["rhSHZW"];

                    ListItem lt10 = new ListItem();
                    lt10.Value = "{$data_RHEmail$}";
                    lt10.Text = Request.Form["rhEmail"];

                    ListItem lt11 = new ListItem();
                    lt11.Value = "{$data_RHComment$}";
                    lt11.Text = Request.Form["rhComment"];

                    listitem.Add(lt2);
                    listitem.Add(lt3);
                    listitem.Add(lt4);
                    listitem.Add(lt5);
                    listitem.Add(lt6);
                    listitem.Add(lt7);
                    listitem.Add(lt8);
                    listitem.Add(lt9);
                    listitem.Add(lt10);
                    listitem.Add(lt11);

                    FrontUtility.SendMail(modMail, listitem, "来自网上的入会申请");
                }
                else
                {
                    return Json(new { result = "0", errMsg = "邮件保存失败！" });
                }

                return Json(new { result = "1", errMsg = "入会申请填报成功！" });

            }
            catch (Exception ee)
            {
                return Json(new { result = "0", errMsg = "入会申请填报失败！" });
            }
        }
        #endregion

*/
    

      




    }
}
        