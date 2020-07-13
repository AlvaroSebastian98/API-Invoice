using APIInvoice.Models.Request;
using APIInvoice.Models.Response;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIInvoice.Controllers
{
    public class InvoiceController : ApiController
    {
        private InvoiceService invoiceService = new InvoiceService();
        private DetailService detailService = new DetailService();
        private ProductService productService = new ProductService();
        private ClientService clientService = new ClientService();

        public List<Invoice_Response_v1> GetAllInvoices()
        {
            var response = (from c in invoiceService.Get()
                            where c.State == true
                            select
                            new Invoice_Response_v1
                            {
                                InvoiceID = c.InvoiceID,
                                InvoiceNumber = c.InvoiceNumber,
                                Date = c.Date,
                                DueDate = c.DueDate,
                                Client = new Client_Response_v1
                                {
                                    ClientID = c.ClientID,
                                    Username = clientService.GetById(c.ClientID).Username
                                },
                                Details = (from d in detailService.Get()
                                           where d.InvoiceID == c.InvoiceID
                                           select
                                           new Detail_Response_v1
                                           {
                                               DetailID = d.DetailID,
                                               Quantity = d.Quantity,
                                               Description = d.Description,
                                               Prize = d.Prize,
                                               Product = new Product_Response_v2
                                               {
                                                   ProductID = d.ProductID,
                                                   ProductName = productService.GetById(d.ProductID).ProductName
                                               }
                                           }).ToList()
                            }).ToList();

            return response;
        }

        public Invoice_Response_v1 GetInvoiceById(int id)
        {
            Invoice invoice = invoiceService.GetById(id);

            Invoice_Response_v1 invoiceResponse = new Invoice_Response_v1
            {
                InvoiceID = invoice.InvoiceID,
                InvoiceNumber = invoice.InvoiceNumber,
                Date = invoice.Date,
                DueDate = invoice.DueDate,
                Client = new Client_Response_v1
                {
                    ClientID = invoice.ClientID,
                    Username = clientService.GetById(invoice.ClientID).Username
                },
                Details = (from d in detailService.Get()
                           where d.InvoiceID == invoice.InvoiceID
                           select
                           new Detail_Response_v1
                           {
                               DetailID = d.DetailID,
                               Quantity = d.Quantity,
                               Description = d.Description,
                               Prize = d.Prize,
                               Product = new Product_Response_v2
                               {
                                   ProductID = d.ProductID,
                                   ProductName = productService.GetById(d.ProductID).ProductName
                               }
                           }).ToList()
            };

            return invoiceResponse;
        }

        public async Task<bool> InsertInvoice([FromBody] Invoice_Request_v1 request)
        {
            Invoice invoice = new Invoice();
            invoice.DueDate = request.DueDate;
            invoice.ClientID = request.ClientID;
            invoice.Details = (from d in request.Details
                               select
                               new Detail
                               {
                                   Quantity = d.Quantity,
                                   Description = d.Description,
                                   ProductID = d.ProductID
                               }).ToList();

            bool status = await invoiceService.Insert(invoice);
            return status;

        }

        public bool UpdateInvoice([FromBody] Invoice_Request_v2 request)
        {
            bool status;
            try
            {
                Invoice invoice = new Invoice();
                invoice.InvoiceID = request.InvoiceID;
                invoice.DueDate = request.DueDate;
                invoice.ClientID = request.ClientID;

                invoiceService.Update(invoice, invoice.InvoiceID);
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }        

        public async Task<bool> DeleteInvoice(int id)
        {
            bool status = await invoiceService.Delete(id);
            return status;
        }
    }
}
