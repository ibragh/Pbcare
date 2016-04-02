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
			int CurrentWeek = pbcareApp.CurrentWeek (pbcareApp.FinaldueDate);

			string[] info = new string[41];
			for (int i = 1; i < info.Length; i++) {
				// get the pregnancy weekly info from local database
				info [i] = pbcareApp.Database.InsertIntoPregnancyWeekly (i);
			}
			PregnancyWeekly[] pregnancyWeek = new PregnancyWeekly[41];
			for (int i = 1; i < pregnancyWeek.Length; i++) {
				pregnancyWeek[i] = new PregnancyWeekly("الأسبوع "+i,info [i]);
			}
			this.ItemsSource =pregnancyWeek;

			this.ItemTemplate = new DataTemplate (() => {
				return new PregnancyWeeklyPage (); // ContentPage
			});
			// selected week .. so her preganncy week will
			// be the first screen will appear 
			this.SelectedItem = ((PregnancyWeekly[])ItemsSource); // it needs change
		//	this.CurrentPage = this.Children[9];

		}

	}
}

