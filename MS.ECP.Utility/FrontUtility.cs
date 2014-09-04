using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
 
 
 
using MS.ECP.BLL;
using MS.ECP.Common;
using MS.ECP.Model;

namespace MS.ECP.Utility
{
    public class FrontUtility
    {
        //加载系统所有语言
        public static DataTable GetSysRegion()
        {
            string cacheName = "Region-Cache";
            object cacheRegion = DataCache.GetCache(cacheName);
            if (cacheRegion == null)
            {
                MS.ECP.BLL.SysWebRegion bllRegion = new BLL.SysWebRegion();
                DataTable dtRegion = bllRegion.GetList(" status='1' ").Tables[0];
                DataCache.SetCache(cacheName, dtRegion);
                return dtRegion;
            }
            else
            {
                return (DataTable) DataCache.GetCache(cacheName);
            }
        }

        //所有语言 HTML
        public static string AllLanguageHtml(string checkCode, string where)
        {
            string key = "Language-" + ResourcesHelper.GetLang().ToUpper();
            List<Model.SysLanguage> listModel = null;
            object cache = DataCache.GetCache(key);
            if (cache != null)
            {
                listModel = (List<Model.SysLanguage>) cache;
            }
            else
            {
                listModel =
                    new BLL.SysLanguage().GetList(" LanguageStatus='1' and WebRegion='" + ResourcesHelper.GetLang() +
                                                  "' " + (string.IsNullOrWhiteSpace(where) ? "" : " and " + where)) as
                        List<Model.SysLanguage>;
                DataCache.SetCache(key, listModel);
            }
            StringBuilder builder = new StringBuilder();
            foreach (Model.SysLanguage model in listModel)
            {
                builder.Append(string.Format("<option value=\"{0}\" {2}>{1}</option>", model.LanguageCode,
                    model.LanguageText, (model.LanguageCode == checkCode ? "selected=\"selected\"" : "")));
            }
            return builder.ToString();
        }



        //Currency Symbol
        public static string CurrencySymbol2(string currency)
        {
            string symbol = "";
            switch (currency.Trim().ToUpper())
            {
                case "001": //USD $
                case "003": //AUD
                case "005": //CAD
                    symbol = "&#36;";
                    break;
                case "002": //YEN ¥
                    symbol = "&#165;";
                    break;
                case "004": //EURO €
                    symbol = "&#8364;";
                    break;
                case "006": //CHF
                    symbol = "CHF";
                    break;
            }
            return symbol;
        }

        public static string CurrencySymbol(string currency)
        {
            string symbol = "";
            switch (currency.Trim().ToUpper())
            {
                case "001": //USD $
                    symbol = "USD";
                    break;
                case "002": //YEN ¥
                    symbol = "JPY";
                    break;
                case "003": //AUD
                    symbol = "AUD";
                    break;
                case "004": //EURO €
                    symbol = "EUR";
                    break;
                case "005": //CAD
                    symbol = "CAD";
                    break;
                case "006": //CHF
                    symbol = "CHF";
                    break;
                case "007": //CHF
                    symbol = "GBP";
                    break;
                case "008": //CHF
                    symbol = "CNY";
                    break;
                case "009": //CHF
                    symbol = "KRW";
                    break;
            }
            return symbol;
        }

