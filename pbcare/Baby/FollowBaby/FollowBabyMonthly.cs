using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class FollowBabyMonthly : CarouselPage
	{
		public FollowBabyMonthly (Baby c )
		{
			this.Title = "متابعة الطفل الشهرية";
			BackgroundColor = Color.FromRgb (197, 255, 255);

			int CurrentMonth = BabyPage.CurrentMonth (c.birthDate);

			string[] info = new string[13];
			for (int i = 1; i < info.Length; i++) {
				// get the Baby monthly info from local database
				info [i] = pbcareApp.Database.getChildMonth (i);
			}
			BabyMonthly[] BabyMonth = new BabyMonthly[13];
			BabyMonth[0] = new BabyMonthly(c.ChildName ,CurrentMonth+" شهر ");

			for (int i = 1; i < BabyMonth.Length; i++) {
				BabyMonth[i] = new BabyMonthly(" الشهر "+ i ,info [i]);
			}
				
			this.ItemsSource = BabyMonth;
			this.ItemTemplate = new DataTemplate (typeof(BabyMonthlyPage));

			this.SelectedItem = ((BabyMonthly[])ItemsSource);
		}

	}
}

