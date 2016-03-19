using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using System.IO;
using SQLite;

namespace pbcare.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif


			global::Xamarin.Forms.Forms.Init();

			Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.StyleId) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
				}
			};

			// TODO - set the StyleId of views here.

			LoadApplication(new pbcareApp());

			return base.FinishedLaunching(app, options);
		}
	}
}

