using MvcDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDAO.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           
           //Personne p = new Personne()
           //{
           //Nom= "Andrea",
           //Prenom="Mora",
           //Salaire= 4000,
           //DateNaissance= null
           //};
            //return View(new PersonneDAO().getPersonnes());
            return View(PersonneDaoDisco.getPersonnes());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //return View(new PersonneDAO().getPersonneById(id));
            return View(PersonneDaoDisco.getPersonneById(id));
        }

        [HttpPost]
        public ActionResult Edit(Personne p)
        {
            //new PersonneDAO().addOrUpdatePersonne(p);
            PersonneDaoDisco.addOrUpdatePersonne(p);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //return View(new PersonneDAO().getPersonneById(id));
            return View(PersonneDaoDisco.getPersonneById(id));
        }

        [HttpPost]
        public ActionResult Delete(Personne p)
        {
            //new PersonneDAO().deletePersonne(p.Id);
            PersonneDaoDisco.deletePersonne(p.Id);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Personne());
        }
        [HttpPost]
        public ActionResult Create(Personne p)
        {
            //new PersonneDAO().addOrUpdatePersonne(p);
            PersonneDaoDisco.addOrUpdatePersonne(p);
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            //return View(new PersonneDAO().getPersonneById(id));
            return View(PersonneDaoDisco.getPersonneById(id));
        }
        
    }
}
