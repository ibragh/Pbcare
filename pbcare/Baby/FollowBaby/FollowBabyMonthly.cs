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

			string[] info = new string[12 -(CurrentMonth-1)];

			int temp = CurrentMonth; 
			int i = 0;
			while(i < info.Length){
				info [i] = pbcareApp.Database.getChildMonth(temp);
				temp++;
				i++;
			}
				
			BabyMonthly[] BabyMonth = new BabyMonthly[12- (CurrentMonth - 1)];
			int temp2 = CurrentMonth; 
			int j = 0;
			while(j < info.Length){
				BabyMonth[j] = new BabyMonthly(" الشهر "+ temp2 ,info [j]);
				temp2++;
				j++;
			}

			this.ItemsSource = BabyMonth;
			this.ItemTemplate = new DataTemplate (typeof(BabyMonthlyPage));

			this.SelectedItem = ((BabyMonthly[])ItemsSource);
		}

	}
}

