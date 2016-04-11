using System;

using Xamarin.Forms;

namespace Smartdocs
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			StackLayout FirstRowLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal
			};
			StackLayout SecondRowLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal
			};
			StackLayout ThirdRowLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal
			};

			Label NameLabel = new Label{
				Text = "User name:"
			};
			Label PasswordLabel = new Label{
				Text = "Password:"
			};
			Entry NameEntry = new Entry ();
			Entry PasswordEntry = new Entry ();

			Button LoginButton = new Button {
				Text = "Login"
			};

			FirstRowLayout.Children.Add (NameLabel);
			FirstRowLayout.Children.Add (NameEntry);
			SecondRowLayout.Children.Add (PasswordLabel);
			SecondRowLayout.Children.Add (PasswordEntry);
			ThirdRowLayout.Children.Add (LoginButton);

			Content = new StackLayout { 
				Children = {
					FirstRowLayout, SecondRowLayout, ThirdRowLayout
				}
			};
			LoginButton.Clicked += (sender, e) => {
				var homeNav = new NavigationPage( new HomePage() ) { Title = "Smart Docs" };

				App.G_App.MainPage = homeNav;
			};
		}
	}
}


