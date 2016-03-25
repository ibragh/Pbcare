using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using System.IO;
using SQLite;
using System.Diagnostics;

namespace pbcare.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif


			global::Xamarin.Forms.Forms.Init ();

			Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.StyleId) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
				}
			};

			// TODO - set the StyleId of views here.

			LoadApplication (new pbcareApp ());

			return base.FinishedLaunching (app, options);
		}

		public override void ReceivedLocalNotification (UIApplication application, UILocalNotification notification)
		{
			Debug.WriteLine ("Location Notification: {0}:{1}", notification.AlertAction, notification.AlertBody);
			//Debug.WriteLine("Location Notification: " + notification.AlertBody);

			if (UIApplication.SharedApplication.ApplicationState == UIApplicationState.Active) {
				new UIAlertView (notification.AlertAction, notification.AlertBody, null, "OK", null).Show ();

				//var alert = UIAlertController.Create(notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
				//UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
			}
		}


		public override void HandleAction (UIApplication application, string actionIdentifier, NSDictionary remoteNotificationInfo, Action completionHandler)
		{
			if (UIApplication.SharedApplication.ApplicationState == UIApplicationState.Active)
				new UIAlertView ("Notification Action", actionIdentifier, null, "OK", null).Show ();
			else
				Console.WriteLine ("Notification Action {0}", actionIdentifier);

			base.HandleAction (application, actionIdentifier, remoteNotificationInfo, completionHandler);
		}
	}
}

