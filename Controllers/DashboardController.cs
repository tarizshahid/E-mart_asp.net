using MemberDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace MemberDemoApp.Controllers
{
    public class DashboardController : Controller
    {


        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Products()
        {
            List<ProductsClass> ProductData = new List<ProductsClass>();
            string MainConn = ConfigurationManager.ConnectionStrings["PracticeDemo"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(MainConn);
            string SQLquery = "select * from [dbo].[Products]";
            SqlCommand sqlCom = new SqlCommand(SQLquery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader rdr = sqlCom.ExecuteReader();
            while (rdr.Read())
            {
                ProductsClass PrCl = new ProductsClass();
                PrCl.ProductName = rdr["ProductName"].ToString();

                PrCl.Size = rdr["Size"].ToString();


                PrCl.ProductID = (int)rdr["ProductID"];

                PrCl.Price = (int)rdr["Price"];

                PrCl.StockRemaining = (int)rdr["StockRemaining"];

                PrCl.ProductType = rdr["ProductType"].ToString();
                Random r = new Random();
                int random = r.Next(500);
                PrCl.randoom = random;
                ProductData.Add(PrCl);

            }

            return View(ProductData);
        }
        string naam, sizee;
        int pricee;
        [HttpPost]
        public ActionResult Products(string UserName, int Price, string Size)
        {
            naam = UserName;
            pricee = Price;
            sizee = Size;
            return RedirectToAction("Checkout", "Dashboard");
        }

        [HttpGet]
        public ActionResult Checkout(string UserName, int Price, string Size)
        {
            ViewBag.name = UserName;
            ViewBag.price = Price;
            ViewBag.size = Size;
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(CheckoutClass obj)
        {
            
            return View();
        }
    }
}