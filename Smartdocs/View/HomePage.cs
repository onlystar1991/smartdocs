using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Smartdocs
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{

			var StlButton = new Button { 
				Text = "STL", 
				BorderWidth = 2, 
				BorderColor = Color.Red,
				WidthRequest = 100,
				HeightRequest = 50,
			};

			StlButton.Clicked += async (sender, e) => {
				await Navigation.PushAsync(new SmartTaskList());
			};

			var RequestButton = new Button {
				Text = "Request", 
				BorderWidth = 2, 
				BorderColor = Color.Red,
				WidthRequest = 100,
				HeightRequest = 50,
			};
			var SettingButton = new Button {
				Text = "Setting", 
				BorderWidth = 2, 
				BorderColor = Color.Red,
				WidthRequest = 100,
				HeightRequest = 50
			};
			var OutboxButton = new Button {
				Text = "Outbox", 
				BorderWidth = 2, 
				BorderColor = Color.Red,
				WidthRequest = 100,
				HeightRequest = 50
			};
			Title = "Home Page";

			StackLayout FirstRowLayout = new StackLayout
			{
				Children = {
					StlButton, RequestButton
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				Padding = new Thickness(5, 5, 5, 5)
			};

			StackLayout SecondRowLayout = new StackLayout
			{ 
				Children = {
					SettingButton, OutboxButton
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				Padding = new Thickness(5, 5, 5, 5)
			};


			Content = new StackLayout {
				Children = {
					FirstRowLayout, SecondRowLayout
				},
				BackgroundColor = Color.FromRgb(50, 200, 50),
				Padding = new Thickness(5, 5, 5, 5)
			};
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			App.WorkItems = await App.WorkManager.GetAllWorkItems();
		}
	}
}