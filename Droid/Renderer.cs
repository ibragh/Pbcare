using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using pbcare.Droid;
using pbcare;

[assembly: ExportRenderer (typeof(Entry1), typeof(Entry_1))]
[assembly: ExportRenderer (typeof(Entry2), typeof(Entry_2))]
namespace pbcare.Droid
{
	class Entry_1 : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.SetBackgroundColor (global::Android.Graphics.Color.Argb(80,184,228,241));
			}
		}
	}


	class Entry_2 : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.SetBackgroundColor (global::Android.Graphics.Color.Argb(80,184,228,241));
			}
		}
	}


}

