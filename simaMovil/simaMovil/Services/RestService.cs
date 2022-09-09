using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using simaMovil.Models;
using Xamarin.Essentials;

namespace simaMovil.Services
{
    internal class RestService : IRestService
    {
        
        public async Task<IEnumerable<object>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> PostAsync(object item, string route)
        {
            string jsonUserInfo = JsonSerializer.Serialize(item);
                        
            var content = new StringContent(jsonUserInfo, Encoding.UTF8, Constants.ContentType);
            content.Headers.ContentType = new MediaTypeHeaderValue(Constants.ContentType);

            var request = new HttpRequestMessage(HttpMethod.Post, Constants.ApiUrl + route);
            request.Content = content;
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(Constants.ContentType);

#if DEBUG

            HttpClientHandler insecureHandler = InsecureHandler.GetInsecureHandler();
            HttpClient client = new HttpClient(insecureHandler);

#else
HttpClient client = new HttpClient();
#endif
            HttpResponseMessage response = await client.SendAsync(request);

            return response;
        }
    }
}
