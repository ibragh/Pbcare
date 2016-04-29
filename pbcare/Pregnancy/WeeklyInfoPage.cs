using System;
using Xamarin.Forms;

namespace pbcare
{
	public class WeeklyInfoPage : ContentPage
	{
		
		public WeeklyInfoPage ()
		{
			BackgroundColor = Color.FromRgb (197, 255, 255);


			Label WeekLabel = new Label {
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center,
				TextColor = Color.FromHex("#5069A1"),
			};
			Label messageLabel = new Label { 
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,  
				TextColor = Color.FromHex("#5069A1"),
			};
			WeekLabel.SetBinding (Label.TextProperty, "week");
			messageLabel.SetBinding (Label.TextProperty, "message");

			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				Padding = new Thickness(10,20,0,10),
				Children = {
					WeekLabel, 
					new ScrollView{
						Content = new StackLayout{ 
							Padding = new Thickness(0,0,20,0),
							Children = {
								messageLabel
							}
						}
					}
				}
			};	
		}
	}
}
		

	