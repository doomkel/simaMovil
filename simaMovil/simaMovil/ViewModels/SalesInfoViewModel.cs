using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using simaMovil.Models;
using simaMovil.Services;

namespace simaMovil.ViewModels
{
    internal class SalesInfoViewModel : RepVtaMesModel
    {
        private readonly IRestService _restService;
        private readonly IMessageService _messageService;

        public SalesInfoViewModel(IRestService restService, IMessageService messageService)
        {
            _restService = restService;
            _messageService = messageService;

            using (UserDialogs.Instance.Loading("Obteniendo informacion"))
            {
                //await Report();
            }
        }

        private async Task Report()
        {
            try
            {

            }
            catch (Exception ex)
            {

                await _messageService.ShowAsync("Error: " + ex.Message);
            }
        }
    }
}
