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
                Invoice = context.Invoices.Find(ID);
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

        // No hay método para actualizar ya que los campos de Invoice son autogenerados

        public bool Delete(int ID)
        {
            bool status;
            try
            {
                using (var context = new InvoiceContext())
                {
                    // TODO: Eliminar (¿primero?) también los productos de la tabla Detail que estén relacionados
                    // con la factura eliminada
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
