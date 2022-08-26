using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using simaMovil.Models;
using simaMovil.Repository;
using Xamarin.Essentials;

namespace simaMovil.Data
{
    internal class TokenController :  ITokenController
    {
        public async Task<Token> GetTokenAsync(string _uri, User _user)
        {
            try
            {
                //obtener token
                string jsonUserInfo = JsonSerializer.Serialize(_user);

                var connectionUrl = _uri;

                var content = new StringContent(jsonUserInfo, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, connectionUrl);
                request.Content = content;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

#if DEBUG
                                
                HttpClientHandler insecureHandler = InsecureHandler.GetInsecureHandler();
                HttpClient client = new HttpClient(insecureHandler);

#else
HttpClient client = new HttpClient();
#endif
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzaW1hU2VydmljZUFjY2Vzc1Rva2VuIiwianRpIjoiZTQ5NWMwNjUtMDQyMy00Y2Y3LWFiZDUtZTdiZDM1MWI5ODlkIiwiaWF0IjoiMTgvMDgvMjAyMiAwNjo0ODo0OSBwLiBtLiIsIkNvZF91c3VhcmlvIjoiMSIsIlVzdWFyaW8iOiJkdmF6cXVleiIsIlBlcmZpbCI6IjEiLCJleHAiOjE2NjA5MzQ5MjksImlzcyI6InNpbWFBdXRoZW50aWNhdGlvblNlcnZlciIsImF1ZCI6InNpbWFTZXJ2aWNlUG9zdG1hbkNsaWVudCJ9.0VB7zXF8P2801nEi7p58pHX5vr3RJmIG2p74x_qhZFU");

                HttpResponseMessage response = await client.SendAsync(request);
                string tokenText = await response.Content.ReadAsStringAsync();
                await SecureStorage.SetAsync("token", tokenText);

                Token token = new Token()
                {
                    TokenText = tokenText,
                    Type = "",
                    Expiration = DateTime.Now
                };

                return token;

            }
            catch 
            {
                return null;
            }
        }

    }
}
