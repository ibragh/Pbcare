using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support;
using Xamarin.Forms.Platform.Android;


namespace pbcare.Droid
{
	// Show the splash screen
//	[Activity(Theme = "@style/Theme.Splash",  MainLauncher = true, NoHistory = true, 
//		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]              
//	public class SplashActivity : Activity
//	{
//		protected override void OnCreate(Bundle bundle)
//		{
//			base.OnCreate(bundle);
//			System.Threading.Thread.Sleep(1000); 
//			this.StartActivity(typeof(MainActivity));
//		}
//	}

	[Activity (Label = "pbcare.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize |
		ConfigChanges.Orientation, WindowSoftInputMode = SoftInput.AdjustResize)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			// Must be called before base.OnCreate (bundle);
//			FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;
//			FormsAppCompatActivity.TabLayoutResource = Resource.Layout.TabLayout;

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => {
				if (!string.IsNullOrWhiteSpace (e.View.StyleId)) {
					e.NativeView.ContentDescription = e.View.StyleId;
				}
			};

			LoadApplication (new pbcareApp ());
		}

		public override void OnBackPressed ()
		{
			// This prevents a user from being able to hit the back button and leave the login page.
			if (pbcareApp.IsUserLoggedIn) {
				base.OnBackPressed ();
			}
		}
	}
}

