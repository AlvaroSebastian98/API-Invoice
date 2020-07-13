using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Product_Request_v4
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Prize { get; set; }
        public int Stock { get; set; }
    }
}