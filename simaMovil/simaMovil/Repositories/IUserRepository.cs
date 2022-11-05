using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using simaMovil.Models;

namespace simaMovil.Repositories
{
    internal interface IUserRepository
    {
        Task<TokenModel> GetToken();

        Task SetToken(string token);
        
    }
}
