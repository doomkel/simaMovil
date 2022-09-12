using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using simaMovil.Views;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using simaMovil.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace simaMovil
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public App()
        {
            InitializeComponent();
            Startup.Init();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts                      
            
        }
        
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
                      

    }
}
