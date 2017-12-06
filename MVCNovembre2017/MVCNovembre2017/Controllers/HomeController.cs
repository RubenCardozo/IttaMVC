using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNovembre2017.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Index_back()
        {
            return View();
        }

        public String Lapins() 
        {
            return @"{
                    'nom': 'Bugs',
                    'prenom':'Bunny',
                    'datenaissance': '1944-14-70'
                   }".Replace("'","\"");
        }
    }
}
