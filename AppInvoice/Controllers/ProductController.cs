using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AppInvoice.Models;

namespace AppInvoice.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<Product> product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44330/api/");
                var responseTask = client.GetAsync("product/get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<Product>>();
                    readJob.Wait();
                    product = readJob.Result;
                }
                else
                {
                    product = Enumerable.Empty<Product>();
                    ModelState.AddModelError(string.Empty, "Server error");
                }
            }
            return View(product);
        }
    }
}