using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Invoice_Request_v2
    {
        public int InvoiceID { get; set; }
        public DateTime DueDate { get; set; }
        public int ClientID { get; set; }
    }
}