using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHandlers.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int id = 0)
        {
           
            if (1==id)
            {
                throw new Exception("Pourrite"); 
            }
            
            return View();
        }

        public ActionResult About()
        {            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page";
            return View();
        }
    }
}