        //生成页码
        /// <summary>
        /// 生成页码
        /// </summary>
        /// <param name="perCount">每页行数</param>
        /// <param name="total">数量总行数</param>
        /// <param name="pageIndex">当前页</param>
        /// <returns></returns>
        public static string CreatePageCode(int perCount, int total, int pageIndex, string href)
        {
            if (total == 0)
            {
                return "";
            }
            int pageCount = (perCount >= total) ? 1 : ((total%perCount > 0) ? (total/perCount + 1) : total/perCount);
            StringBuilder pageBuilder = new StringBuilder();
            //当前页面不为1时，加载上一页
            if (pageIndex != 1)
            {
                pageBuilder.Append("<a href='" + href + "/" + (pageIndex - 1).ToString() + "'><</a>");
                pageBuilder.Append("<a href='" + href + "/1'>1</a>");
            }
            // 小于20页时显示全部页码
            if (pageCount < 20)
            {
                if (pageIndex == 1)
                {
                    pageBuilder.Append("<span class='current'>1</span>");
                }
                for (int i = 2; i <= pageCount - 1; i++)
                {
                    if (i == pageIndex)
                    {
                        pageBuilder.Append("<span class='current'>" + i.ToString() + "</span>");
                    }
                    else
                    {
                        pageBuilder.Append("<a href='" + href + "/" + i.ToString() + "'>" + i.ToString() + "</a>");
                    }
                }
                if (pageIndex == pageCount && pageCount != 1)
                {
                    pageBuilder.Append("<span class='current'>" + pageCount.ToString() + "</span>");
                }
            }
            else
            {
                int count = (pageIndex > 95) ? 8 : 10; //前5后5
                int prev = count/2;
                int next = count/2;
                int pIndex = pageIndex;
                int temp = 0;

                if (pageIndex - prev < 2)
                {
                    prev = pageIndex - 2;
                }
                if (pageIndex + next > pageCount - 1)
                {
                    next = pageCount - pageIndex - 1;
                }
                if (prev < count/2)
                {
                    next = count - prev;
                }
                if (next < count/2)
                {
                    prev = count - next;
                }

                ArrayList arr = new ArrayList();
                //前半部分
                temp = prev;
                while (prev > 0)
                {
                    pIndex--;
                    arr.Add("<a href='" + href + "/" + pIndex.ToString() + "'> " + pIndex.ToString() + "</a>");
                    prev--;

                }
                //前半部分没有显示页码1，则需要显示"..."
                if (pIndex > 10)
                {
                    pageBuilder.Append("<a>...</a>");
                }
                for (int j = arr.Count; j > 0; j--)
                {
                    pageBuilder.Append(arr[j - 1].ToString());
                }
                pageBuilder.Append("<span class='current'>" + pageIndex.ToString() + "</span>");
                pIndex = pageIndex;
                temp = next;
                while (next > 0)
                {
                    pIndex++;
                    pageBuilder.Append("<a href='" + href + "/" + pIndex.ToString() + "'> " + pIndex.ToString() + "</a>");
                    next--;
                }
                //前半部分没有显示页码1，则需要显示"..."
                if (pIndex < pageCount - 1)
                {
                    pageBuilder.Append("<a>...</a>");
                }
            }
            if (pageCount != pageIndex)
            {
                pageBuilder.Append("<a href='" + href + "/" + pageCount.ToString() + "'>" + pageCount.ToString() +
                                   "</a>");
                pageBuilder.Append("<a href='" + href + "/" + (pageIndex + 1).ToString() + "'>></a>");
            }

            return pageBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="perCount"></param>
        /// <param name="total"></param>
        /// <param name="pageIndex"></param>
        /// <param name="href"></param>
        /// <returns></returns>
        public static string CreatePageIndex(int perCount, int total, int pageIndex, string href) //首页翻页样式
        {
            if (total == 0)
            {
                return "";
            }
            int pageCount = (perCount >= total) ? 1 : ((total%perCount > 0) ? (total/perCount + 1) : total/perCount);
            StringBuilder pageBuilder = new StringBuilder();
            //当前页面不为1时，加载上一页
            if (pageIndex != 1)
            {
                pageBuilder.Append("<a href='" + href + "/" + (pageIndex - 1).ToString() + "'><</a>");
                pageBuilder.Append("<a href='" + href + "/1'>1</a>");
            }
            // 小于10页时显示全部页码
            if (pageCount < 10)
            {
                if (pageIndex == 1)
                {
                    pageBuilder.Append("<span class='current'>1</span>");
                }
                for (int i = 2; i <= pageCount - 1; i++)
                {
                    if (i == pageIndex)
                    {
                        pageBuilder.Append("<span class='current'>" + i.ToString() + "</span>");
                    }
                    else
                    {
                        pageBuilder.Append("<a href='" + href + "/" + i.ToString() + "'>" + i.ToString() + "</a>");
                    }
                }
                if (pageIndex == pageCount && pageCount != 1)
                {
                    pageBuilder.Append("<span class='current'>" + pageCount.ToString() + "</span>");
                }
            }
            else
            {
                int count = (pageIndex > 95) ? 4 : 5; //前5后5
                int prev = count/2;
                int next = count/2;
                int pIndex = pageIndex;
                int temp = 0;

                if (pageIndex - prev < 2)
                {
                    prev = pageIndex - 2;
                }
                if (pageIndex + next > pageCount - 1)
                {
                    next = pageCount - pageIndex - 1;
                }
                if (prev < count/2)
                {
                    next = count - prev;
                }
                if (next < count/2)
                {
                    prev = count - next;
                }

                ArrayList arr = new ArrayList();
                //前半部分
                temp = prev;
                while (prev > 0)
                {
                    pIndex--;
                    arr.Add("<a href='" + href + "/" + pIndex.ToString() + "'> " + pIndex.ToString() + "</a>");
                    prev--;

                }
                //前半部分没有显示页码1，则需要显示"..."
                if (pIndex > 2)
                {
                    pageBuilder.Append("<a  href='" + href + "/" + (pIndex - 1).ToString() + "'>...</a>");
                }
                for (int j = arr.Count; j > 0; j--)
                {
                    pageBuilder.Append(arr[j - 1].ToString());
                }
                pageBuilder.Append("<span class='current'>" + pageIndex.ToString() + "</span>");
                pIndex = pageIndex;
                temp = next;
                while (next > 0)
                {
                    pIndex++;
                    pageBuilder.Append("<a href='" + href + "/" + pIndex.ToString() + "'> " + pIndex.ToString() + "</a>");
                    next--;
                }
                //前半部分没有显示页码1，则需要显示"..."
                if (pIndex < pageCount - 1)
                {
                    pageBuilder.Append("<a href='" + href + "/" + (pIndex + 1).ToString() + "'>...</a>");
                }
            }
            if (pageCount != pageIndex)
            {
                pageBuilder.Append("<a href='" + href + "/" + pageCount.ToString() + "'>" + pageCount.ToString() +
                                   "</a>");
                pageBuilder.Append("<a href='" + href + "/" + (pageIndex + 1).ToString() + "'>></a>");
            }

            return pageBuilder.ToString();
        }

        //format datetime
        public static string FormatDataTime(string datetime)
        {
            return Convert.ToDateTime(datetime).ToString("d", Thread.CurrentThread.CurrentCulture);
        }

        //format datetime
        public static string FormatDataTime(DateTime datetime)
        {
            return datetime.ToString("d", Thread.CurrentThread.CurrentCulture);
        }


        // 发送邮件
        public static bool SendMail(MailModel model, IDictionary<string, string> listKeys, string fliename)
        {
            bool result = true;
            string activeCode = string.Empty;
            string webRegion = string.IsNullOrWhiteSpace(model.WebRegion) ? ResourcesHelper.GetLang() : model.WebRegion;
            try
            {
                var myMail = new MailMessage();
                MailBodyBaoMing(model, listKeys);
                myMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPEmail"], "AAMAPrd.com");
                if (!string.IsNullOrEmpty(model.ToAddress))
                {
                    myMail.To.Add(new MailAddress(model.ToAddress));
                }

                myMail.Subject = fliename;
                myMail.Body = model.Body;
                myMail.IsBodyHtml = model.SendModel != "0";
                myMail.BodyEncoding = Encoding.UTF8;

                var objSmtpClient = new SmtpClient
                {
                    Host = ConfigurationManager.AppSettings["SMTPServer"],
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPEmail"],
                        ConfigurationManager.AppSettings["SMTPPassword"])
                };

                objSmtpClient.Send(myMail);
            }

            catch (Exception ee)
            {
                result = false;
            }

            return result;
        }




