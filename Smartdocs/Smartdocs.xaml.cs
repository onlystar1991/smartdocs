using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Smartdocs.Models;

namespace Smartdocs
{
	public partial class App : Application
	{
		public static App G_App { get; set; }
		public static HttpHandler G_HTTP_CLIENT { get; set; }
		public static bool G_IS_LOGGEDIN {get; set;}
		public static Page G_ROOT_PAGE { get; set; }
		public static WorkItem G_CURRENT_ACTIVE_ITEM { get; set; }

		public static List<WorkItem> G_WORK_ITEMS {
			get;
			set;
		}

		public App ()
		{
			InitializeComponent ();

			G_WORK_ITEMS = new List<WorkItem> ();
			G_CURRENT_ACTIVE_ITEM = new WorkItem ();
			IDictionary<string, object> properties = Application.Current.Properties;

			if (properties.ContainsKey ("LoggedIn") && properties ["LoggedIn"].Equals ("true")) {
				Constants.SECRET_TOKEN = properties ["token"].ToString ();
				MainPage = new NavigationPage (new RootPage ());
			} else {
				MainPage = new NavigationPage (new Login ());
			}

			G_App = this;
			G_HTTP_CLIENT = new HttpHandler ();
			G_IS_LOGGEDIN = false;
		}
	}
}