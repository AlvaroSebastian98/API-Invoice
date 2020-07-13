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
                           where c.Enable == true
                           select
                           new Product_Response_v1
                           {
                               ProductID = c.ProductID,
                               ProductName = c.ProductName,
                               Prize = c.Prize
                           }).ToList();

            return response;
        }

        public Product_Response_v1 Get(int id)
        {
            Product product = service.GetById(id);

            Product_Response_v1 productResponse = new Product_Response_v1
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Prize = product.Prize
            };

            return productResponse;
        }

        public int Post([FromBody] Product_Request_v1 request)
        {
            //Ingreso un objeto de tipo Product_Request_v1
            //TRANSFORMAR
            //Necesito un objeto de tipo Product
            Product product = new Product();            
            product.ProductName = request.ProductName;
            product.Prize = request.Prize;
            product.Stock = request.Stock;

            int id = service.Insert(product);

            return id;
        }

        public bool Update([FromBody] Product_Request_v4 request)
        {
            bool status;
            try
            {
                Product product = new Product();
                product.ProductID = request.ProductID;
                product.ProductName = request.ProductName;
                product.Prize = request.Prize;
                product.Stock = request.Stock;

                service.Update(product, product.ProductID);
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
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

        public bool Delete(int id)
        {
            bool response = service.Delete(id);
            return response;
        }
    }
}
