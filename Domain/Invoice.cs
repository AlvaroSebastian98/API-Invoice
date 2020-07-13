using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        //--1 Invoice have many details
        public List<Detail> Details { get; set; }        

        public User Client { get; set; }
        [ForeignKey("Client")]
        public int ClientID { get; set; }

        public bool State { get; set; }
    }

}
