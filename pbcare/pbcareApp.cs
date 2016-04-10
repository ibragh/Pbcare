using System;
using Xamarin.Forms;
using System.Diagnostics;

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

		public static DateTime FinaldueDate { get; set; }

		public static User u = new User ();

		/* Calculate Current Week */
		public static int CurrentWeek (DateTime dueDate)
		{
			TimeSpan difference = dueDate - DateTime.Now.AddDays (-1);
			// for calculating the past days of pregnancy
			double PastDays = (280 - (int)difference.TotalDays); 
			return (int)Math.Ceiling (PastDays / 7);

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

