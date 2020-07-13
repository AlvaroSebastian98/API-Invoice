using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AppInvoice.Models;
using AppInvoice.Models.Request;

namespace AppInvoice.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            //IEnumerable<Invoice> invoice = null;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:44330/api/");
            //    var responseTask = client.GetAsync("Invoice/GetAllInvoices");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readJob = result.Content.ReadAsAsync<IList<Invoice>>();
            //        readJob.Wait();
            //        invoice = readJob.Result;
            //    }
            //    else
            //    {
            //        invoice = Enumerable.Empty<Invoice>();
            //        ModelState.AddModelError(string.Empty, "Server error");
            //    }
            //}
            //return View(invoice);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InvoiceRequest invoice)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44330/api/");
                var postJob = client.PostAsJsonAsync<InvoiceRequest>("Invoice/InsertInvoice", invoice);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Server error");
            return View(invoice);
        }
    }
}