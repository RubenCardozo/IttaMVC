using MVCAuth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCAuth.Controllers
{
    public class SecuriteController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            
            return View(new LoginUser());
        }


        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser loginuser, string returnUrl)
        {

            if (ModelState.IsValid && Membership.ValidateUser(loginuser.Username, loginuser.Password))
            {
                FormsAuthentication.SetAuthCookie(loginuser.Username, false);
                return Redirect(returnUrl);
            }
            ModelState.AddModelError("","username ou mot de passe invalide");
            return View(loginuser);
        }

    }
}
