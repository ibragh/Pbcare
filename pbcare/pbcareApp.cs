using System;
using Xamarin.Forms;

namespace pbcare
{
	
	public class pbcareApp : Application
	{
		public static INavigation MyNavigation { get; private set; }

		public static Page GetMainPage ()
		{
			var p = new pbcareMainPage ();
			MyNavigation = p.Navigation;
			return p;
		}

		public static bool IsUserLoggedIn { get; set; }

		public static User u = new User ();

		public pbcareApp ()
		{
			IsUserLoggedIn = true;
			MainPage = GetMainPage ();
		}



		static DatabaseClass database;

		public static DatabaseClass Database {
			get { 
				if (database == null) {
					database = new DatabaseClass ();
				} 
				return database;

			}
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

