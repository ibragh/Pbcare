using System;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;

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

		public static DateTime FinaldueDate  { get; set; } 

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
			
		protected override void OnStart ()
		{
			// Handle when your app starts

		}
			

		protected override void OnSleep ()
		{
			// Only for Android
			if (Device.OS == TargetPlatform.Android) {
				DependencyService.Get<IAudio> ().StopMP3File ();
				//DependencyService.Get<IBth> ().Cancel ();
			} 
		}

		protected override void OnResume ()
		{
			// Only for Android
			if (Device.OS == TargetPlatform.Android) {
				//DependencyService.Get<IBth> ().Start ("HC-06");
			} 

		}
	}
}

