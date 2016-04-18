using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using pbcare.Droid;
using pbcare;

[assembly: ExportRenderer (typeof(Entry1), typeof(Entry_1))]
[assembly: ExportRenderer (typeof(DatePicker1), typeof(DatePicker_1))]
[assembly: ExportRenderer (typeof(Picker1), typeof(Picker_1))]


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
		

	class DatePicker_1 : DatePickerRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.SetBackgroundColor (global::Android.Graphics.Color.Argb(80,184,228,241));
				Control.SetTextColor(global::Android.Graphics.Color.Argb(255,80,105,161));

			}
		}
	}

	class Picker_1 : PickerRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.SetBackgroundColor (global::Android.Graphics.Color.Argb(80,184,228,241));
				Control.SetTextColor(global::Android.Graphics.Color.Argb(255,80,105,161));

			}
		}
	}


}

