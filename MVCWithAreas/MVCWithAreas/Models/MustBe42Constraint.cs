using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVCWithAreas.Models
{
    public class MustBe42Constraint:IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName,RouteValueDictionary values, RouteDirection routeDirection)
        {

            if(!httpContext.Request.Browser.IsMobileDevice && values.ContainsKey("v1") && values.ContainsKey("v2"))
            {
                double d1 = double.Parse((String)values["v1"]);
                double d2 = double.Parse((String)values["v2"]);
                return(d1 * d2 == 42 || d1+d2 == 42 || d1-d2 == 42 || d1/d2 == 42);
            }
            return false;
        }
    }
}