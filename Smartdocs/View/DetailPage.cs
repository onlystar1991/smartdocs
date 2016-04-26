using System;
using Xamarin.Forms;

namespace Smartdocs
{
	public class DetailPage : ContentPage
	{
		public DetailPage ()
		{
			Grid grid = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(100, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength(100, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength(100, GridUnitType.Star)},
				}
			};

			grid.Children.Add (new Label {
				Text = "Document No",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.End
			}, 0, 0);

			grid.BackgroundColor = Color.Gray;

			Entry DocNoEntry = new Entry {
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White
			};

			grid.Children.Add (DocNoEntry, 1, 0);

			Button BarCodeButton = new Button {
				Text = "Bar Code",
			};

			BarCodeButton.Clicked += async (sender, e) => {
				#if __ANDROID__
				// Initialize the scanner first so it can track the current context
				MobileBarcodeScanner.Initialize (Application);
				#endif
				var BarCode = await DependencyService.Get<BarCodeScannerService>().ScanAsync();
				DocNoEntry.Text = BarCode;
			};

			grid.Children.Add (BarCodeButton, 2, 0);

			grid.Children.Add (new Label {
				Text = "Amount",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.End
			}, 0, 1);

			Entry DocAmountEntry = new Entry {
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White,
			};

			grid.Children.Add (DocAmountEntry, 1, 1);

			grid.Children.Add ( new Label {
				Text = "USD",
				VerticalOptions = LayoutOptions.Center
			}, 2, 1);

			grid.Children.Add (new Label {
				Text = "Vendor",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.End
			}, 0, 2);

			Entry VendorEntry = new Entry {
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White
			};

			grid.Children.Add (VendorEntry, 1, 2);

			grid.Children.Add (new Label {
				Text = "Reference No",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.End
			}, 0, 3);

			Entry ReferenceEntry = new Entry {
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White
			};

			grid.Children.Add (ReferenceEntry, 1, 3);

			grid.Children.Add (new Label {
				Text = "Tax Code",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.End
			}, 0, 4);

			Entry TaxCodeEntry = new Entry {
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White
			};

			grid.Children.Add (TaxCodeEntry, 1, 4);

			grid.Children.Add (new Label {
				Text = "Date",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.End
			}, 0, 5);

			Entry DateEntry = new Entry {
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White
			};

			grid.Children.Add (DateEntry, 1, 5);

			Button AddAttachementButton = new Button {
				Text = "Add Attachement",
				VerticalOptions = LayoutOptions.Center
			};

			grid.Children.Add (AddAttachementButton, 1, 6);

			Button AddCommentButton = new Button {
				Text = "Add Comment",
			};

			AddCommentButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new AddCommentPage());
			};

			grid.Children.Add (AddCommentButton, 0, 7);

			Button AddDisplayLog = new Button {
				Text = "Display Log",
			};

			AddDisplayLog.Clicked += (sender, e) => {
				Navigation.PushAsync(new LogsPage());
			};

			grid.Children.Add (AddDisplayLog, 2, 7);

			Button Approved = new Button {
				Text = "Approved",
			};

			grid.Children.Add (Approved, 0, 8);

			Button Rejected = new Button {
				Text = "Rejected",
			};

			grid.Children.Add (Rejected, 2, 8);

			Content = grid;
			BackgroundColor = Color.Gray;
			Padding = new Thickness (0, Device.OnPlatform (20, 20, 20), 0, 0);
		}

	}
}


