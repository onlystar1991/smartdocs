using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public class App : Application
	{
		public static WorkItemManager WorkManager { get; private set; }
		public static List<WorkItemModel> WorkItems { get; set; }
		public static App G_App { get; set; }
		public static WorkItemManager G_WORKITEM_MANAGER { get; set; }

		public App ()
		{
			// The root page of your application
			WorkManager = new WorkItemManager();
			WorkItems = new List<WorkItemModel> ();

			LoginPage login = new LoginPage();
			MainPage = login;
			G_App = this;
			G_WORKITEM_MANAGER = new WorkItemManager ();
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

