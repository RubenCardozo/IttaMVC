using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithAreas.Controllers
{
    public class ErrorController : TemplateController
    {
        //
        // GET: /Error/

        public ActionResult CinqCent(Exception exception)
        {

            return View(exception);
        }

    }
}
