using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class NewInvoiceMain : ContentView
	{
		public NewInvoiceMain ()
		{
			InitializeComponent ();
			BackgroundColor = Color.Yellow;

			var barCodeScannerGesture = new TapGestureRecognizer();
			barCodeScannerGesture.Tapped += OnItemTapped;

			BarcodeScanner.GestureRecognizers.Add (barCodeScannerGesture);
		}

		private async void OnItemTapped(Object sender, EventArgs e)
		{
			#if __ANDROID__
			// Initialize the scanner first so it can track the current context
			MobileBarcodeScanner.Initialize (Application);
			#endif
			var BarCode = await DependencyService.Get<BarCodeScannerService>().ScanAsync();

			BarCodeResult.Text = BarCode;
		}
	}
}

