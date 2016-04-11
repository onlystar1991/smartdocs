using System;
using System.Threading.Tasks;
using ZXing.Mobile;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Smartdocs.iOS.BarCodeScanner))]

namespace Smartdocs.iOS
{
	public class BarCodeScanner : BarCodeScannerService
	{
		public BarCodeScanner ()
		{
			
		}

		public async Task<string> ScanAsync()
		{
			var scanner = new ZXing.Mobile.MobileBarcodeScanner ();
			var scanResult = await scanner.Scan ();
			if (scanResult != null)
				return scanResult.Text;
			else
				return "";
		}
	}
}

