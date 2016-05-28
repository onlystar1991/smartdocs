using Xamarin.Forms;
using Smartdocs.Custom;
using Smartdocs.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Smartdocs
{
	public class InvoiceDetailPage : ContentPage
	{
		private View _tabs;

		private RelativeLayout _relativeLayout;

		private TabbedPageViewModel _viewModel;

		public InvoiceDetailPage ()
		{
			_viewModel = new TabbedPageViewModel();
			BindingContext = _viewModel;
			BackgroundColor = Color.White;

			_relativeLayout = new RelativeLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var pagesCarousel = CreatePagesCarousel();
			_tabs = CreateTabs();
			var tabsHeight = 36;

			_relativeLayout.Children.Add (_tabs, 
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent (parent => parent.Width),
				Constraint.Constant (tabsHeight)
			);

			_relativeLayout.Children.Add (pagesCarousel,
				Constraint.RelativeToParent ((parent) => { return parent.X; }),
				Constraint.RelativeToParent ((parent) => { return tabsHeight; }),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToView (_tabs, (parent, sibling) => { return parent.Height - (sibling.Height); })
			);

			StackLayout stackLayout = new StackLayout {
				BackgroundColor = Color.White
			};
			StackLayout menu = new StackLayout {
				HeightRequest = Device.OnPlatform(56, 46, 46),
				BackgroundColor = Color.White,
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Center,
			};

				Image togglMenuImage = new Image {
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					WidthRequest = 18,
					HeightRequest = 18,
					Source = "toggle_menu.png",
				};

				StackLayout menuBarCenter = new StackLayout {
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.Center
				};

				Label MenuBarTitle = new Label {
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.Center,
					FontSize = 18,
					Text = "SmartDocs",
					TextColor = Color.Black
				};

				menuBarCenter.Children.Add (MenuBarTitle);
				Image SearchImage = new Image {
					HorizontalOptions = LayoutOptions.End,
					VerticalOptions = LayoutOptions.Center,
					Source = "search.png",
					WidthRequest = 18,
					HeightRequest = 18
				};

			menu.Children.Add (togglMenuImage);
			menu.Children.Add (menuBarCenter);
			menu.Children.Add (SearchImage);

			menu.Padding = new Thickness (10, 38, 10, 10);

			stackLayout.Children.Add (menu);
			_relativeLayout.BackgroundColor = Color.White;
			stackLayout.Children.Add (_relativeLayout);
			Content = stackLayout;
			NavigationPage.SetHasNavigationBar(this, false);
		}

		CarouselLayout CreatePagesCarousel ()
		{
			var carousel = new CarouselLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate(typeof(DynamicTemplateLayout))
			};
			carousel.SetBinding(CarouselLayout.ItemsSourceProperty, "Pages");
			carousel.SetBinding(CarouselLayout.SelectedItemProperty, "CurrentPage", BindingMode.TwoWay);

			return carousel;
		}

		private View CreateTabsContainer()
		{
			return new StackLayout
			{
				Children = { CreateTabs() }
			};
		}

		private View CreateTabs()
		{
			var pagerIndicator = new PagerIndicatorTabs() { HorizontalOptions = LayoutOptions.CenterAndExpand };
			pagerIndicator.RowDefinitions.Add(new RowDefinition() { Height = 36 });
			pagerIndicator.SetBinding(PagerIndicatorTabs.ColumnDefinitionsProperty, "Pages", BindingMode.Default, new SpacingConverter());
			pagerIndicator.SetBinding(PagerIndicatorTabs.ItemsSourceProperty, "Pages");
			pagerIndicator.SetBinding(PagerIndicatorTabs.SelectedItemProperty, "CurrentPage");

			return pagerIndicator;
		}
	}

	public class SpacingConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var items = value as IEnumerable<ICarouselViewModel>;

			var collection = new ColumnDefinitionCollection();
			foreach (var item in items)
			{
				collection.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
			}
			return collection;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}