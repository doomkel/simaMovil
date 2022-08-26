using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using simaMovil.Data;
using simaMovil.Models;

namespace simaMovil.Services
{
    internal class RestService
    {
        readonly HttpClient client;
        public RestService()
        {

#if DEBUG

            HttpClientHandler insecureHandler = InsecureHandler.GetInsecureHandler();
            client = new HttpClient(insecureHandler);

#else
HttpClient client = new HttpClient();
#endif
        }

    }
}
