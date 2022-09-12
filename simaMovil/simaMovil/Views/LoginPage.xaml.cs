using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Acr.UserDialogs;
using simaMovil.Models;
using simaMovil.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace simaMovil.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
		{            
			InitializeComponent();
            Init();
            BindingContext = ActivatorUtilities.CreateInstance<LoginViewModel>(Startup.ServiceProvider);
        }

        void Init()
        {
            BackgroundColor = Constants.BackGroundColor;
            lblUser.TextColor = Constants.MainTextColor;
            lblPass.TextColor = Constants.MainTextColor;
            entUser.TextColor = Constants.SubTextColor;
            entPass.TextColor = Constants.SubTextColor;
            btnEntrar.TextColor = Color.White;
            entUser.BackgroundColor = Color.Black;
            entPass.BackgroundColor = Color.Black;
            btnEntrar.BackgroundColor = Constants.MainTextColor;
                                    
            LoginIcon.HeightRequest = 120;

            entUser.Focus();
        }

        //private async void BtnEntrar_Clicked(object sender, EventArgs e)
        //{            
        //    UserModel user = new UserModel(entUser.Text, entPass.Text);                 
            
        //    UserDialogs.Instance.ShowLoading(title: "Autenticando");
        //    var result = await ((LoginViewModel)BindingContext).CheckInformation(user);
        //    UserDialogs.Instance.HideLoading();
                        
        //    if (result == true)
        //    {
        //        await Shell.Current.GoToAsync("//main");

        //    }
        //    else
        //    {
        //        await DisplayAlert("Login", "Usuario o contraseña incorrecta", "Ok");
        //    }
        //}

             

        private void EntUser_Completed(object sender, EventArgs e)
        {
            entPass.Focus();
        }

        private void EntPass_Completed(object sender, EventArgs e)
        {
            btnEntrar.Focus();
        }

   
    }
}