using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class FollowBabyMonthly : CarouselPage
	{
		public FollowBabyMonthly ()
		{
			this.Title = "متابعة الطفل الشهرية";
			BackgroundImage = "mainPB.jpg";

			//int CurrentWeek = pbcareApp.CurrentWeek (pbcareApp.FinaldueDate);

//			string[] info = new string[41];
//			for (int i = 1; i < info.Length; i++) {
//				// get the Baby monthly info from local database
//				info [i] = pbcareApp.Database.InsertIntoPregnancyWeekly (i);
//			}
//			BabyMonthly[] BabyMonth = new BabyMonthly[41];
//			for (int i = 1; i < BabyMonth.Length; i++) {
//				BabyMonth[i] = new PregnancyWeekly("الأسبوع "+i,info [i]);
//			}
//			this.ItemsSource =BabyMonth;
//
//			this.ItemTemplate = new DataTemplate (() => {
//				return new PregnancyWeeklyPage (); // ContentPage
//			});
//			this.SelectedItem = ((PregnancyWeekly[])ItemsSource); 
//			;

		}

	}
}

