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
		public void addPregnancy(object sender, EventArgs e){
			Navigation.PushAsync(new AddPregnancy ());
		}
		public void followPregnancy(object sender, EventArgs e){
			
//			var page = new CarouselPage();
//			page.Title = " whatever";
//			var p1 = new page1 ();
//			var p2 = new page2 ();
//			page.Children.Add (p1);
//			page.Children.Add (p2);
//			Navigation.PushAsync (page);
		}

	}
}

