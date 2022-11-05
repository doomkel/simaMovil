using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AutoMapper;
using simaMovil.Services;
using simaMovil.Models;
using simaMovil.Dtos;
using simaMovil.Repositories;
using Acr.UserDialogs;

namespace simaMovil.ViewModels
{
    internal class LoginViewModel : UserModel
    {
        
        private readonly IRestService _restService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapperService;
        private readonly IUserRepository _userRepository;
        public LoginViewModel(IRestService restService, IMessageService messageService, IMapper mapperService, IUserRepository userRepository)
        {
            _restService = restService;
            _messageService = messageService;
            _mapperService = mapperService;
            _userRepository = userRepository;

            SaveCommand = new Command(async () =>
            {
                using (UserDialogs.Instance.Loading("Autenticando"))
                {
                    await Login();
                }                               
            });
        }

        public ICommand SaveCommand { get; set; }

        public async Task Login()
        {
            try
            {
                IsBusy = true;                               
                
                HttpResponseMessage response = await _restService.PostAsync(_mapperService.Map<UserDto>(this), "/token");
                
                if (response.IsSuccessStatusCode)
                {
                    string token = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(token);
                    await _userRepository.SetToken(token);
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
