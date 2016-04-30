using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class FollowPregnancy : CarouselPage
	{
		public FollowPregnancy ()
		{
			this.Title = "متابعة الحمل الأسبوعي";
			BackgroundColor = Color.FromRgb (197, 255, 255);


			int CurrentWeek = PregnancyPage.CurrentWeek(pbcareApp.FinaldueDate);
			string[] info;
			if (CurrentWeek >= 30) {
				info = new string[40 -(CurrentWeek - 1)];
			} else {
				info = new string[10];
			}

			int temp = CurrentWeek; 
			int i = 0;
			while(i < info.Length){
				info [i] = pbcareApp.Database.getPregnancyWeeks(temp);
				temp++;
				i++;
			}

			WeeklyInfo[] pregnancyWeek;
			if (CurrentWeek >= 30) {
				pregnancyWeek = new WeeklyInfo[40 -(CurrentWeek - 1)];

			} else {
				pregnancyWeek = new WeeklyInfo[10];
			}

			int temp2 = CurrentWeek; 
			int j = 0;
			while(j < pregnancyWeek.Length){
				pregnancyWeek[j] = new WeeklyInfo("الأسبوع "+temp2 ,info[j]);
				temp2++;
				j++;
			}


			this.ItemsSource =pregnancyWeek;
			this.ItemTemplate = new DataTemplate (typeof(WeeklyInfoPage));
			// selected week .. so the fetus week will
			// be the first screen will appear 
			this.SelectedItem = ((WeeklyInfo[])ItemsSource);
		}

	}
}

