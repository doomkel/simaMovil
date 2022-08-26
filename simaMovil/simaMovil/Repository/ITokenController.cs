using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using simaMovil.Models;

namespace simaMovil.Repository
{
    internal interface ITokenController
    {
        Task<Token> GetTokenAsync(string _uri, User _user);
    }
}
