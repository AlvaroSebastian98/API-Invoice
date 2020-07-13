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
        public DateTime DueDate { get; set; }
        public string InvoiceNumber { get; set; }        
        public Client_Response_v1 Client { get; set; }
        //public int ClientID { get; set; }
        public List<Detail_Response_v1> Details { get; set; }
    }
}