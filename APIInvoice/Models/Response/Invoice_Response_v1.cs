using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Response
{
    public class Invoice_Response_v1
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public List<Detail_Response_v1> Details { get; set; }
    }
}