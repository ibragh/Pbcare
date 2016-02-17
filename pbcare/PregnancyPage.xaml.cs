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
            var page = new CarouselPage();
            page.Title = "أسابيع الحمل";

            page.Children.Add(new page1());
            page.Children.Add(new page2());
            page.Children.Add(new page3());
            page.Children.Add(new page4());
          
        }
	}
}

