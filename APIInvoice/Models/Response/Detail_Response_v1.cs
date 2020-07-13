using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Response
{
    public class Detail_Response_v1
    {
        public int DetailID { get; set; }
        public int Quantity { get; set; }
        public int Prize { get; set; }
        public string Description { get; set; }
        public Product_Response_v2 Product { get; set; }
        //public int ProductID { get; set; }
        //public string ProductName { get; set; }        
    }
}