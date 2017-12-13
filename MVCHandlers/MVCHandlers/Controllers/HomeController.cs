using MVCHandlers.ServiceIttaRef;
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

        public ActionResult Autre()
        {
            Client pierre = null;
            using (ServiceIttaClient proxy = new ServiceIttaClient())
            {
                pierre = proxy.getPartenaire(new Client() { Nom = "pier" });
            }

            return View(pierre);
        }

        public ActionResult useWS()
        {
            Client toto = null;
            using (ServiceIttaClient proxy = new ServiceIttaClient())
            {
               toto = proxy.getPartenaire(new Client() { Nom = "gertrud" });
            }
            
            return View(toto);
        }
    }
}
