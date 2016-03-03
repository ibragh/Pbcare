using System;
using Xamarin.Forms;

namespace pbcare
{
	public class PregnancyWeeklyPage : ContentPage
	{
		
		public PregnancyWeeklyPage (bool includeBigLabel)
		{
			// Build the page
			this.Content = new StackLayout {
				 Padding = 20,
				Children = {

				}
			};
			// Add in the big Label at top for CarouselPage.
			if (includeBigLabel) {
				Label bigLabel = new Label {
					FontSize = 50,
					HorizontalOptions = LayoutOptions.Center
				};
				Label bigLabel1 = new Label { 
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Center
				};
				bigLabel.SetBinding (Label.TextProperty, "week");
				bigLabel1.SetBinding (Label.TextProperty, "messege");
				(this.Content as StackLayout).Children.Insert (0, bigLabel);
				(this.Content as StackLayout).Children.Insert (1, bigLabel1);
			}
		}
	}
}
	