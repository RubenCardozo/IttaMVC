using MVCNov2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNov2017.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        public ActionResult Afficher(String id) 
        {
            Client c = new Client(nom: "Dupont",prenom: "Alain", id: id);
            return View(c);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
