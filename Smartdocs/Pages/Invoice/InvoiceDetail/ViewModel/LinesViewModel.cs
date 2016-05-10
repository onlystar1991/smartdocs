using System;
using Xamarin.Forms;
using Smartdocs;

namespace Smartdocs.ViewModels
{
	public class LinesViewModel : BaseViewModel, ICarouselViewModel
	{
		public string PageTitle
		{
			get { return "Lines"; }
		}

		public ContentView View
		{
			get { return new LinesView(); }
		}
	}
}

