using System;
using Xamarin.Forms;

namespace pbcare
{
	
	public class pbcareApp : Application
	{
		public static bool IsUserLoggedIn { get; set;}
		public static User u = new User ();
		public pbcareApp ()
		{
			MainPage = new MyPage ();
		}
			
		static DatabaseClass db;
		public static DatabaseClass DB {
			get { 
				if (db == null) {
					db = new DatabaseClass ();
				} 
				return db;

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

