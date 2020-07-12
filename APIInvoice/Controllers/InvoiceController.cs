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

        public List<Invoice_Response_v1> GetAllInvoices()
        {
            var response = (from c in invoiceService.Get()
                            select
                            new Invoice_Response_v1
                            {
                                InvoiceID = c.InvoiceID,
                                InvoiceNumber = c.InvoiceNumber,
                                Date = c.Date,
                                Details = (from d in detailService.Get()
                                           where d.InvoiceID == c.InvoiceID
                                           select                                          
                                           new Detail_Response_v1
                                           {
                                               DetailID = d.DetailID,
                                               Quantity = d.Quantity,
                                               Prize = d.Prize,
                                               //ProductID = d.ProductID,
                                               //ProductName = productService.GetById(d.ProductID).ProductName
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
                Details = (from d in detailService.Get()
                           select
                           new Detail_Response_v1
                           {
                               DetailID = d.DetailID,
                               Quantity = d.Quantity,
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
            invoice.Details = (from d in request.Details
                               select
                               new Detail
                               {
                                   Quantity = d.Quantity,
                                   ClientID = d.ClientID,
                                   ProductID = d.ProductID
                               }).ToList();

            bool status = await invoiceService.Insert(invoice);
            return status;

        }

        // No hay método para actualizar ya que los campos de Invoice son autogenerados

        public bool DeleteInvoice(int id)
        {
            bool status = invoiceService.Delete(id);
            return status;
        }
    }
}
