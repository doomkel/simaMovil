using System;
using System.Collections.Generic;
using System.Text;
using simaMovil.Services;
using simaMovil.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace simaMovil.ViewModels
{
    internal class LoginViewModel
    {
        private readonly IRestService _restService;
        public LoginViewModel(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<bool> CheckInformation(UserModel _user)
        {
            try
            {
                HttpResponseMessage reponse = await _restService.PostAsync(_user, "token");
                return reponse.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

        }

    }
}
