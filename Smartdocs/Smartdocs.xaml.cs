using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Smartdocs
{
	public partial class App : Application
	{
		public static List<WorkItemModel> WorkItems { get; set; }
		public static App G_App { get; set; }
		public static HttpHandler G_HTTP_CLIENT { get; set; }
		public static bool G_IS_LOGGEDIN {get; set;}
		public static Page G_ROOT_PAGE { get; set; }

		public App ()
		{
			InitializeComponent ();

			WorkItems = new List<WorkItemModel> ();

			IDictionary<string, object> properties = Application.Current.Properties;

			if (properties.ContainsKey ("LoggedIn") && properties ["LoggedIn"].Equals ("true")) {
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