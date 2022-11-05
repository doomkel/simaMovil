using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using simaMovil.Models;


namespace simaMovil.Services
{
    internal interface IRestService
    {
        Task<HttpResponseMessage> GetAllAsync(string token, string route);
        Task<HttpResponseMessage> GetAsync(string token, string route);
        Task<HttpResponseMessage> PostAsync(object item,string route);

    }
}
