using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class RequestPage : ContentPage
	{
		public RequestPage ()
		{
			InitializeComponent ();

			List<InboxViewModel> inboxModels = new List<InboxViewModel> {
				new InboxViewModel {
					Title = "Payment",
					Status = "Request",
					ImageIcon = "payment.png"
				},
				new InboxViewModel {
					Title = "Price Change",
					Status = "Request",
					ImageIcon = "price.png"
				},
				new InboxViewModel {
					Title = "Maintenance",
					Status = "Request",
					ImageIcon = "maintenance.png"
				},
				new InboxViewModel {
					Title = "Delivery",
					Status = "Request",
					ImageIcon = "request.png"
				},
				new InboxViewModel {
					Title = "Proof of Delivery",
					Status = "Request",
					ImageIcon = "request.png"
				}
			};
			PopulateList (inboxModels);

			NavigationPage.SetHasNavigationBar(this, false);
		}

		private void PopulateList(List<InboxViewModel> list)
		{
			var column = LeftColumn;

			var itemTapped = new TapGestureRecognizer();
			itemTapped.Tapped += OnItemTapped;

			for (var i = 0; i < list.Count; i++) {
				var item = new InboxItemTemplate();

				if (i % 2 == 0) {
					column = LeftColumn;
				} else {
					column = RightColumn;
				}

				item.GestureRecognizers.Add( itemTapped );
				item.BindingContext = list[i];
				column.Children.Add( item );
			}
		}

		private async void OnItemTapped (Object sender, EventArgs e) {

			var selectedItem = (InboxViewModel)((InboxItemTemplate)sender).BindingContext;

			if (selectedItem.Title.Equals ("Proof of Delivery")) {
				await Navigation.PushAsync (new ProofOfDeliveryPage ());
			} else {
				await Navigation.PushAsync (new NewInvoice ());
			}

		}
	}
}

