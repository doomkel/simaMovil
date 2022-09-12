using System;
using System.Collections.Generic;
using System.Text;
using simaMovil.Services;
using simaMovil.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.Forms;

namespace simaMovil.ViewModels
{
    internal class LoginViewModel : UserModel
    {
        
        private readonly IRestService _restService;
        private readonly IMessageService _messageService;
        public LoginViewModel(IRestService restService, IMessageService messageService)
        {
            _restService = restService;
            _messageService = messageService;

            SaveCommand = new Command(async () => await CheckInformation()); 
        }

        public ICommand SaveCommand { get; set; }

        public async Task CheckInformation()
        {
            try
            {
                IsBusy = true;

                //TODO:ACR.SHOWDIALOGS https://social.msdn.microsoft.com/Forums/en-US/443f5ce9-14d3-48ab-a5fb-8a0d2c75563f/acr-user-dialogs-not-working-on-viewmodel?forum=xamarinforms

                HttpResponseMessage response = await _restService.PostAsync(this, "/token");
                
                if (response.IsSuccessStatusCode)
                {
                    string token = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(token);
                    await SecureStorage.SetAsync("tokenExpiration", token);
                    await Shell.Current.GoToAsync("//main");
                }
                else
                {
                    await _messageService.ShowAsync("Usuario o contraseña incorrecta");                    
                }



            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                
            }
            finally
            {
                IsBusy = false;
            }

        }

    }
}
