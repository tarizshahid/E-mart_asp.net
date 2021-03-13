using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberDemoApp.Models
{
    public class ChangePassword
    {
        [Display(Name = "Old Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string currentPassword { get; set; }


        [Display(Name = "New Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }


        [Display(Name = "Confirm New Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Compare(otherProperty: "newPassword", ErrorMessage = "Password doesn't match")]
        public string ConfirmNewPassword { get; set; }
    }
}