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

            

            var result = await CheckInformation(user);

            if (result == true)
            {
                await DisplayAlert("Login", "Login Success", "Ok");
                //App.UserDatabase.SaveUser(user);
            }
            else
            {
                await DisplayAlert("Login", "Login Not Correct", "Ok");
            }
        }


        public async Task<bool> CheckInformation(User _user)
        {
            try
            {
                //obtener token
                string jsonUserInfo = JsonSerializer.Serialize(_user);

                var connectionUrl = "https://10.0.2.2:44392/api/token";

                var content = new StringContent(jsonUserInfo, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, connectionUrl);
                request.Content = content;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

#if DEBUG
                HttpClientHandler insecureHandler = GetInsecureHandler();
                HttpClient client = new HttpClient(insecureHandler);
                
#else
HttpClient client = new HttpClient();
#endif
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzaW1hU2VydmljZUFjY2Vzc1Rva2VuIiwianRpIjoiZTQ5NWMwNjUtMDQyMy00Y2Y3LWFiZDUtZTdiZDM1MWI5ODlkIiwiaWF0IjoiMTgvMDgvMjAyMiAwNjo0ODo0OSBwLiBtLiIsIkNvZF91c3VhcmlvIjoiMSIsIlVzdWFyaW8iOiJkdmF6cXVleiIsIlBlcmZpbCI6IjEiLCJleHAiOjE2NjA5MzQ5MjksImlzcyI6InNpbWFBdXRoZW50aWNhdGlvblNlcnZlciIsImF1ZCI6InNpbWFTZXJ2aWNlUG9zdG1hbkNsaWVudCJ9.0VB7zXF8P2801nEi7p58pHX5vr3RJmIG2p74x_qhZFU");

                HttpResponseMessage response = await client.SendAsync(request);
                string token = await response.Content.ReadAsStringAsync();
                await SecureStorage.SetAsync("token", token);

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