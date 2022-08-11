using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using simaMovil.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using simaMovil.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyOwnNetService))]
namespace simaMovil.Droid.Data
{    
    
    internal class MyOwnNetService : IMyOwnNetService
    {
        public HttpClientHandler GetHttpClientHandler()
        {
            return new Xamarin.Android.Net.AndroidClientHandler();
        }
    }
}