using System;
using Acr.Notifications;
using Xamarin.Forms;

namespace pbcare
{
	public class arduino_bt : ScrollView
	{
		
		public arduino_bt ()
		{
			Label header = new Label {
				Text = "Switch",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center

			};

			Switch switcher = new Switch {IsToggled = false};

			Label label = new Label {
				Text = "Switch is now False",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			switcher.Toggled += (object sender, ToggledEventArgs e) => {
				try {
					
				
					if (e.Value) {
						//MessagingCenter.Subscribe<App, string> (this, "Barcode", (sender, arg) => Device.BeginInvokeOnMainThread (() => _l.Text = arg));
						Notifications.Instance.Send ("Warning", "There has been movment", Notification.DefaultSound, when: TimeSpan.FromSeconds (1));
						DependencyService.Get<IAudio> ().PlayMp3File ("test.mp3");
						//DependencyService.Get<IBth> ().Start ("HC-06");
					
					} else {
						DependencyService.Get<IAudio> ().StopMP3File ();
						//DependencyService.Get<IBth> ().Cancel ();
					}
				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine (ex.Message);
				}
			};



			// Accomodate iPhone status bar.
			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					header,
					switcher,
					label
				}
			};
		}


	}
}
