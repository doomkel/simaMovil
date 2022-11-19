using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using simaMovil.Models;
using simaMovil.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace simaMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalesInfoPage : ContentPage
    {
        public SalesInfoPage()
        {
            InitializeComponent();
            BindingContext = ActivatorUtilities.CreateInstance<SalesInfoViewModel>(Startup.ServiceProvider);
        }
    }
}