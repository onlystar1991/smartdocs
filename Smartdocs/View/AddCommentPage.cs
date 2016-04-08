using System;

using Xamarin.Forms;

namespace Smartdocs
{
	public class AddCommentPage : ContentPage
	{
		public AddCommentPage ()
		{
			StackLayout MainLayout = new StackLayout {
				BackgroundColor = Color.Gray
			};

			StackLayout FirstRowLayout = new StackLayout {
				Padding = new Thickness(20, 10, 20, 0),
			};

			StackLayout SecondRowLayout = new StackLayout {
				Padding = new Thickness(10, 10, 10, 10),
				HeightRequest = 200
			};

			StackLayout ThirdRowLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.End,
				Padding = new Thickness(10, 10, 30, 10)
			};

			Label Title = new Label {
				Text = "Please input comments"
			};

			FirstRowLayout.Children.Add (Title);

			Editor CommentEditor = new Editor { 
				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			SecondRowLayout.Children.Add (CommentEditor);

			Button AddCommentButton = new Button {
				Text = "Add Comment",
			};
			ThirdRowLayout.Children.Add (AddCommentButton);

			MainLayout.Children.Add (FirstRowLayout);
			MainLayout.Children.Add (SecondRowLayout);
			MainLayout.Children.Add (ThirdRowLayout);
			Content = MainLayout;
		}
	}
}