        // 发送邮件
        public static bool SendMail(MailModel model, List<ListItem> listKeys, string Subject)
        {
            bool result = true;
            string activeCode = string.Empty;
            string webRegion = string.IsNullOrWhiteSpace(model.WebRegion) ? ResourcesHelper.GetLang() : model.WebRegion;
            try
            {
                MailMessage myMail = new MailMessage();
                MailBodyBaoMing(model, listKeys);
                myMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPEmail"].ToString(), "AAMAPrd.com");
                if (!string.IsNullOrEmpty(model.ToAddress))
                {
                    myMail.To.Add(new MailAddress(model.ToAddress));
                }

                myMail.Subject = Subject;
                myMail.Body = model.Body;
                myMail.IsBodyHtml = model.SendModel == "0" ? false : true;
                myMail.BodyEncoding = Encoding.UTF8;

                SmtpClient objSmtpClient = new SmtpClient();
                objSmtpClient.Host = ConfigurationManager.AppSettings["SMTPServer"].ToString();
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials =
                    new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPEmail"].ToString(),
                        ConfigurationManager.AppSettings["SMTPPassword"].ToString());

                objSmtpClient.Send(myMail);
            }

            catch (Exception ee)
            {
                result = false;
            }

            return result;
        }

        // 发送邮件
        public static bool SendMailMiss(MailModel model, List<ListItem> listKeys, string Subject)
        {
            bool result = true;
            string activeCode = string.Empty;
            string webRegion = string.IsNullOrWhiteSpace(model.WebRegion) ? ResourcesHelper.GetLang() : model.WebRegion;
            try
            {
                MailMessage myMail = new MailMessage();
                MailBodyBaoMing(model, listKeys);
                myMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPEmail"].ToString(),
                    "www.missionsky.com");
                if (!string.IsNullOrEmpty(model.ToAddress))
                {
                    myMail.To.Add(new MailAddress(model.ToAddress));
                }

                myMail.Subject = Subject;
                myMail.Body = model.Body;
                myMail.IsBodyHtml = model.SendModel == "0" ? false : true;
                myMail.BodyEncoding = Encoding.UTF8;

                SmtpClient objSmtpClient = new SmtpClient();
                objSmtpClient.Host = ConfigurationManager.AppSettings["SMTPServer"].ToString();
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials =
                    new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPEmail"].ToString(),
                        ConfigurationManager.AppSettings["SMTPPassword"].ToString());

