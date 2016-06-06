using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Smartdocs.Models;

namespace Smartdocs
{
	public partial class MainView : ContentView
	{
		public MainView ()
		{
			InitializeComponent ();

			VendorLabel.Text = App.G_CURRENT_ACTIVE_ITEM.headerData.Vendor_Name;
			BudgetLabel.Text = "$" + App.G_CURRENT_ACTIVE_ITEM.headerData.Budgeted_Amount;
			ReferenceLabel.Text = App.G_CURRENT_ACTIVE_ITEM.headerData.Reference_No;
			DateLabel.Text = App.G_CURRENT_ACTIVE_ITEM.headerData.Date;
		}

	}
}

