using System;

using Xamarin.Forms;

namespace Smartdocs
{
	public class SettingPage : ContentPage
	{
		public SettingPage ()
		{
			StackLayout MainLayout = new StackLayout ();
			MainLayout.Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
			MainLayout.VerticalOptions = LayoutOptions.FillAndExpand;
			Label Title = new Label
			{
				Text = "Setting Page"
			};
			MainLayout.Children.Add (Title);
			Content = MainLayout;
		}
	}
}


