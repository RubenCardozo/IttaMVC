using MvcDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDAO.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        NorthwindEntities entities = new NorthwindEntities();

        public ActionResult Index()
        {
           
           
            //return View(new PersonneDAO().getPersonnes());
            //return View(PersonneDaoDisco.getPersonnes());
           
            return View(entities.Personnes);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //return View(new PersonneDAO().getPersonneById(id));
            //return View(PersonneDaoDisco.getPersonneById(id));
            Personne pers = entities.Personnes.First(p => p.Id == id);
            return View(pers);
        }

        [HttpPost]
        public ActionResult Edit(Personne p)
        {
            //*******************Version-1*************************
            //new PersonneDAO().addOrUpdatePersonne(p);
            //PersonneDaoDisco.addOrUpdatePersonne(p);
            //Personne pers= entities.Personnes.First(pe => pe.Id == p.Id );
            //pers.Nom = p.Nom;....ou bien

            //*******************Version-2*************************
            //entities.Entry(pers).CurrentValues.SetValues(p);
            //entities.SaveChanges();.... ou bien

            //*******************Version-3*************************
            entities.Personnes.Attach(p);
            entities.Entry(p).State=EntityState.Modified;
            entities.SaveChanges();
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //return View(new PersonneDAO().getPersonneById(id));
            //return View(PersonneDaoDisco.getPersonneById(id));
             return View(entities.Personnes.First(pe => pe.Id == id)); 
        }

        [HttpPost]
        public ActionResult Delete(Personne p)
        {
            //new PersonneDAO().deletePersonne(p.Id);
            //PersonneDaoDisco.deletePersonne(p.Id);
            entities.Personnes.Attach(p);
            entities.Entry(p).State = EntityState.Deleted;
            entities.SaveChanges();
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
            //PersonneDaoDisco.addOrUpdatePersonne(p);
            entities.Personnes.Add(p);
            entities.SaveChanges();
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            //return View(new PersonneDAO().getPersonneById(id));
            //return View(PersonneDaoDisco.getPersonneById(id));
            return View(entities.Personnes.First(pe => pe.Id == id));
        }
        
    }
}
