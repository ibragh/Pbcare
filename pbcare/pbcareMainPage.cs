using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public partial class pbcareMainPage : TabbedPage
	{
		public pbcareMainPage ()
		{
			
		}

		protected override void OnAppearing ()
		{
			this.Children.Add (new NavigationPage (new PregnancyPage ()){ Title = "حملي", Icon = "MyPregnancy.png" });
			this.Children.Add (new NavigationPage (new BabyPage ()){ Title = "أطفالي", Icon = "MyBaby.png" });
			this.Children.Add (new NavigationPage (new WebsitePage ()){ Title = "المنتدى", Icon = "Setting.png" });
			if (Device.OS == TargetPlatform.Android && pbcareApp.u.isSensorOn == 1) {
				this.Children.Add (new NavigationPage (new arduino_bt ()){ Title = "جهاز الإستشعار", Icon = "Setting.png" });
			}

			this.Children.Add (new NavigationPage (new SettingPage ()){ Title = "الإعدادات", Icon = "Setting.png" });

			base.OnAppearing ();
		}

	}
}
