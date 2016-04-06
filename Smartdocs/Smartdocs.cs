using System;

using Xamarin.Forms;

namespace Smartdocs
{
	public class App : Application
	{
		public static WorkItemManager WorkManager { get; private set; }

		public App ()
		{
			// The root page of your application
			WorkManager = new WorkItemManager(new HttpHandler());

			var homeNav = new NavigationPage( new HomePage() ) { Title = "Smart Docs" };
			MainPage = homeNav;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

