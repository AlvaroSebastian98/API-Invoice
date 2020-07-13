using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppInvoice.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public List<InvoiceDetail> Details { get; set; }
    }
}