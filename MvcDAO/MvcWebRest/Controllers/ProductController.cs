using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcWebRest.Controllers
{
    public class ProductController : ApiController
    {

        NorthwindEntities entities = new NorthwindEntities(true);

        // GET api/Product
        public IEnumerable<Product> Get(String orderby= null, string dir ="ASC")
        {
            if (orderby == null)
            {
                return entities.Products.ToList();
            }
            else 
            {
                ObjectContext oc = new ObjectContext("");
                //return entities.Products.OrderBy(p => p.ProductName).ToList();
                string sql = "select value Product from entities.Products as Product" +
                   "orderby Product." + orderby + "" + dir;
                ObjectQuery<List<Product>> query = new ObjectQuery<List<Product>>(sql, null);
                ObjectResult<List<Product>> r= query.Execute(MergeOption.NoTracking);
                return r;
               
            }
            
        }

        // GET api/Product/5?include=Category
        public Product Get(int id, string include=null)
        {
            if (include==null)
            {
                return entities.Products.FirstOrDefault(p => p.ProductID == id);
            }
            else
            {
                return entities.Products.Include(include).FirstOrDefault(p => p.ProductID == id);
               
            }
            
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
