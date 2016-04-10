using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace pbcare
{
	public partial class pbcareMainPage : TabbedPage
	{
		public pbcareMainPage ()
		{
			BackgroundImage = "back2.png";
			InitializeComponent ();
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
