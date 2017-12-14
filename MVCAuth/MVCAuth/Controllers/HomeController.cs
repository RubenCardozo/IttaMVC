using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Security;

namespace MVCAuth.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [AllowAnonymous]

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Users ="titi,tutu")]
        [Authorize (Roles="admins")]
        public ActionResult Verboten()
        {
            dynamic profile = ProfileBase.Create(Membership.);
            Profile.langue = "hongrois";
            Profile.dernierevisite = DateTime.Now;
            return View();
        }
    }
}
