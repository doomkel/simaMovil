using System;
using System.Collections.Generic;
using System.Text;
using simaMovil.Services;
using simaMovil.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Xamarin.Essentials;

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
                HttpResponseMessage response = await _restService.PostAsync(_user, "/token");
                
                if (response.IsSuccessStatusCode)
                {
                    string token = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(token);
                    await SecureStorage.SetAsync("tokenExpiration", token);
                    return true;
                }
                else
                {
                    return false;
                }

                

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

        }

    }
}
