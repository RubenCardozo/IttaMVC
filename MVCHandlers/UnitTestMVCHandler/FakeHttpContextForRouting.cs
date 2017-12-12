using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace UnitTestMVCHandler
{
    class FakeHttpContextForRouting : HttpContextBase
    {
        FakeHttpRequestForRouting _request;
        FakeHttpResponseForRouting _response;

        public FakeHttpContextForRouting(string appPath = "/", string requestUrl = "~/")
        {
            _request = new FakeHttpRequestForRouting(appPath, requestUrl);
            _response = new FakeHttpResponseForRouting();
        }

        public override HttpRequestBase Request
        {
            get { return _request; }
        }
        public override HttpResponseBase Response
        {
            get { return _response; }
        }
    }
}
