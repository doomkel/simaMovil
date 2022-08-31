using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using simaMovil.Data;
using simaMovil.Models;
using Microsoft.Net.Http.Headers;

namespace simaMovil.Services
{
    internal class RestService
    {
        public static HttpClient client;
        public RestService()
        {
            var services = new ServiceCollection();
            services.AddHttpClient("simaRestApi", httpClient =>
            {
                httpClient.BaseAddress = new Uri(Constants.DefaultApiUrl);
                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            } );
            var serviceProvider = services.BuildServiceProvider();



            if (client == null)
            {

#if DEBUG

                HttpClientHandler insecureHandler = InsecureHandler.GetInsecureHandler();
                client = new HttpClient(insecureHandler);

                

#else
     client = new HttpClient();
#endif
            }
        }

    }
}
