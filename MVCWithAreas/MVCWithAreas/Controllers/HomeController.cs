using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCWithAreas.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Outer()
        {
            ViewBag.sac = "le sac de la vue";
            Random r = new Random();
            return View(r.NextDouble());
        }

        //[ChildActionOnly]
        public ActionResult Inner()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Random r = new Random();
            return PartialView(r.NextDouble());
        }

        public ActionResult Templated()
        {
            return View();
        }

        //Filtre d'erreur
        [HandleError(View="CustomError", ExceptionType = typeof (DivideByZeroException))]
        public ActionResult Pourrite()
        {
            
            return View();
        }
       

    }
}
