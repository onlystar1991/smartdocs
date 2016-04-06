using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Smartdocs
{
	public class HomePage : ContentPage
	{
		List<WorkItemModel> result;

		public HomePage ()
		{

			var stlButton = new Button { 
				Text = "STL", 
				BorderWidth = 2, 
				BorderColor = Color.Red,
				WidthRequest = 100,
				HeightRequest = 50,
			};

			stlButton.Clicked += async (sender, e) => {
				await Navigation.PushAsync(new SmartTaskList());
			};


			var requestButton = new Button {
				Text = "Request", 
				BorderWidth = 2, 
				BorderColor = Color.Red,
				WidthRequest = 100,
				HeightRequest = 50
			};
			var settingButton = new Button { 
				Text = "Setting", 
				BorderWidth = 2, 
				BorderColor = Color.Red,
				WidthRequest = 100,
				HeightRequest = 50
			};
			var outboxButton = new Button {
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
					stlButton, requestButton
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center
			};

			StackLayout SecondRowLayout = new StackLayout
			{ 
				Children = {
					settingButton, outboxButton
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center
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

			result = new List<WorkItemModel> ();

			result = await App.WorkManager.GetAllWorkItems();

			Debug.WriteLine (result);
		}
	}
}


