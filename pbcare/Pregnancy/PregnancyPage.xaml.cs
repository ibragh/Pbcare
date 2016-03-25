using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Acr.Notifications;

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


			Navigation.PushAsync (new FollowPregnancy ());
		}

		public void FollowFetusByImagesClicked (object sender, EventArgs e)
		{
			// Only for testing
			sendNotification ();
			Navigation.PushAsync (new FollowFetusByImages ());
		}

		public void FollowFetusWeeklyClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new FollowFetusWeekly ());
		}

		public int Now_Week ()
		{
			int n = 0;
			DateTime.Now.AddDays (7).ToString ("dd.MM.yy");
			return n;
		}

		public void sendNotification ()
		{
			Notifications.Instance.Send ("ABC", "I got a notification", when: TimeSpan.FromSeconds (20));

		}
	}
}

