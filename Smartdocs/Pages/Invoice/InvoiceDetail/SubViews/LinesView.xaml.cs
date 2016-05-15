using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class LinesView : ContentView
	{
		public LinesView ()
		{
			InitializeComponent ();

			List<LinesViewModel> linesModels = new List<LinesViewModel> {
				new LinesViewModel {
					Line = "1",
					Material = "100-100",
					Amount = "500.00",
					Quantity = "5 pcs"
				},
				new LinesViewModel {
					Line = "2",
					Material = "100-110",
					Amount = "299.22",
					Quantity = "2 EA"
				}
			};
			PopulateList (linesModels);
		}

		private void PopulateList(List<LinesViewModel> list)
		{
			var column = Row;

			for (var i = 0; i < list.Count; i++) {
				var item = new LinesViewItemTemplate ();

				item.BindingContext = list[i];
//				item.GestureRecognizers.Add( inboxItemTapped );
				column.Children.Add( item );
			}
		}
	}
}

