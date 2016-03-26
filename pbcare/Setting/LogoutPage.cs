using System;

using Xamarin.Forms;

namespace pbcare
{
	public class LogoutPage : ContentPage
	{
		public LogoutPage ()
		{
			var msg = new Label { 
				Text = "Thank you for using Pbcare", 
				TextColor = Color.Navy 
			};

			var ExitButton = new Button {
				Text="Exit :(",
			};
			//ExitButton.Clicked += ExitButtonClicked ();
			var LoginButton = new Button {
				Text="Login again :)",
			};

			Content = new StackLayout { 
				Padding = 20, HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {
					msg,
					ExitButton,
					LoginButton
				}
			};

		}

	}
}


