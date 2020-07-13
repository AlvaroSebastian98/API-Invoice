using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppInvoice.Models.Request
{
    public class InvoiceRequest
    {
        List<InvoiceDetailRequest> Details { get; set; }
    }
}