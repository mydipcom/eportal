using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using MS.ECP.Web.Filters;

namespace MS.ECP.Web.Models
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
        [RequiredMessage("请输入{0}")]
        [Display(Name = "用户名")]
        [StringLength(30, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
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
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "协议")]
        [RequiredTrue(ErrorMessage = "请同意")]
        public bool RememberMe { get; set; }
    }


/*    public class RegisterModel
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
        public string PasswordSalt { get; set; }



        [Display(Name = "Remember me?")]
        [RequiredTrue(ErrorMessage = "请同意")]
        public bool RememberMe { get; set; }


        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "联系电话")]
        public string MobilePhone { get; set; }

        [Required]
        [Display(Name = "联系地址")]
        public string Address { get; set; }

        [Display(Name = "工作公司")]
        public string CompanyName { get; set; } 

    }*/
}
