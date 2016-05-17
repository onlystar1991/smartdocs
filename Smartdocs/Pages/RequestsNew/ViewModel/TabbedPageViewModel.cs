using System;
using System.Collections.Generic;
using System.Linq;
using Smartdocs.Request;

namespace Smartdocs.Request.ViewModel
{
	public class TabbedPageViewModel: BaseViewModel
	{
		public TabbedPageViewModel()
		{
			Pages = new List<ICarouselViewModel>
			{
				new MainViewModel(),

				new FileViewModel()
			};
		}

		private IEnumerable<ICarouselViewModel> _pages;

		public IEnumerable<ICarouselViewModel> Pages
		{
			get
			{
				return _pages;
			}
			set
			{
				SetObservableProperty(ref _pages, value);
				CurrentPage = Pages.FirstOrDefault();
			}
		}

		private ICarouselViewModel _currentPage;

		public ICarouselViewModel CurrentPage
		{
			get
			{
				return _currentPage;
			}
			set
			{
				SetObservableProperty(ref _currentPage, value);
			}
		}
	}
}

