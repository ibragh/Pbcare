using System;

using Xamarin.Forms;

namespace pbcare
{
	public class pbcareApp : Application
	{
		public static bool IsUserLoggedIn { get; set;}
		public pbcareApp ()
		{
//			if (!IsUserLoggedIn) {
//				MainPage = new NavigationPage (new LoginPage ());
//			} else {
//				MainPage = new NavigationPage (new MainPage ());
//			}
			MainPage = new MyPage();
		}
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

