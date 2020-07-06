using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Response
{
    public class Product_Response_v1
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Prize { get; set; }

    }
}