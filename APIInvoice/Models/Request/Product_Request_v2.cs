using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Product_Request_v2
    {
        public int ProductID { get; set; }
        public int Prize { get; set; }
    }
    public class Product_Request_v3
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}