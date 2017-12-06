using MVCWithAreas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithAreas.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /admin/Default1/

        public ActionResult Index()
        {
            //Client c;
            return View();
        }

    }
}
