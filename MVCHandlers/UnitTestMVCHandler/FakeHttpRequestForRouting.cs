using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitTestMVCHandler
{
    class FakeHttpRequestForRouting : HttpRequestBase
    {
        string _appPath;
        string _requestUrl;
        public FakeHttpRequestForRouting(string appPath, string requestUrl)
        {
            _appPath = appPath;
            _requestUrl = requestUrl;
        }
        public override string ApplicationPath
        {
            get { return _appPath; }
        }
        public override string AppRelativeCurrentExecutionFilePath
        {
            get { return _requestUrl; }
        }
        public override string PathInfo
        {
            get { return ""; }
        }
        public override NameValueCollection ServerVariables
        {
            get { return new NameValueCollection(); }
        }
    }
}
