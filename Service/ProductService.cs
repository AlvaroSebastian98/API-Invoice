using Infraestructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService
    {
        public List<Product> Get()
        {
            List<Product> Products = null;
            using (var context = new InvoiceContext())
            {

                Products = context.Products.ToList();

            }
            return Products;
        }

        //public List<Product> Get(Product Product)
        //{
        //    List<Product> Products = null;


        //    using (var context = new InvoiceContext())
        //    {

        //        Products = context.Products.
        //            Where(x => x.ProductName.Contains(Product.ProductName)
        //            && x.ProductAddress.Contains(Product.ProductAddress)).
        //            ToList();

        //    }

        //    return Products;
        //}

        public Product GetById(int ID)
        {
            Product Product = null;

            using (var context = new InvoiceContext())
            {
                Product = context.Products.Find(ID);
            }

            return Product;
        }

        public void Insert(Product Product)
        {
            using (var context = new InvoiceContext())
            {
                Product.Enable = true;
                Product.CreatedOn = DateTime.Today;
                Product.ModifiedOn = DateTime.Today;
                Product.CreatedBy = "Admin";
                context.Products.Add(Product);
                context.SaveChanges();
            }
        }

        public void Update(Product Product, int ID)
        {
            using (var context = new InvoiceContext())
            {
                var ProductNew = context.Products.Find(ID);
                ProductNew.ProductName = Product.ProductName == null ? ProductNew.ProductName : Product.ProductName;
                ProductNew.Prize = Product.Prize==0 ? ProductNew.Prize : Product.Prize;                
                context.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var context = new InvoiceContext())
            {
                var Product = context.Products.Find(ID);
                context.Products.Remove(Product);
                context.SaveChanges();
            }
        }


    }
}
