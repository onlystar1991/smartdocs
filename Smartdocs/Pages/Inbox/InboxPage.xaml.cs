using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class InboxPage : ContentPage
	{
		public InboxPage ()
		{
			InitializeComponent ();
			List<InboxViewModel> inboxModels = new List<InboxViewModel> {
				new InboxViewModel {
					Title = "Invoice",
					Status = "Approval",
					ImageIcon = "invoice.png",
					PageType = typeof(InvoicePage)
				},
				new InboxViewModel {
					Title = "Purchase Order",
					Status = "Approval",
					ImageIcon = "purchase_order.png",
					PageType = typeof(PurchaseOrder)
				},
				new InboxViewModel {
					Title = "Purchase Request",
					Status = "Approval",
					ImageIcon = "purchase_request.png",
					PageType = typeof(PurchaseRequest)
				},
				new InboxViewModel {
					Title = "Material Master",
					Status = "Request",
					ImageIcon = "request.png",
					PageType = typeof(MaterialMaster)
				}
			};

			PopulateList (inboxModels);
			NavigationPage.SetHasNavigationBar(this, false);
		}

		private void PopulateList(List<InboxViewModel> list)
		{
			var column = LeftColumn;
			var inboxItemTapped = new TapGestureRecognizer();
			inboxItemTapped.Tapped += OnItemTapped;

			for (var i = 0; i < list.Count; i++) {
				var item = new InboxItemTemplate();

				if (i % 2 == 0) {
					column = LeftColumn;
				} else {
					column = RightColumn;
				}
				item.BindingContext = list[i];
				item.GestureRecognizers.Add( inboxItemTapped );
				column.Children.Add( item );
			}
		}

		private async void OnItemTapped(Object sender, EventArgs e)
		{
			var selectedItem = (InboxViewModel)((InboxItemTemplate)sender).BindingContext;
			try {
				
				var page = (Page)Activator.CreateInstance (selectedItem.PageType);

				await Navigation.PushAsync(page);

			} catch(Exception ex) {
				Debug.WriteLine ("Test", ex.ToString ());
			}

		}
	}
}

