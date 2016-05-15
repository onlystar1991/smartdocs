using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class OutboxPage : ContentPage
	{
		public OutboxPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);

			List<InvoiceModel> invoicexModels = new List<InvoiceModel> {
				new InvoiceModel {
					InvoiceID = "Invoice1234",
					From = "ABC Corperation",
					Price = "$1,340.00",
					Date = "8 PM 08/09/2016"
				},
				new InvoiceModel {
					InvoiceID = "Invoice6498",
					From = "CDE Inc.",
					Price = "$4,450.21",
					Date = "10 PM 07/07/2016"
				}
			};
			PopulateList (invoicexModels);
		}

		private void PopulateList(List<InvoiceModel> list)
		{
			var column = InvoiceRow;

			for (var i = 0; i < list.Count; i++) {
				var item = new InvoiceItemTemplate();
				item.BindingContext = list[i];
				column.Children.Add( item );
			}
		}

		public void OnHamburgerIconTapped(Object sender, EventArgs e)
		{
			Element current = this;

			while (current.Parent != null ) {
				current = current.Parent;
				if (current.GetType().Name == "RootPage") {
					break;
				}
			}

			var master = current as MasterDetailPage;

			if (master != null) {
				master.IsPresented = true;
			}
		}
	}
}

