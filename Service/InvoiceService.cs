using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InvoiceService
    {
        public List<Invoice> Get()
        {
            List<Invoice> Invoices = null;
            using (var context = new InvoiceContext())
            {

                Invoices = context.Invoices.ToList();

            }
            return Invoices;
        }

        public Invoice GetById(int ID)
        {
            Invoice Invoice = null;

            using (var context = new InvoiceContext())
            {
                Invoice = context.Invoices.Where((invoice) => invoice.InvoiceID == ID && invoice.State == true).First();
            }

            return Invoice;
        }

        public async Task<bool> Insert(Invoice Invoice)
        {
            DetailService detailService = new DetailService();
            bool status;
            int invoiceID;

            try
            {
                using (var context = new InvoiceContext())
                {
                    Invoice.Date = DateTime.Today;
                    Invoice.InvoiceNumber = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                    Invoice.State = true;

                    context.Invoices.Add(Invoice);                    

                    invoiceID = Invoice.InvoiceID;
                }

                //Agregar Detalle
                List<Detail> details = Invoice.Details;
                await detailService.InsertwithInvoice(details, invoiceID);

                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public void Update(Invoice Invoice, int ID)
        {
            using (var context = new InvoiceContext())
            {
                var InvoiceNew = context.Invoices.Find(ID);
                InvoiceNew.DueDate = Invoice.DueDate == null ? InvoiceNew.DueDate : Invoice.DueDate;
                InvoiceNew.ClientID = Invoice.ClientID == 0 ? InvoiceNew.ClientID : Invoice.ClientID;
                context.SaveChanges();
            }
        }

        public async Task<bool> Delete(int ID)
        {
            DetailService detailService = new DetailService();
            bool status;

            try
            {
                // TODO: Eliminar (¿primero?) también los productos de la tabla Detail que estén relacionados
                // con la factura eliminada
                List<Detail> Details = detailService.Get().Where((detail) => detail.InvoiceID == ID).ToList();

                await detailService.DeleteWithInvoice(Details);                

                using (var context = new InvoiceContext())
                {                    
                    var Invoice = context.Invoices.Find(ID);
                    Invoice.State = false;
                    context.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool Remove(int ID)
        {
            bool status;
            try
            {
                using (var context = new InvoiceContext())
                {
                    var Invoice = context.Invoices.Find(ID);
                    context.Invoices.Remove(Invoice);
                    context.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
