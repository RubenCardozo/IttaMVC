using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCHandlers.Controllers;
using System.Web.Mvc;
using System.Web.Routing;


namespace UnitTestMVCHandler
{
    [TestClass]
    public class UnitTesttestController
    {
        HomeController home; 
        [TestInitialize]
        public void Initialisation()
        {
            home= new HomeController();
        
        }
        [TestCleanup]
        public void Shutdown()
        {
            home = null;

        }

        [TestMethod]
        public void TestHomeIndex()
        {
            HomeController home =new HomeController();
            //RedirectToRouteResult view = (RedirectToRouteResult)home.Index();

            //Assert.AreEqual(home.RouteData.Values["action"], "Index");

            //Assert.AreEqual(view.RouteValues["action"], "Index");

            ViewResult view = (ViewResult)home.Index();
            Assert.AreEqual(view.ViewName, "");
        }

        [TestMethod]
        public void TestHomeIndexException()
        {
            try
            {
                HomeController home = new HomeController();
                ViewResult view = (ViewResult)home.Index(1);
            }
            catch (Exception ex)
            {

                Assert.IsInstanceOfType(ex, typeof(Exception));
                return;
            }
            Assert.Fail("Pas d'exception");
            
        }

        [TestMethod]

        public void TestRouteHomeIndex() {

            var routes = new RouteCollection();
            MVCHandlers.RouteConfig.RegisterRoutes(routes);
            var context = new FakeHttpContextForRouting(requestUrl: "~/Home/Index/");
            RouteData routeData = routes.GetRouteData(context);

            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);

        }

        [TestMethod]

        public void TestRouteHomeIndexError()
        {

            var routes = new RouteCollection();
            MVCHandlers.RouteConfig.RegisterRoutes(routes);
            var context = new FakeHttpContextForRouting(requestUrl: "~/Home/Index/1");
            RouteData routeData = routes.GetRouteData(context);

            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual("1", routeData.Values["id"]);

        }
    }
}
