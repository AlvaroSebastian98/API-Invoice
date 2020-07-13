using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppInvoice.Models.Request
{
    public class InvoiceDetailRequest
    {
        public int Quantity { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
    }
}