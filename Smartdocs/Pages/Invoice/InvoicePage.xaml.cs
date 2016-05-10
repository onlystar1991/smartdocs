using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class InvoicePage : ContentPage
	{
		public InvoicePage ()
		{
			InitializeComponent ();
			List<InvoiceModel> invoicexModels = new List<InvoiceModel> {
				new InvoiceModel {
					InvoiceID = "Invoice1234",
					From = "ABC Corperation",
					Price = "$1340.00",
					Date = "8 PM 08/09/2016"
				},
				new InvoiceModel {
					InvoiceID = "Invoice6498",
					From = "CDE Inc.",
					Price = "$4450.21",
					Date = "10 PM 07/07/2016"
				}
			};
			PopulateList (invoicexModels);

			NavigationPage.SetHasNavigationBar(this, false);
		}

		private void PopulateList(List<InvoiceModel> list)
		{
			var column = InvoiceRow;

			var invoiceItemTapGestureRecognizer = new TapGestureRecognizer();
			invoiceItemTapGestureRecognizer.Tapped += OnProductTapped;

			for (var i = 0; i < list.Count; i++) {
				var item = new InvoiceItemTemplate();

				item.BindingContext = list[i];
				item.GestureRecognizers.Add (invoiceItemTapGestureRecognizer);
				column.Children.Add( item );
			}
		}

		private async void OnProductTapped(Object sender, EventArgs e){
			

			await Navigation.PushAsync (new InvoiceDetailPage ());
		}
	}
}

