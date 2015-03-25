namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string UserName { get; set; }
    }
}
