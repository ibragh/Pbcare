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
//				MainPage = new NavigationPage (new MyPage ());
//			}
			MainPage = new MyPage();

			/*     00000000    Importent 0000000
			 * We need to handle Android physical back button 
			 * bcz it make the app stopped if it pressed
			 * in the main page (MyPage.cs)
			 */
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

