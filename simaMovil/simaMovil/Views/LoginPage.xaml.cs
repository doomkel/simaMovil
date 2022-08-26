﻿using System;
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
using simaMovil.Data;


namespace simaMovil.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            
			InitializeComponent ();
            Init();
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


            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = 120;

            entUser.Focus();
        }

        private async void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            User user = new User(entUser.Text, entPass.Text);


            UserDialogs.Instance.ShowLoading(title: "Autenticando");
            var result = await CheckInformation(user);
            UserDialogs.Instance.HideLoading();
                        
            if (result == true)
            {
                await DisplayAlert("Login", "OK", "Ok");
                
            }
            else
            {
                await DisplayAlert("Login", "Usuario o contraseña incorrecta", "Ok");
            }
        }


        public async Task<bool> CheckInformation(User _user)
        {
            try
            {
                TokenController tokenController = new TokenController();
                User user = new User
                {
                    Usuario = entUser.Text,
                    Clave = entPass.Text
                };

                Token token = await tokenController.GetTokenAsync(Constants.ApiUrl, user);


                if (token == null)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

        }

        private void EntUser_Completed(object sender, EventArgs e)
        {
            entPass.Focus();
        }

        private void EntPass_Completed(object sender, EventArgs e)
        {
            btnEntrar.Focus();
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}