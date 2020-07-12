using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Detail_Request_v2
    {
        public int Quantity { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int InvoiceID { get; set; }
    }
}