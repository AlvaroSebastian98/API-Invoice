using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Detail_Request_v1
    {
        public string Description { get; set; }
        public int Quantity { get; set; }        
        public int ProductID { get; set; }
    }
}