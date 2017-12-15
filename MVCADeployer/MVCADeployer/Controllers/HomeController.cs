using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using System.Web.Routing;


namespace MVCADeployer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            if (Request.QueryString["langue"] != null)
            {
                HttpCookie cl = new HttpCookie("langue", Request.QueryString["langue"]);
                cl.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cl);
                Thread.CurrentThread.CurrentUICulture =
                Thread.CurrentThread.CurrentCulture
                = new CultureInfo(Request.QueryString["langue"]);
            }
            else
            if (Request.Cookies["langue"] != null)
            {
                Thread.CurrentThread.CurrentUICulture =
                Thread.CurrentThread.CurrentCulture
                = new CultureInfo(Request.Cookies["langue"].Value);
            }

            return base.BeginExecuteCore(callback, state);
        }

        public ActionResult Index(string lang=null)
        {
            if (lang != null)
            {
                HttpCookie cl = new HttpCookie("langue",lang);
                cl.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cl);
                Thread.CurrentThread.CurrentUICulture =
                Thread.CurrentThread.CurrentCulture 
                = new CultureInfo(lang);
            }
          
            return View();
        }

    }
}
