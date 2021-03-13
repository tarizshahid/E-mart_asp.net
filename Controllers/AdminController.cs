using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberDemoApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize, ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View();
        }
    }
}