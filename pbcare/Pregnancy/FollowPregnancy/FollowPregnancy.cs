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
			int check = CurrentWeek + 10;
			if (check > 40) {
				check = check - 40;
				if (check == 10) {
					check = 9;
				}
				info = new string[10 - check];
			} else {
				info = new string[10];
			}

			int message = CurrentWeek; 
			int i = 0;
			while(i < info.Length){
				info [i] = pbcareApp.Database.getPregnancyWeeks(message);
				message++;
				i++;
			}

			WeeklyInfo[] pregnancyWeek;
			int check2 = CurrentWeek + 10;
			if (check2 > 40) {
				check2 = check2 - 40;
				if (check2 == 10) {
					check = 9;
				}
				pregnancyWeek = new WeeklyInfo[10 - check2];
			} else {
				pregnancyWeek = new WeeklyInfo[10];
			}

			int img2 = CurrentWeek; 
			int j = 0;
			while(j < pregnancyWeek.Length){
				pregnancyWeek[j] = new WeeklyInfo("الأسبوع "+img2,info[j]);
				img2++;
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

