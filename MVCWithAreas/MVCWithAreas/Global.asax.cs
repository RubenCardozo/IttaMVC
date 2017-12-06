using MVCWithAreas.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCWithAreas
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

#if ! DEBUG 
            BundleTable.EnableOptimizations = true;
#endif
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Debug.WriteLine(exception.Message);
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            

           if (exception is HttpException)
           {
               int code = ((HttpException)exception).GetHttpCode();
               if (code == 404)
               {
                   Response.Redirect("~/Content/Error404.html");
               }
           }
           else
           {
               RouteValueDictionary values = Request.RequestContext.RouteData.Values;
               values.Clear();
               values.Add("controller", "Error");
               values.Add("action", "cinqcent");
               values.Add("exception",exception);
               ((IController)new Controllers.ErrorController()).Execute(Request.RequestContext);
           }
           Server.ClearError();
        }
    }
}