using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace simaMovil.Models
{
    internal  class TokenModel
    {
        public  string Token { get; set; }                   
        public  DateTime ExpirationDate { get; set; }        
        public  bool isValid => (ExpirationDate >= DateTime.Now);
        
    }
}
