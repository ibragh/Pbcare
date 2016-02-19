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
			var page = new CarouselPage ();
			page.Title = "whatever";



			page.Children.Add (new Week10());
			page.Children.Add (new Week2());
			page.Children.Add (new Week3());
			page.Children.Add (new Week4());
			page.Children.Add (new Week5());
			page.Children.Add (new Week6());
			page.Children.Add (new Week7());
			page.Children.Add (new Week8());
			page.Children.Add (new Week9());
			page.Children.Add (new Week1());

			Navigation.PushAsync (page);
		}
	}
}

