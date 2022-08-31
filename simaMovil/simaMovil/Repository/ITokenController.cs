using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using simaMovil.Models;

namespace simaMovil.Repository
{
    internal interface ITokenController
    {
        Task<bool> GetTokenAsync(string _uri, User _user);
    }
}
