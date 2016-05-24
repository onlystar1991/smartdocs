using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Smartdocs
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();

			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			Content.FindByName<Button> ("loginButton").Clicked += OnLoginButtonClicked;

			indicator.VerticalOptions = LayoutOptions.CenterAndExpand;
			indicator.IsVisible = false;
			indicator.Color = Device.OnPlatform (Color.Black, Color.Default, Color.Default);

			// Make Navigation Bar Title Invisible
			NavigationPage.SetHasNavigationBar (this, false);
		}

		async void OnLoginButtonClicked(object sender, EventArgs args) {
			if (CheckValidate ()) {
				indicator.IsVisible = true;
				((Button)sender).IsEnabled = false;

				var result = await App.G_HTTP_CLIENT.LoginAsync (username.Text.Trim(), password.Text.Trim());
				Xamarin.Forms.Device.BeginInvokeOnMainThread (async () => {
					((Button)sender).IsEnabled = true;
					indicator.IsVisible = false;
					if (result == null) {
						await DisplayAlert ("Error", "Can't connect server.", "Ok");
					} else {
						if (result.Equals("OK")) {
							GotoHomePage();
						} else {
							await DisplayAlert ("Warning", "Bad credentials", "Ok");
						}
					}
				});

			} else {
				await DisplayAlert ("Warning!", "Username and password is required!", "Ok");
			}
		}

		private bool CheckValidate() {
			
			if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Text))
				return false;
			else
				return true;
		}

		async void GotoHomePage() {
			Application.Current.Properties["LoggedIn"] = "true";
			Navigation.InsertPageBefore (new RootPage (), this);
			await Navigation.PopAsync ();
		}
	}
}

