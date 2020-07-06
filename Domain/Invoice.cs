using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }        
       //--1 Invoice have many details
        public List<Detail> Details { get; set; }
    }

    public class Test
    {
        public Test()
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceNumber = "f001";
            invoice.Date = DateTime.Today;
            invoice.Details.Add(new Detail { DetailID = 1 });
            invoice.Details.Add(new Detail { DetailID = 2 });
            invoice.Details.Add(new Detail { DetailID = 3 });
            invoice.Details.Add(new Detail { DetailID = 4 });
        }
    }

}
