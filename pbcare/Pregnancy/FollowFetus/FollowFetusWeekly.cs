using System;

using Xamarin.Forms;

namespace pbcare
{
	public class FollowFetusWeekly :  CarouselPage
	{
		public FollowFetusWeekly()
		{
			this.Title = "Fetus Weekly";
			string msg = "bla bla bla bla sdfshfghgfhfg \n hj";


			this.ItemsSource = new PregnancyWeekly[] 
			{
				new PregnancyWeekly("week1", msg),
				new PregnancyWeekly("week2", msg),
				new PregnancyWeekly("week3", msg),
				new PregnancyWeekly("week4", msg),
				new PregnancyWeekly("week5", msg),
				new PregnancyWeekly("week6", msg)
			};

			this.ItemTemplate = new DataTemplate(() =>
				{
					return new PregnancyWeeklyPage(true);
				});
			this.SelectedItem = ((PregnancyWeekly[])ItemsSource) [2];
		}
	}
}

