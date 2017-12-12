using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Routing;

namespace MVCHandlers.Models
{
    /// <summary>
    /// Summary description for HelloWorldHandler
    /// </summary>
    public class HelloWorldHandler : IHttpHandler
    {
        private RequestContext requestContext;

        #region IHttpHandler Member
        public HelloWorldHandler(RequestContext requestContext)
        {
            // TODO: Complete member initialization
            this.requestContext = requestContext;
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse resp = context.Response;
            HttpRequest req = context.Request;

            context.Response.ContentType = "text/html";
            resp.Write("<html>");
            resp.Write("<body>");

            String[] ts = req.Path.Split('/');
            resp.Write("<h1>Hello "+ ts[ts.Length-1] + "</h1>");
            resp.Write("<h1>Hello " + requestContext.RouteData.Values["resource"] + "</h1>");

            resp.Write("</body>");
            resp.Write("</html>");

        }
        #endregion
    }   



    public class HelloWorldRouteHandler : IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext  requestContext) 
            {
                return new HelloWorldHandler (requestContext);
            }
        }
       


}