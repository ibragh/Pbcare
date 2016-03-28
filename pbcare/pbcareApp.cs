using System;
using Xamarin.Forms;

namespace pbcare
{
	
	public class pbcareApp : Application
	{
		public static INavigation MyNavigation { get; set; }

		public static Page GetMainPage ()
		{
			var p = new pbcareMainPage ();
			MyNavigation = p.Navigation;
			return p;
		}

		public pbcareApp ()
		{

			MainPage = GetMainPage ();
		}

		public static bool IsUserLoggedIn { get; set; }
		public static DateTime FinaldueDate { get; set;}
		public static User u = new User ();
		/*Calculate Current Week*/
		public static int CurrentWeek(){
			TimeSpan difference = pbcareApp.FinaldueDate - DateTime.Now ;
			int days =( 280 - (int) difference.TotalDays) +1;

			int i;
			for (i=0; i < 280; i=i+7) {
				for (int j = i; j <= (i+7); j++) {
					if (days == j) {
						return i / 7;
					}
				}
			}
			return i/7;

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

