using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace simaMovil.Services
{
    internal interface IMessageService
    {
        Task ShowAsync(string message);
    }
}
