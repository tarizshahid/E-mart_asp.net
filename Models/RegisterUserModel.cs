using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberDemoApp.Models
{
    public class RegisterUserModel
    {
        //Full name
        [Display (Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName {get;set;}
       
        //User Name
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        //Password
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //confirm password
        [Display(Name = " Confirm Password")]
        [Required(ErrorMessage = "Field is required.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //Email Id
        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Field is required.")]
        public string email { get; set; }

        //Confirm Email Id
        [Display(Name = "Confirm Email id")]
        [Required(ErrorMessage = "Field is required.")]
        public string ConfirmEmail { get; set; }

        //Role
        [Display(Name = "User Role")]
        [Required(ErrorMessage = "Field is required.")]
        [UIHint("RolesDropDownList")]
        public string Role { get; set; }
    }
}