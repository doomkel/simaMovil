using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using simaMovil.Models;
using simaMovil.Data;
using System.Net.Http.Headers;

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
            //User user = new User(entUser.Text, entPass.Text);

            //if (user.CheckInformation())

            var result = await CheckInformation(entUser.Text, entPass.Text);

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

        
        public async Task<bool> CheckInformation(string _usu, string _pass)
        //public string CheckInformation(string _usu, string _pass)
        {
            try
            {
                var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Usuario", _usu),
                new KeyValuePair<string, string>("Clave", _pass )

            };

                var request = new HttpRequestMessage(HttpMethod.Get, "https://192.168.0.127:44392/api/remisiones");

                //request.Content = new FormUrlEncodedContent(keyValues);
                //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var client = new HttpClient(Xamarin.Forms.DependencyService.Get<IMyOwnNetService>().GetHttpClientHandler());

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzaW1hU2VydmljZUFjY2Vzc1Rva2VuIiwianRpIjoiY2I3YTIwZTUtYmU5OS00OGRmLWIzNjMtMjUwYzMwZmFkYTY1IiwiaWF0IjoiMTEvMDgvMjAyMiAwNjoxOTo0NSBwLiBtLiIsIkNvZF91c3VhcmlvIjoiMSIsIlVzdWFyaW8iOiJkdmF6cXVleiIsIlBlcmZpbCI6IjEiLCJleHAiOjE2NjAzMjgzODYsImlzcyI6InNpbWFBdXRoZW50aWNhdGlvblNlcnZlciIsImF1ZCI6InNpbWFTZXJ2aWNlUG9zdG1hbkNsaWVudCJ9.lHbxM2jNkD18b3D5uUYYA57Xu_jALqW-cE3NgNEWLbE");

                HttpResponseMessage response = await client.SendAsync(request);
                //var response = client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
                //var responseString = response.Content.ReadAsStringAsync();

                Debug.WriteLine(responseString);
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
    }
}