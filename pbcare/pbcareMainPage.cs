using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public partial class pbcareMainPage : TabbedPage
	{
		public pbcareMainPage ()
		{
			this.Children.Add (new NavigationPage (new PregnancyPage ()){ Title = "حملي", Icon = "MyPregnancy.png" });
			this.Children.Add (new NavigationPage (new BabyPage ()){ Title = "أطفالي", Icon = "MyBaby.png" });
			this.Children.Add (new NavigationPage (new WebsitePage ()){ Title = "المنتدى", Icon = "Setting.png" });
			// Show Ardunio Page Handler ONLY --- For Android Devices
			if (Device.OS == TargetPlatform.Android) {
				this.Children.Add (new NavigationPage (new arduino_bt ()){ Title = "جهاز الإستشعار", Icon = "Setting.png" });
			}
			this.Children.Add (new NavigationPage (new SettingPage ()){ Title = "الإعدادات", Icon = "Setting.png" });

		}

		protected override void OnAppearing ()
		{

			// when showing this window, if the Login hasn't been done, show
			// the login screen...
			if (!pbcareApp.IsUserLoggedIn && !pbcareApp.Database.checkUserLoggedin ()) {
				Navigation.PushModalAsync (new NavigationPage (new LogInPage ()));
			}

			base.OnAppearing ();
		}
	}
}
