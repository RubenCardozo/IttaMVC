using MVCNovembre2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace MVCNovembre2017.Controllers
{
    public class StateController : Controller
    {

        public ActionResult Index(bool first = false)
        {
            ViewData["vda"] = ClientDAO.GetClientById("A");
            ViewBag.vdb = ClientDAO.GetClientById("B");

            HttpCookie gateau = new HttpCookie("gateau");

            if (@Request.Cookies["gateau"] != null)
            {
                gateau.Expires = DateTime.Now.AddMinutes(-1);
            }
            else
            {
                //gateau.Path = "/state";
                gateau.Path = "mille-feuille";
                gateau.Secure = false;//Coockie ne pourrais etre transmit 
                gateau.HttpOnly = true;
                gateau.Expires = DateTime.Now.AddMinutes(1);
            }

            Response.Cookies.Add(gateau);

            Session["cli"] = new Client("11", "dddd", "dd");

            if (Session.IsNewSession)
            //{
            //    Session["i"] = 1;
            //}else
                {
                    Session["i"] = ((int)(Session["i"] ?? 0)) + 1;
                }

            if ((int)(Session["i"] ?? 0) == 3)
            {
                Session.Abandon();
                Session.Clear();
            }

            //if (!first)
            //    return Redirect("/state/index2");

                
            return View();



        }
        public ActionResult Index2()
        {

            return View("Index");
        }
    }
}
