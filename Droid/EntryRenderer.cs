using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using pbcare.Droid;

[assembly: ExportRenderer (typeof(Entry), typeof(MyEntryRenderer))]

namespace pbcare.Droid
{
	class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.SetBackgroundColor (global::Android.Graphics.Color.Argb(200,185,185,185));
			}
		}
	}
}


