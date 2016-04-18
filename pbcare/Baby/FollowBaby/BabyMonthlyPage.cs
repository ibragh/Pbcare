using System;
using Xamarin.Forms;

namespace pbcare
{
	public class BabyMonthlyPage : ContentPage
	{
		Label monthLabel , messageLabel ;

		public BabyMonthlyPage ()
		{

			monthLabel = new Label {
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center, 
				TextColor = Color.FromHex("#5069A1"),
			};
			messageLabel = new Label { 
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center, 
				TextColor = Color.FromHex("#5069A1"),
			};
			monthLabel.SetBinding (Label.TextProperty, "month");
			messageLabel.SetBinding (Label.TextProperty, "message");


			}

		protected override void OnAppearing ()
		{

			this.Content = new StackLayout {
				Padding = 20,
				Children = {
					monthLabel, messageLabel
				}
			};
		}
	}
}


