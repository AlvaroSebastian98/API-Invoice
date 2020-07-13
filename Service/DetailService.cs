using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DetailService
    {
        public List<Detail> Get()
        {
            List<Detail> Details = null;
            using (var context = new InvoiceContext())
            {

                Details = context.Details.ToList();

            }
            return Details;
        }


        public Detail GetById(int ID)
        {
            Detail Detail = null;

            using (var context = new InvoiceContext())
            {
                //Detail = context.Details.Where((detail) => detail.DetailID == ID && detail.State == true).First();
                Detail = context.Details.Find(ID);
            }

            return Detail;
        }

        public async Task<bool> Insert(Detail Detail)
        {
            bool status;

            try
            {
                using (var context = new InvoiceContext())
                {
                    var Product = context.Products.Find(Detail.ProductID);

                    Detail.Prize = Product.Prize;
                    Detail.State = true;
                                 
                    context.Details.Add(Detail);
                    await context.SaveChangesAsync();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }

        public async Task<bool> InsertwithInvoice(List<Detail> Details, int invoiceID)
        {
            bool status;

            try
            {
                using (var context = new InvoiceContext())
                {
                    foreach (var Detail in Details)
                    {
                        Detail.InvoiceID = invoiceID;
                        var Product = context.Products.Find(Detail.ProductID);

                        Detail.Prize = Product.Prize;
                        Detail.State = true;

                        context.Details.Add(Detail);
                    }

                    await context.SaveChangesAsync();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }

        public bool Update(Detail Detail, int ID)
        {
            bool status;
            try
            {
                using (var context = new InvoiceContext())
                {
                    var DetailNew = context.Details.Find(ID);
                    DetailNew.Quantity = Detail.Quantity == 0 ? DetailNew.Quantity : Detail.Quantity;
                    DetailNew.Prize = Detail.Prize == 0 ? DetailNew.Prize : Detail.Prize;
                    DetailNew.Description = Detail.Description ?? DetailNew.Description;
                    DetailNew.ProductID = Detail.ProductID == 0 ? DetailNew.ProductID : Detail.ProductID;
                    DetailNew.InvoiceID = Detail.InvoiceID == 0 ? DetailNew.InvoiceID : Detail.InvoiceID;

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

        public async Task<bool> DeleteWithInvoice(List<Detail> Details)
        {
            bool status;
            try
            {
                using (var context = new InvoiceContext())
                {
                    foreach (var detail in Details)
                    {
                        var Detail = context.Details.Find(detail.DetailID);
                        Detail.State = false;
                    }                    
                    await context.SaveChangesAsync();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }

        public async Task<bool> Delete(int ID)
        {
            bool status;
            try
            {
                using (var context = new InvoiceContext())
                {
                    var Detail = context.Details.Find(ID);
                    Detail.State = false;
                    await context.SaveChangesAsync();
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
                    var Detail = context.Details.Find(ID);
                    context.Details.Remove(Detail);
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
