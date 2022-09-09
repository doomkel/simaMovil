using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace simaMovil.Services
{
    internal interface IRestService
    {
        Task<IEnumerable<object>>  GetAllAsync();
        Task<object> GetAsync();
        Task<HttpResponseMessage> PostAsync(object item,string route);

    }
}
