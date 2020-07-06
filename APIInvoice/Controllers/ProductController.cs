using APIInvoice.Models.Request;
using APIInvoice.Models.Response;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIInvoice.Controllers
{
    public class ProductController : ApiController
    {
        private ProductService service = new ProductService();

        public List<Product_Response_v1> Get()
        {
            //Mapper
            //Transforma un objeto de un tipo (Product) a otro tipo (ProductResponse)
            var response = (from c in service.Get()
                           select
                           new Product_Response_v1
                           {
                               ProductID = c.ProductID,
                               ProductName = c.ProductName,
                               Prize = c.Prize
                           }).ToList();

            return response;
        }

        public Product Get(int id)
        {
            return service.GetById(id);
        }

        public void Post([FromBody] Product_Request_v1 request)
        {
            //Ingreso un objeto de tipo Product_Request_v1
            //TRANSFORMAR
            //Necesito un objeto de tipo Product
            Product product = new Product();            
            product.ProductName = request.ProductName;
            product.Prize = request.Prize;
            product.Stock = request.Stock;            
            service.Insert(product); 
        }
        public void UpdatePrize([FromBody] Product_Request_v2 request)
        {
            
            Product product = new Product();
            product.ProductID = request.ProductID;
            product.Prize = request.Prize;                        
            service.Update(product,product.ProductID);
        }
        public void UpdateName([FromBody] Product_Request_v3 request)
        {

            Product product = new Product();
            product.ProductID = request.ProductID;
            product.ProductName = request.ProductName;
            service.Update(product, product.ProductID);
        }
    }
}
