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


			int CurrentWeek = pbcareApp.CurrentWeek (pbcareApp.FinaldueDate);

			string[] info = new string[41];
			for (int i = 1; i < info.Length; i++) {
				
				// get the pregnancy weekly info from local database
				info [i] = pbcareApp.Database.InsertIntoPregnancyWeekly (i);
			}
			WeeklyInfo[] pregnancyWeek = new WeeklyInfo[41];
			for (int i = 1; i < pregnancyWeek.Length; i++) {
				pregnancyWeek[i] = new WeeklyInfo("الأسبوع "+i,info [i]);
			}
			this.ItemsSource =pregnancyWeek;
			this.ItemTemplate = new DataTemplate (typeof(WeeklyInfoPage));
			// selected week .. so her preganncy week will
			// be the first screen will appear 
			this.SelectedItem = ((WeeklyInfo[])ItemsSource); // it needs change
		//	this.CurrentPage = this.Children[9];


		}

	}
}

