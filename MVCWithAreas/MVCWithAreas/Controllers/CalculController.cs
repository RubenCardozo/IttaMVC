using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVCWithAreas.Controllers
{
    public class CalculController : Controller
    {
        
        //[OutputCache(Duration=60, VaryByParam="none", Location=OutputCacheLocation.Client, NoStore=true, VaryByCustom="browser")]
        [OutputCache(CacheProfile="cachecalcul")]
        public ActionResult Ajouter(double v1, double v2)
        {
            ViewBag.heure = DateTime.Now.Second;
            //if (MemoryCache.Default.Get("addition")==null)
            //{
            //    MemoryCache.Default.Add("addition", v1 + v2, DateTime.Now.AddMinutes(1));
            //}
            var r= MemoryCache.Default.AddOrGetExisting("addition", v1 + v2, DateTime.Now.AddMinutes(1));
            return View("Resultat", MemoryCache.Default.Get("addition"));
        }


        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Multiplier(double v1, double v2)
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            ViewBag.heure = DateTime.Now.Second;
            return View("Resultat", v1 * v2);
        }

        public ActionResult FrontPage()
        {
            // return Redirect("~/") ;
            // return RedirectToAction("Index", "Home");
            // return RedirectToAction("Index", "Home", new {id=15, maman="love"});
            // return RedirectToRoute(new {controller="Home", action= "Index" });
            return RedirectToRoute("Default", new {controller="Home" });
            
        }

    }
}
