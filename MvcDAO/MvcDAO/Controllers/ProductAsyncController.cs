using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace MvcDAO.Controllers
{
    public class ProductAController : AsyncController
    {

        HttpClient client = new HttpClient();

        public ProductAController()
        {
            client.BaseAddress = new Uri("http://localhost:48847/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // producta/index
        public void IndexAsync()
        {

            HttpResponseMessage reponse = client.GetAsync("api/product").Result;
            if (reponse.IsSuccessStatusCode)
            {
                AsyncManager.OutstandingOperations.Increment();
                Task<List<Product>> tlp = reponse.Content.ReadAsAsync<List<Product>>();
                AsyncManager.Parameters["products"] = tlp.Result;
                AsyncManager.OutstandingOperations.Decrement();
            }
        }
        public ActionResult IndexCompleted(List<Product> products)
        {
            return View(products);
        }

        //// GET: ProductAsync/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ProductAsync/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ProductAsync/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ProductAsync/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ProductAsync/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ProductAsync/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ProductAsync/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}