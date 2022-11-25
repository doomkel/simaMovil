using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace simaMovil.Services
{
    public static class TaskExtensions
    {
        public static async void Await(this Task task, Action<Exception> error)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                error?.Invoke(ex);
                
            }
            
        }
    }
}
