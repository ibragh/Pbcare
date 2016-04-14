
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using pbcare;
using pbcare.iOS;

[assembly: ExportRenderer (typeof(Entry1), typeof(Entry_1))]
namespace pbcare.iOS
{
	public class Entry_1 : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				// do whatever you want to the UITextField here!
				Control.BackgroundColor = UIColor.FromRGBA (184,228,241,80);

			}
		}
	}
}

