using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class FollowPregnancy : CarouselPage
	{
		public FollowPregnancy ()
		{
			this.Title = "PregnancyWeekly";


			//var CurrentWeek = DateTime.Now.Subtract (pbcareApp.FinaldueDate);


			string[] info = new string[41];
			for (int i = 1; i < info.Length; i++) {
				info [i] = pbcareApp.Database.InsertIntoPregnancyWeekly (i);
			}

			PregnancyWeekly[] d = new PregnancyWeekly[41];
			for (int i = 1; i < d.Length; i++) {
				d[i] = new PregnancyWeekly("Week "+i,info [i]);
			}
			
			this.ItemTemplate = new DataTemplate (() => {
				return new PregnancyWeeklyPage (); // ContentPage
			});
			this.ItemsSource =d;

			this.SelectedItem = ((PregnancyWeekly[])ItemsSource) [pbcareApp.CurrentWeek()];
		}

	}
}

