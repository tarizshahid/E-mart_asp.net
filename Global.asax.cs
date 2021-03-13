using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;
using System.Web.Optimization;
using MemberDemoApp.App_Start;

namespace MemberDemoApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeDBProcess();
        }

        private void InitializeDBProcess()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("PracticeDemo", "Login", "UserId", "UserName", autoCreateTables: true);
                //WebSecurity.CreateUserAndAccount("tariz", "admin123");
                //  Roles.CreateRole("User");
                //Roles.CreateRole("Admin");
                //Roles.AddUserToRole("tariz", "Admin");
               
            }
        }
    }
}
