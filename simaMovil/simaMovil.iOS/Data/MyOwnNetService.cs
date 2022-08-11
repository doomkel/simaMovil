using Foundation;
using simaMovil.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using UIKit;

namespace simaMovil.iOS.Data
{
    internal class MyOwnNetService : IMyOwnNetService
    {
        public HttpClientHandler GetHttpClientHandler()
        {
            return new HttpClientHandler();
        }
    }
}