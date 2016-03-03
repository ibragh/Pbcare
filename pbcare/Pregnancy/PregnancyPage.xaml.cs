using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace pbcare
{
	public partial class PregnancyPage : ContentPage
	{
		public PregnancyPage ()
		{
			InitializeComponent ();
		}

		public void AddPregnancyClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new AddPregnancyPage ());
		}

		public void FollowPregnancyWeeklyClicked (object sender, EventArgs e)
		{


			Navigation.PushAsync ( new FollowPregnancy());
		}

		public void FollowFetusByImagesClicked (object sender , EventArgs e){

			Navigation.PushAsync (new FollowFetusByImages ());
		}

		public void FollowFetusWeeklyClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new FollowFetusWeekly ());
		}
	}
}

