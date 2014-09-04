using System.ComponentModel.DataAnnotations;

namespace MS.ECP.AAMAPrd.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Password { get; set; }
    }
}