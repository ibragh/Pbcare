using System;
using Xamarin.Forms;

namespace pbcare
{
	public class PregnancyWeeklyPage : ContentPage
	{
		
		public PregnancyWeeklyPage ()
		{
			BackgroundImage = null ;

			Label WeekLabel = new Label {
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};
			Label messageLabel = new Label { 
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};
			WeekLabel.SetBinding (Label.TextProperty, "week");
			messageLabel.SetBinding (Label.TextProperty, "message");

			this.Content = new StackLayout {
				Padding = 20,
				Children = {
					WeekLabel, messageLabel
				}
			};	
		}
	}
}
		

	