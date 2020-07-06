using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Product_Request_v1
    {        
        public string ProductName { get; set; }
        public int Prize { get; set; }
        public int Stock { get; set; }
    }
}