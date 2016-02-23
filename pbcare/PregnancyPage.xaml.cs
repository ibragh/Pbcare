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

		public void addPregnancy (object sender, EventArgs e)
		{
			Navigation.PushAsync (new AddPregnancy ());
		}

		public void followPregnancy (object sender, EventArgs e)
		{
			var FollowPregnancy = new CarouselPage ();
			FollowPregnancy.Title = " أسابيع الحمل";



			FollowPregnancy.Children.Add (new Week1());
			FollowPregnancy.Children.Add (new Week2());
			FollowPregnancy.Children.Add (new Week3());
			FollowPregnancy.Children.Add (new Week4());
			FollowPregnancy.Children.Add (new Week5());
			FollowPregnancy.Children.Add (new Week6());
			FollowPregnancy.Children.Add (new Week7());
			FollowPregnancy.Children.Add (new Week8());
			FollowPregnancy.Children.Add (new Week9());
			FollowPregnancy.Children.Add (new Week10());

			Navigation.PushAsync (FollowPregnancy);
		}

		public void FetusImages (object sender , EventArgs e){
		
			Navigation.PushAsync (new FetusImages ());
		}

		public void followFetus (object sender, EventArgs e)
		{
			var FollowFetusByWeek = new CarouselPage ();
			FollowFetusByWeek.Title = "الجنين";



			FollowFetusByWeek.Children.Add (new Week1());
			FollowFetusByWeek.Children.Add (new Week2());
			FollowFetusByWeek.Children.Add (new Week3());
			FollowFetusByWeek.Children.Add (new Week4());
			FollowFetusByWeek.Children.Add (new Week5());
			FollowFetusByWeek.Children.Add (new Week6());
			FollowFetusByWeek.Children.Add (new Week7());
			FollowFetusByWeek.Children.Add (new Week8());
			FollowFetusByWeek.Children.Add (new Week9());
			FollowFetusByWeek.Children.Add (new Week10());

			Navigation.PushAsync (FollowFetusByWeek);
		}
	}
}

