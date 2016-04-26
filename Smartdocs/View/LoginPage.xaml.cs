using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Smartdocs
{
	public partial class LoginPage : ContentPage
	{
		Entry UsernameEntry { get; set; }
		Entry PasswordEntry { get; set; }

		public LoginPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			string platformName = Device.OS.ToString ();
			Content.FindByName<Button> ("loginButton" + platformName).Clicked += OnLoginButtonClicked;
			UsernameEntry = Content.FindByName<Entry>
		}

		public async void OnLoginButtonClicked(object sender, EventArgs args) {
			var result = await App.G_HTTP_CLIENT.LoginAsync("admin", "admin");

			Debug.WriteLine (result);
			Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
				
				if(result == null) {
					DisplayAlert("Error", "Can't connect server.", "Ok");
				} else {
					DisplayAlert("Hello", "Login Successed", "OK");

				}
			});
		}
	}
}

