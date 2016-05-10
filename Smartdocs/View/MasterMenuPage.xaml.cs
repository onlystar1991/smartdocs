using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class MasterMenuPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public MasterMenuPage ()
		{
			InitializeComponent ();

			var masterPageItems = new List<MasterPageItem> ();
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
	}
}

