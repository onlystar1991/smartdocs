using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

using Xamarin.Forms;
using Smartdocs.Models;

namespace Smartdocs
{
	public partial class InvoicePage : ContentPage
	{
		public InvoicePage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		private void PopulateList(List<InvoiceModel> list)
		{
			var column = InvoiceRow;
			column.Children.Clear ();

			var invoiceItemTapGestureRecognizer = new TapGestureRecognizer();
			invoiceItemTapGestureRecognizer.Tapped += OnInvoiceTapped;

			for (var i = 0; i < list.Count; i++) {
				var item = new InvoiceItemTemplate();

				item.BindingContext = list[i];
				item.GestureRecognizers.Add (invoiceItemTapGestureRecognizer);
				column.Children.Add( item );
			}
		}

		private async void OnInvoiceTapped(Object sender, EventArgs e) {

			var selectedItem = (InvoiceModel)((InvoiceItemTemplate)sender).BindingContext;
			WorkItem viewItem = new WorkItem ();
			foreach (WorkItem item in App.G_WORK_ITEMS) {
				if (selectedItem.InvoiceID.Equals (item.workItemId)) {
					viewItem = item;
					break;
				}
			}
			App.G_CURRENT_ACTIVE_ITEM = viewItem;
			await Navigation.PushAsync ( new InvoiceDetailPage() );
		}

		protected async override void OnAppearing () {

			App.G_WORK_ITEMS = new List<WorkItem> ();

			App.G_WORK_ITEMS = await App.G_HTTP_CLIENT.GetAllWorkItemsAsync ();
			List<InvoiceModel> invoiceModels = new List<InvoiceModel> ();

			foreach (WorkItem item in App.G_WORK_ITEMS) {
				
				InvoiceModel model = new InvoiceModel {
					InvoiceID = item.workItemId,
					From = item.headerData.Company_name,
					Price = "$" + item.headerData.Budgeted_Amount,
					Date = item.headerData.Date
				};
				invoiceModels.Add (model);
			}

			PopulateList (invoiceModels);
		}
	}
}

