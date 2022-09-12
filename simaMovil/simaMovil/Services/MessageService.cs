using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace simaMovil.Services
{
    internal class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("simaMovil", message, "Ok");
        }
    }
}
