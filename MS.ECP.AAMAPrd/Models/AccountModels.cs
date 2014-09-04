using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mail;
using System.Web.Mvc;
using System.Web.Security;

namespace MS.ECP.AAMAPrd.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "电子邮件地址")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }



    public class JoinPart
    {
        [Required(ErrorMessage = "{0}必须填写")]
        [Display(Name = "姓名")]
        public string UserName { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "工作单位")]
        public string WorkPlace { get; set; }

        [Display(Name = "职务")]
        public string Position { get; set; }

        [Display(Name = "通讯地址")]
        public string Adress { get; set; }

        [Display(Name = "办公电话")]
        public string Phone { get; set; }

        [Display(Name = "手机")]
        public string MobliePhone { get; set; }

        [Required(ErrorMessage = "{0}必须填写")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "{0}格式错误")]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Display(Name = "社会职务/荣誉称号")]
        public string OthersPosition { get; set; }

        [Display(Name = "备注")]
        public string ReMark { get; set; }

        [Display(Name = "使用优惠券")]
        public bool Coupon { get; set; }

    }
}
