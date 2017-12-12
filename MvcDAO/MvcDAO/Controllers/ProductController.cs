using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;


namespace MvcDAO.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client = new HttpClient();

        public ProductController()
        {
            client.BaseAddress= new Uri ("http://localhost:48847/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: /api/product/

        public ActionResult Index()
        {
            List<Product> products = null;
            HttpResponseMessage reponse = client.GetAsync("api/product").GetAwaiter().GetResult();

            if (reponse.IsSuccessStatusCode)
            {
                products = reponse.Content.ReadAsAsync<List<Product>>().GetAwaiter().GetResult();
            }

            return View(products);
        }

        [HttpGet]
        // GET: /api/product/id
        public ActionResult Edit(int id)
        {

            Product product = null;
            
            HttpResponseMessage reponse = client.GetAsync("api/product/"+ id).Result;

            if (reponse.IsSuccessStatusCode)
            {
                product = reponse.Content.ReadAsAsync<Product>().Result;
            }

            return View(product);
        }

        [HttpPut]
        // PUT: /api/product/id
        public ActionResult Edit(int id, Product prod)
        {
            Product product = null;

            HttpResponseMessage reponse = client.PutAsJsonAsync("api/product/"+ id, prod).GetAwaiter().GetResult();

            if (reponse.IsSuccessStatusCode)
            {
                product = reponse.Content.ReadAsAsync <Product>().GetAwaiter().GetResult();
            }
            return Redirect("api/product");
        }

        // DELETE: /api/product/id
        public ActionResult Delete(int id)
        {
            Product product = null;

            HttpResponseMessage reponse = client.DeleteAsync("api/product/" + id).GetAwaiter().GetResult();

            if (reponse.IsSuccessStatusCode)
            {
                product = reponse.Content.ReadAsAsync<Product>().GetAwaiter().GetResult();
            }

            return View(product);
            
        }

        //// DELETE: /api/product/id
        //public ActionResult Delete(int id)
        //{
        //     List<Product> products = null;

        //    HttpResponseMessage reponse = client.DeleteAsync("api/product/"+id).GetAwaiter().GetResult();

        //    if (reponse.IsSuccessStatusCode)
        //    {
        //        products = reponse.Content.ReadAsAsync<List<Product>>().GetAwaiter().GetResult();
        //    }

        //    return View(products);
            
        //}



        //// POST: /api/product/create
        //public ActionResult Create()
        //{
           
        //    return View(new Product());
        //}

        // POST: /api/product/id
        public ActionResult Create(Product prod)
        {
            Product product = null;

            HttpResponseMessage reponse = client.PostAsJsonAsync("api/product/" + prod, prod).GetAwaiter().GetResult();

            if (reponse.IsSuccessStatusCode)
            {
                product = reponse.Content.ReadAsAsync<Product>().GetAwaiter().GetResult();
            }
           
            return Redirect("/api/product");
        }

       
        public ActionResult Details(int id)
        {
           
            return View();
        }

    }
}
