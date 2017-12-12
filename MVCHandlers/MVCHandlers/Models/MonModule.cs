using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHandlers.Models
{
    public class MonModule : IHttpModule
    {
        public void Dispose()
        {
           
        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += application_BeginRequest;
            application.EndRequest += application_EndRequest;
        }

        void application_BeginRequest(object source, EventArgs e)
        {
            HttpApplication application =(HttpApplication) source;
            HttpContext context = application.Context;
            if (context.Request.QueryString["log"] !=null)
            {
                context.Response.Write("<h1>Logué par mon module</h1>");
            }
            
        }
         void application_EndRequest(object source, EventArgs e)
        {
            HttpApplication application =(HttpApplication) source;
            HttpContext context = application.Context;
            if (context.Request.QueryString["log"] !=null)
            {
                context.Response.Write("<h1>Logué à nouveau par mon module</h1>");
            }
            
        }
    }
}