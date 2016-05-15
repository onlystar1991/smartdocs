using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class LinesViewItemTemplate : ContentView
	{
		public LinesViewItemTemplate ()
		{
			InitializeComponent ();
		}
	}

	public class LinesViewModel {
		public string Line { get; set; }
		public string Material { get; set; }
		public string Amount { get; set; }
		public string Quantity { get; set; }
	}
}