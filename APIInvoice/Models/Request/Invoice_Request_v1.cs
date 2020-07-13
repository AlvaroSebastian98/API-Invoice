using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Invoice_Request_v1
    {
        public List<Detail_Request_v1> Details { get; set; }
        public DateTime DueDate { get; set; }
        public int ClientID { get; set; }        
    }
}