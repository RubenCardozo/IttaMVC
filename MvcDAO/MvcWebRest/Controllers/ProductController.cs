using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcWebRest.Controllers
{
    public class ProductController : ApiController
    {

        NorthwindEntities entities = new NorthwindEntities(true);

        // GET api/values
        public IEnumerable<Product> Get()
        {
            return entities.Products.ToList();
        }

        // GET api/Product/5
        public Product Get(int id)
        {
            return entities.Products.FirstOrDefault(p => p.ProductID == id);
        }

        // GET api/Product/?name=Chai
        public Product Get(string name)
        {
            return entities.Products.FirstOrDefault(p =>String.Compare( p.ProductName, name,true)==0);
        }

        // POST(create) api/values
        public void Post([FromBody]Product value)
        {
            entities.Products.Attach(value);
            entities.Entry(value).State = System.Data.EntityState.Added;
            entities.SaveChanges();
        }

        // PUT(edit) api/values/5
        public void Put(int id, [FromBody]Product value)
        {
            entities.Products.Attach(value);
            entities.Entry(value).State = System.Data.EntityState.Modified;
            entities.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Product prod = entities.Products.FirstOrDefault(p => p.ProductID == id);
            entities.Products.Remove(prod);
            entities.SaveChanges();
        }

    }
}
