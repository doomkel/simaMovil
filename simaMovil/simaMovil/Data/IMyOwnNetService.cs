using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace simaMovil.Data
{
    public  interface IMyOwnNetService
    {
        HttpClientHandler GetHttpClientHandler();
    }
}
