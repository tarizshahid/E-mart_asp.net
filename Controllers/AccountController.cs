using MemberDemoApp.Models;
using MemberDemoApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace MemberDemoApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult AboutUs ()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                bool authenticated = WebSecurity.Login(loginModel.Username, loginModel.password, loginModel.RememberMe);
                string qs = Request.QueryString["ReturnUrl"];
                if (qs == null && authenticated)
                {
                    return RedirectToAction("Products", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "The username or the password is incorrect.");
                   // return Redirect(Url.Content(qs));
                    return View();
                }
            }
            ModelState.AddModelError("", "The username or the password is incorrect.");
            return View();
        }
        
        public ActionResult Signout ()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [Authorize]
        public ActionResult RegisterUser()
        {
            if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Admin"))
            {
                ViewBag.RoleId = 1;
            }
            else
            {
                ViewBag.RoleId = 0;
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult RegisterUser(RegisterUserModel registerUserModel)
        {
            if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Admin"))
            {
                ViewBag.RoleId = 1;
            }
            else
            {
                ViewBag.RoleId = 0;
            }
            if (ModelState.IsValid)
            {
                bool isUserNameExists = WebSecurity.UserExists(registerUserModel.UserName);
                if (isUserNameExists)
                {
                    ModelState.AddModelError("UserName", "User Name already Exists");
                }
                WebSecurity.CreateUserAndAccount(registerUserModel.UserName, registerUserModel.Password, new { FullName = registerUserModel.FullName, Email = registerUserModel.email });
                Roles.AddUserToRole(registerUserModel.UserName, registerUserModel.Role);
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpGet, Authorize]
        public ActionResult ChangePassword ()
        {
            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult ChangePassword (ChangePassword changePassword)
        {
            bool isPasswordChanged = WebSecurity.ChangePassword(WebSecurity.CurrentUserName, changePassword.currentPassword, changePassword.newPassword);
            if (isPasswordChanged)
            {
                //ViewBag.Message = "The Password has been changed successfully";
                return RedirectToAction("Index","Dashboard");
            }    
           
            return View();
        }
        
        [HttpGet, Authorize]
        public ActionResult UserProfile ()
        {
            UserProfileModel userProfile = AccountViewModel.getUserProfile(WebSecurity.CurrentUserId);
            return View(userProfile);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult UserProfile (UserProfileModel userProfile)
        {
            if (ModelState.IsValid)
            {
                AccountViewModel.updateUserProfile(userProfile);
                ViewBag.Message = "Profile has been updated successfully";
            }
            return View();
        }

        [HttpGet, Authorize(Roles ="Admin, Manager")]
        public ActionResult AllUsers ()
        {
           List<AllUsersModel> allUsers = AccountViewModel.GetAllUsers();
            return View(allUsers);
        }
    }
}