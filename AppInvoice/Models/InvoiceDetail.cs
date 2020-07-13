using AppInvoice.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppInvoice.Models
{
    public class InvoiceDetail
    {
        public int DetailID { get; set; }
        public int Quantity { get; set; }
        public int Prize { get; set; }
        public ProductResponse Product { get; set; }
    }
}