using System;
using Xamarin.Forms;

namespace pbcare
{
	public class BabyMonthlyPage : ContentPage
	{

		public BabyMonthlyPage ()
		{
			BackgroundImage = null ;

			Label monthLabel = new Label {
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};
			Label messageLabel = new Label { 
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};
			monthLabel.SetBinding (Label.TextProperty, "month");
			messageLabel.SetBinding (Label.TextProperty, "message");

			this.Content = new StackLayout {
				Padding = 20,
				Children = {
					monthLabel, messageLabel
				}
			};	
		}
	}
}


