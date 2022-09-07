using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace simaMovil.Services
{
    internal interface IRestService<T>
    {
        Task<IEnumerable<T>>  GetAllAsync();
        Task<T> GetAsync();
        Task<HttpResponseMessage> PostAsync(T item,string route);

    }
}
