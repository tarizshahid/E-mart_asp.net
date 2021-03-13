using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberDemoApp.Models
{
    public class UserProfileModel
    {
        [Display(Name = "User Id")]

        public string userId { get; set; }
        [Display(Name = "UserName")]
        public string userName { get; set; }

        [Display(Name = "Full Name")]
        public string fullName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}