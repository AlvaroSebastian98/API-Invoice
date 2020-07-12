using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Detail_Request_v3
    {
        public int DetailID { get; set; }
        public int Quantity { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int InvoiceID { get; set; }
    }
}