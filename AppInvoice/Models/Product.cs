using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppInvoice.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Prize { get; set; }
    }
}