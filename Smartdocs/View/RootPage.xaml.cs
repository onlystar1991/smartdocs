using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class RootPage : MasterDetailPage
	{
		public RootPage ()
		{
			InitializeComponent ();

			NavigationPage.SetHasNavigationBar(this, false);
			masterMenuPage.ListView.ItemSelected += OnItemSelected;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			if (!App.G_IS_LOGGEDIN) {
				await Navigation.PushModalAsync (new NavigationPage (new Login ()));
			}
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e) 
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null) {
				IsPresented = false;
			}
		}

	}
}

