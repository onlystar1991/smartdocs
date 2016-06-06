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

			actIndicator2.IsRunning = false;
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
			actIndicator2.IsRunning = true;

			App.G_WORK_ITEMS = await App.G_HTTP_CLIENT.GetAllWorkItemsAsync ();
			List<InvoiceModel> invoiceModels = new List<InvoiceModel> ();

			foreach (WorkItem item in App.G_WORK_ITEMS) {

				string date = "";
				if (!String.IsNullOrEmpty (item.headerData.Date)) {
					date = item.headerData.Date.Substring (0, 4) + "/" + item.headerData.Date.Substring (4, 2) + "/" + item.headerData.Date.Substring (6, 2);
				}

				string budget = "";
				if (!String.IsNullOrEmpty (item.headerData.Budgeted_Amount)) {
					budget = "$" + item.headerData.Budgeted_Amount;
				}

				InvoiceModel model = new InvoiceModel {
					InvoiceID = item.workItemId,
					From = item.headerData.Company_name,
					Price = budget,
					Date = date
				};
				invoiceModels.Add (model);
			}

			PopulateList (invoiceModels);
		}
	}
}

