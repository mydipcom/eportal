using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MS.ECP.Web.Filters;

namespace MS.ECP.Web.Areas.Admin.Models
{
    public class LoginModel
    {
        [RequiredMessage("Username", "{0} cannot be empty")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}