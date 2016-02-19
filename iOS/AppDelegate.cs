using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

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

			// TODO - set the StyleId of views here.

			LoadApplication(new pbcareApp());

			return base.FinishedLaunching(app, options);
		}
	}
}

