using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;

namespace Smartdocs
{
	public class SmartTaskList : ContentPage
	{
		public SmartTaskList ()
		{
			var poButton = new Button { Text = "PO", BorderWidth = 2, BorderColor = Color.Red };

			Title = "SmartTask List";

			var prButton = new Button { Text = "PR", BorderWidth = 2, BorderColor = Color.Red  };
			var vendorButton = new Button { Text = "VENDOR", BorderWidth = 2, BorderColor = Color.Red  };

			Content = new StackLayout {
				Children = {
					poButton, prButton, vendorButton
				},

				Padding = new Thickness(5, 5, 5, 5)
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
		}
	}
}


