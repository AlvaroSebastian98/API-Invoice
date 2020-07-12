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
    public class DetailController : ApiController
    {
        private DetailService detailService = new DetailService();
        private ProductService productService = new ProductService();

        public Detail_Response_v1 GetDetailById(int id)
        {
            Detail detail = detailService.GetById(id);

            Detail_Response_v1 detailResponse = new Detail_Response_v1
            {
                DetailID = detail.DetailID,
                Prize = detail.Prize,
                Product = new Product_Response_v2
                {
                    ProductID = detail.ProductID,
                    ProductName = productService.GetById(detail.ProductID).ProductName
                }
            };

            return detailResponse;
        }

        public async Task<bool> InsertDetail([FromBody] Detail_Request_v2 request)
        {
            Detail detail = new Detail();
            detail.Quantity = request.Quantity;
            detail.ClientID = request.ClientID;
            detail.ProductID = request.ProductID;
            detail.InvoiceID = request.InvoiceID;

            bool status = await detailService.Insert(detail);
            return status;

        }

        public bool UpdateDetail([FromBody] Detail_Request_v3 request)
        {

            Detail detail = new Detail();
            detail.DetailID = request.DetailID;
            detail.Quantity = request.Quantity;
            detail.ClientID = request.ClientID;
            detail.ProductID = request.ProductID;
            detail.InvoiceID = request.InvoiceID;
            
            bool status = detailService.Update(detail, detail.DetailID);
            return status;
        }

        public bool DeleteDetail(int id)
        {
            bool status = detailService.Delete(id);
            return status;
        }
    }
}
