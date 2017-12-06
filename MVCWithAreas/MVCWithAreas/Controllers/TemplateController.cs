using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithAreas.Controllers
{
    public class TemplateController : Controller
    {
        //
        // GET: /Template/

        protected override void OnException(ExceptionContext filterContext)
        {
            Debug.WriteLine( "Exception:" + filterContext.Exception.Message + "action= " +
            filterContext.RouteData.Values["action"] + ", controller= " +
            filterContext.RouteData.Values["controller"]);
        }


    }
}
