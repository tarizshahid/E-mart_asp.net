using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberDemoApp.Models
{
    public class LoginModel
    {
        [Display(Name = "Username: ")]
        [Required (ErrorMessage = "Please Enter Username: ")]
        public string Username { get; set; }


        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password: ")]
        public string password { get; set; }


        [Display(Name = "Remember Me: ")]
        public bool RememberMe { get; set; }
    }
}