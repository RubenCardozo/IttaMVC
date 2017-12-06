using MVCNovembre2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNovembre2017.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View(ClientDAO.getAllClients());

        }


        public ActionResult Afficher(String id)
        {
            Client c= ClientDAO.GetClientById(id);
            return View(c);
        }


        public ActionResult Supprimer(String id)
        {
            ClientDAO.RemoveClient(id);
            return View();
        }


        [HttpGet]
        public ActionResult Ajouter()
        {
            return View(new Client());
        }

        [HttpPost]
        public ActionResult Ajouterback(String id, String nom, String prenom, DateTime dateNaissance)
        {
            Client c = new Client(id, nom, prenom, dateNaissance);
            ClientDAO.UpdateOrAddClient(c);
            return View("Index",ClientDAO.getAllClients());
        }


        [HttpPost]
        public ActionResult Ajouter(Client client) //,String prenom)
        {
            //client.Prenom = firstname;
            //client.Prenom = Request.Form["firstname"];
            //client.Prenom = Request.Form.GetValues("firstname")[0];
            //client.Prenom = Request.Form["prenom"];

            if (client.DateNaissance.HasValue
               && client.DateNaissance.Value.CompareTo(DateTime.Now) > 0)
            {
                ModelState.AddModelError("DateNaissence", "Trop fort!");
            }

            if (ModelState.IsValid)
            {
                ClientDAO.UpdateOrAddClient(client);
                return View("Index", ClientDAO.getAllClients());
            }
            return View(client);

        }

        [HttpGet]
        public ActionResult Editer(String id)
        {
            Client c= ClientDAO.GetClientById(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Editer(Client client)
        {
            ModelState.Remove("Id");

            if (client.DateNaissance.HasValue
                && client.DateNaissance.Value.CompareTo(DateTime.Now)>0)
            {
                ModelState.AddModelError("DateNaissence","Trop fort!");
            }

            if (ModelState.IsValid)
            {
                ClientDAO.UpdateOrAddClient(client);
                return View("Index", ClientDAO.getAllClients());
            }
            return View(client);
        }
    }
}
