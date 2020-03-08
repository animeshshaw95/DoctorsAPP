using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DATAMODEL
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="User name is required")]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [StringLength(8,ErrorMessage ="Minimum 8 characters required for password")]
        public string Password { get; set; }

        public bool Rememberme { get; set; }
    }
}
