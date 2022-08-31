using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using simaMovil.Models;
using simaMovil.Repository;
using simaMovil.Services;
using Xamarin.Essentials;

namespace simaMovil.Data
{
    internal class TokenController :  ITokenController
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public TokenController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;


        public async Task<bool> GetTokenAsync(string _uri, User _user)
        {
            try
            {                
                string jsonUserInfo = JsonSerializer.Serialize(_user);

                var content = new StringContent(jsonUserInfo, Encoding.UTF8, Constants.ContentType);
                content.Headers.ContentType = new MediaTypeHeaderValue(Constants.ContentType);

                var request = new HttpRequestMessage(HttpMethod.Post, _uri + "token");
                request.Content = content;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(Constants.ContentType);

#if DEBUG

                //HttpClientHandler insecureHandler = InsecureHandler.GetInsecureHandler();
                //HttpClient client = new HttpClient(insecureHandler);

#else
HttpClient client = new HttpClient();
#endif
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzaW1hU2VydmljZUFjY2Vzc1Rva2VuIiwianRpIjoiZTQ5NWMwNjUtMDQyMy00Y2Y3LWFiZDUtZTdiZDM1MWI5ODlkIiwiaWF0IjoiMTgvMDgvMjAyMiAwNjo0ODo0OSBwLiBtLiIsIkNvZF91c3VhcmlvIjoiMSIsIlVzdWFyaW8iOiJkdmF6cXVleiIsIlBlcmZpbCI6IjEiLCJleHAiOjE2NjA5MzQ5MjksImlzcyI6InNpbWFBdXRoZW50aWNhdGlvblNlcnZlciIsImF1ZCI6InNpbWFTZXJ2aWNlUG9zdG1hbkNsaWVudCJ9.0VB7zXF8P2801nEi7p58pHX5vr3RJmIG2p74x_qhZFU");

                var client = _httpClientFactory.CreateClient("simaRestApi");

                HttpResponseMessage response = await client.PostAsync("token", content);

                if (response.IsSuccessStatusCode)
                {
                    string tokenText = await response.Content.ReadAsStringAsync();
                    
                    await SecureStorage.SetAsync("token", tokenText);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }

    }
}
