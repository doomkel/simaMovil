using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Acr.UserDialogs;
using AutoMapper;
using simaMovil.Dtos;
using simaMovil.Models;
using simaMovil.Services;
using simaMovil.Repositories;


namespace simaMovil.ViewModels
{
    internal class SalesInfoViewModel : RepVtaMesModel
    {
        private List<RepVtaMesModel> _itemList;

        private readonly IRestService _restService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapperService;
        private readonly IUserRepository _userRepository;

        public SalesInfoViewModel(IRestService restService, IMessageService messageService, IMapper mapperService, IUserRepository userRepository)
        {
            _restService = restService;
            _messageService = messageService;
            _mapperService = mapperService;
            _userRepository = userRepository;


            using (UserDialogs.Instance.Loading("Obteniendo informacion"))
            {
               ReportList().Await(errorHandler);
            }          
            
        }
        private void errorHandler(Exception ex)
        {
            _messageService.ShowAsync(ex.Message);
        }

        public List<RepVtaMesModel> ItemList
        {
            get
            {
                return _itemList;
            }
            set
            {
                _itemList = value;
                RaisePropertyChanged(() => ItemList);
            }
        }

      

        private async Task ReportList()
        {
            try
            {
                IsBusy = true;

                TokenModel token = await _userRepository.GetToken();

                if (!token.isValid)
                {
                    //TODO: cerrar sesion
                }

                HttpResponseMessage response = await _restService.GetAllAsync(token.Token, "/repvtames");
                string result = response.Content.ReadAsStringAsync().Result;

                var repVtaMesItems = JsonSerializer.Deserialize<IEnumerable<RepVtaMesDto>>(result);

                ItemList = _mapperService.Map<List<RepVtaMesModel>>(repVtaMesItems); 
                
            }
            catch (Exception ex)
            {
                await _messageService.ShowAsync("Error: " + ex.Message);                
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    
}
