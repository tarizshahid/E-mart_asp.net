using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberDemoApp.Models
{
    public class ProductsClass
    {
        public string ProductName { get; set; }
        public int ProductID{ get; set; }
        public int Price { get; set; }
        public int StockRemaining { get; set; }
        public string Size{ get; set; }
        public string ProductType { get; set; }
        public int randoom { get; set; }
    }
}