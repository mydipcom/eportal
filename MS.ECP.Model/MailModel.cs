using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.ECP.Model
{
    public class MailModel
    {
        public string ToAddress { get; set; }

        public string CCAddress { get; set; }

        public string BCCAddress { get; set; }

        public string Body { get; set; }

        /// <summary>
        /// 发送模式：0：文本，1：HTML
        /// </summary>
        public string SendModel { get; set; }

        /// <summary>
        /// 邮件名称
        /// </summary>
        public string MailName { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 是否需要激活码
        /// </summary>
        public bool IsActionCode { get; set; }

        public string WebRegion { set; get; }

    }
}
