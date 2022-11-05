using simaMovil.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Xamarin.Essentials;
using System.Linq;


namespace simaMovil.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public async Task<TokenModel> GetToken()
        {
            var token = await SecureStorage.GetAsync("token");
                        
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
            var tokenTicks = long.Parse(tokenExp);
            var tokenDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;                       

            TokenModel tokenModel = new TokenModel()
            {
                Token = token,
                ExpirationDate = tokenDate

            };

            return tokenModel;

        }

        public async Task SetToken(string token)
        {
            await SecureStorage.SetAsync("token", token);
        }
    }
}
