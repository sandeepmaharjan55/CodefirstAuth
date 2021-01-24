using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.codefirst.authentication.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}