using System;
using Xamarin.Forms;

namespace pbcare
{
	public class PregnancyWeeklyPage : ContentPage
	{
		
		public PregnancyWeeklyPage ()
		{
			BackgroundColor = Color.FromRgb (197, 255, 255);


			Label WeekLabel = new Label {
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center,
				TextColor = Color.FromHex("#5069A1"),
			};
			Label messageLabel = new Label { 
				FontSize = 20,
				HorizontalOptions = LayoutOptions.EndAndExpand, 
				TextColor = Color.FromHex("#5069A1"),
			};
			WeekLabel.SetBinding (Label.TextProperty, "week");
			messageLabel.SetBinding (Label.TextProperty, "message");

			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.End,
				Padding = 20,
				Children = {
					WeekLabel, messageLabel
				}
			};	
		}
	}
}
		

	