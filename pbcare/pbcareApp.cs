using System;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace pbcare
{
	
	public class pbcareApp : Application
	{
		public static bool IsUserLoggedIn { get; set; }

		public static DateTime FinaldueDate  { get; set; } 
		public static NavigationPage n;
		public static User u = new User ();
		static DatabaseClass database;
		public static DatabaseClass Database {
			get { 
				if (database == null) {
					database = new DatabaseClass ();
				} 
				return database;

			}
		}

		public static INavigation MyNavigation { get; set; }

		public static Page GetMainPage ()
		{
			var p = new pbcareMainPage ();
			var c = new NavigationPage (p);
			MyNavigation = p.Navigation;
			return p;
		}

		public pbcareApp ()
		{
			MainPage = new NavigationPage(new LogInPage ());
		}


		protected override void OnStart ()
		{
			// Handle when your app starts

		}
			

		protected override void OnSleep ()
		{
			
		}

		protected override void OnResume ()
		{
			
		}
	}
}

