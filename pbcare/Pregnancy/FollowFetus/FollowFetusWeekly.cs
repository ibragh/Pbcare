using System;

using Xamarin.Forms;

namespace pbcare
{
	public class FollowFetusWeekly :  CarouselPage
	{
		public FollowFetusWeekly()
		{
			this.Title = "Fetus Weekly";

			this.Children.Add (new FetusWeeklyTry (5));
			this.Children.Add (new FetusWeeklyTry (1));
			this.Children.Add (new FetusWeeklyTry (2));
			this.Children.Add (new FetusWeeklyTry (1));
			this.Children.Add (new FetusWeeklyTry (5));

			this.CurrentPage = this.Children [2];

		}
	}
}