                objSmtpClient.Send(myMail);
            }

            catch (Exception ee)
            {
                result = false;
            }

            return result;
        }

        // 取得邮件内容
        public static void MailBodyBaoMing(MailModel model, List<ListItem> listKeys)
        {
            string content = string.Empty;
            ResourcesHelper resHelper = new ResourcesHelper(model.MailName);

            string path =
                HttpContext.Current.Server.MapPath(string.Format("~/Resource/{1}.html", ResourcesHelper.GetLang(),
                    model.MailName));
            StreamReader reader = new StreamReader(path);
            if (File.Exists(path))
            {
                content = reader.ReadToEnd();
                reader.Close();

                content = content.Replace("{$data_Domain$}", ConfigurationManager.AppSettings["Domain"].ToString());

                if (listKeys != null)
                {
                    foreach (ListItem li in listKeys)
                    {
                        content = content.Replace(li.Value, li.Text);
                    }
                }

                model.Body = content;
            }
            else
            {
                throw new Exception("No email format file");
            }
        }





        // 取得邮件内容
        public static void MailBodyBaoMing(MailModel model, IDictionary<string, string> listKeys)
        {
            var emailmodle = @"<p style=""font-size: 12px;"">  {0}：{1}  </p>                                ";

            string content = string.Empty;
            ResourcesHelper resHelper = new ResourcesHelper(model.MailName);

            string path =
                HttpContext.Current.Server.MapPath(string.Format("~/Resource/{1}.html", ResourcesHelper.GetLang(),
                    model.MailName));
            StreamReader reader = new StreamReader(path);
            if (File.Exists(path))
            {
                content = reader.ReadToEnd();
                reader.Close();

                content = content.Replace("{$data_Domain$}", ConfigurationManager.AppSettings["Domain"].ToString());

                if (listKeys != null)
                {
                    var sb = new StringBuilder();
                    foreach (var kv in listKeys)
                    {
                        sb.Append(String.Format(emailmodle, kv.Key, kv.Value));
                    }
                    content = content.Replace("{$data_Content$}", sb.ToString());
                }

                model.Body = content;
            }
            else
            {
                throw new Exception("No email format file");
            }
        }
    }
}
