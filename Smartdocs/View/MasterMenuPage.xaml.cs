using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class MasterMenuPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		List<MasterPageItem> masterPageItems;

		public MasterMenuPage ()
		{
			InitializeComponent ();

			masterPageItems = new List<MasterPageItem> ();
			masterPageItems.Add (new MasterPageItem {
				Title = "Inbox",
				IconSource = "inbox.png",
				TargetType = typeof(DetailPage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Requests",
				IconSource = "requests.png",
				TargetType = typeof(SmartTaskList)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Outbox",
				IconSource = "outbox.png",
				TargetType = typeof(SmartTaskList)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "Settings",
				IconSource = "setting.png",
				TargetType = typeof(SmartTaskList)
			});
			listView.ItemsSource = masterPageItems;
		}

		private void OnItemTapped(Object sender, ItemTappedEventArgs e)
		{
			var selectedItem = ((ListView)sender).SelectedItem;
			int selectedIndex = 0;
			for (int i = 0; i < masterPageItems.Count; i++) 
			{
				if (((MasterPageItem)selectedItem).Title.Equals (masterPageItems [i].Title)) {
					selectedIndex = i;
					break;
				}
			}

			Element current = this;
			while (current.Parent != null ) {
				current = current.Parent;
				if (current.GetType().Name == "RootPage") {
					break;
				}
			}
			var master = current as MasterDetailPage;
			((TabbedPage)master.Detail).CurrentPage = ((TabbedPage)master.Detail).Children [selectedIndex];
		}
	}
}

