﻿using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
namespace Leave_appz
{
    public partial class Leave_appzPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
          
                if (user_name.Text.Trim().Equals(""))
                {
                    DisplayAlert("Warning", "User Name Text Field Is Empty", "ok");

                }
                else if (user_password.Text.Trim().Equals(""))
                {
                    DisplayAlert("Warning", "User Password Text Field Is Empty", "ok");
                }
                else
                {
                    PostRequest(AppConstant.URL, user_name.Text, user_password.Text);
                }
           
        }

        public Leave_appzPage()
        {
            InitializeComponent();
            backgroundImage.Source = ImageSource.FromResource("Leave_appz.Assets.background.png");
            whitelogoImage.Source = ImageSource.FromResource("Leave_appz.Assets.whitelogoss.png");
            user_name.Text = "";
            user_password.Text = "";
            NavigationPage.SetHasNavigationBar(this, false);

        }


        async void PostRequest(string URL,string userName,string userPassword)
        {
            System.Diagnostics.Debug.WriteLine("asa");
            var formContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("id", "1"),
                new KeyValuePair<string, string>("useremail", userName),
                new KeyValuePair<string, string>("password", userPassword),
            });

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync(URL, formContent);

            var json = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(json);

            try
            {
                var userModel = JsonConvert.DeserializeObject<JsonModelClass.UserDataModel>(json);
                if (userModel.email_id.Trim().Equals(user_name.Text.Trim()) && userModel.user_password.Trim().Equals(user_password.Text.Trim())){
                    Application.Current.Properties["email"] = user_name.Text.Trim();
                    Application.Current.Properties["password"] = user_password.Text.Trim();
                    await Navigation.PushAsync(new MainPage());
                }
                else{
                  await  DisplayAlert("Warning", "Wrong User Name Or Password", "ok");
                }
            }catch(JsonSerializationException ex){
                System.Diagnostics.Debug.WriteLine(ex.ToString());
               await DisplayAlert("Warning", "Wrong User Name Or Password", "ok");
            }


        }



    }

}
