using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public class FollowFetusByImages :  ContentPage
	{
		public FollowFetusByImages()
		{
			this.Title = "Pregnancy Weekly";
			string msg = "Text Text Text Week 7 Text Text Text Text \n " +
				"Text Text Text Week 7 Text Text Text Text \n" +
				"Text Text Text Week 7 Text Text Text Text \n" +
				"Text Text Text Week 7 Text Text Text Text \n" +
				"Text Text Text Week 7 Text Text Text Text \n";
			Label WeekLabel = new Label {
				Text="Week 7",
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};
			Label messageLabel = new Label { 
				Text=msg,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};


//			this.ItemsSource = new PregnancyWeekly[] 
//			{
//				new PregnancyWeekly("week1", msg),
//				new PregnancyWeekly("week2", msg),
//				new PregnancyWeekly("week3", msg),
//				new PregnancyWeekly("week4", msg),
//				new PregnancyWeekly("week5", msg),
//				new PregnancyWeekly("week6", msg)
//			};
//
//			this.ItemTemplate = new DataTemplate(() =>
//				{
//					return new PregnancyWeeklyPage(true);
//				});
//			this.SelectedItem = ((PregnancyWeekly[])ItemsSource) [2];

			Content = new  StackLayout{
				Children = {
					WeekLabel,
					messageLabel
				}

			};
		}
	}
}

