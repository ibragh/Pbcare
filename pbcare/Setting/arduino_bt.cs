﻿// ToDo: 	1- Info Button for handling Error Connection
// 			2- ContentPage With the Scanned Devices. So Connect Whatever I Want
using System;
using Acr.Notifications;
using Xamarin.Forms;
using System.Collections.Generic;

/* ---Masseage Center----- 
"0", "bluetooth task is canceled"
"1", "There is Movement Detected"
"2", "Bluetooth Is NOT Connected.
"3", "Bleutooth Connected"
"4", "Named device not found"
"5", "Bluetooth adapter is not enabled."
"6", "No Bluetooth adapter found."
*/
namespace pbcare
{
	
	public class arduino_bt : ContentPage
	{
		Boolean IsSoundOn;

		public arduino_bt ()
		{
			Title = "جهاز الإستشعار";
			BackgroundColor = Color.FromRgb (94, 196, 225);

			Label header = new Label {
				Text = "تشغيل",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.End
			};
			Switch switcher = new Switch {};
			Label msg = new Label {
				Text = "Use The Switch To Turn ",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			Button StopSound = new Button {
				Text = "إيقاف الصوت",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 50 ,
				//HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			StopSound.Clicked += (object sender, EventArgs e) => {
				// only stop sound in case it is Playing
				if(!IsSoundOn){
					DependencyService.Get<IAudio> ().StopAlarm ();
					switcher.IsToggled = false;
				}
				msg.Text ="Sound has Stopped";
			};

			MessagingCenter.Subscribe<pbcareApp, string> (this, "0", (mysender, arg) => {
				System.Diagnostics.Debug.WriteLine ("MessagingCenter.Subscribe 0: " + arg);
				msg.Text = arg;
				DependencyService.Get<IAudio> ().StopAlarm ();
			});
			MessagingCenter.Subscribe<  pbcareApp, string> (this, "1", (mysender, arg) => {

				try {
					Device.BeginInvokeOnMainThread (() => {
						if (IsSoundOn) {
							msg.Text = arg;
							IsSoundOn = false;
							DependencyService.Get<IAudio> ().PlayAlarm ();
							this.DisplayAlert ("تنـــــبـــيه", "يوجد حركة عند حساس الباب", "حسناً");
						}
					});
				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine ("MessagingCenter.Subscribe 1: " + ex.Message);
				}

			});
			MessagingCenter.Subscribe<  pbcareApp, string> (this, "2", (mysender, arg) => {

				Device.BeginInvokeOnMainThread (() => {
					msg.Text = arg ;
				});

			});
			MessagingCenter.Subscribe<  pbcareApp, string> (this, "3", (mysender, arg) => {
				Device.BeginInvokeOnMainThread (() => {
					msg.Text = arg;
				});

			});
			MessagingCenter.Subscribe<  pbcareApp, string> (this, "4", (mysender, arg) => {
				Device.BeginInvokeOnMainThread (() => {
					msg.Text = arg;
					//this.DisplayAlert ("Warning", arg , "OK");
				});

			});
			MessagingCenter.Subscribe<  pbcareApp, string> (this, "5", (mysender, arg) => {
				Device.BeginInvokeOnMainThread (() => {
					msg.Text = arg;
					//this.DisplayAlert ("Warning", arg, "OK");
				});

			});
			MessagingCenter.Subscribe<  pbcareApp, string> (this, "6", (mysender, arg) => {
				Device.BeginInvokeOnMainThread (() => {
					msg.Text = arg;
					//this.DisplayAlert ("Warning", arg, "OK");
				});

			});

			switcher.Toggled += (object sender, ToggledEventArgs e) => {

				try {
					if (e.Value) {
						IsSoundOn = true;
						DependencyService.Get<IBth> ().Start ("HC-06");
					} else {
						DependencyService.Get<IBth> ().Cancel();
						// only stop sound in case it is Playing
						if(!IsSoundOn){
							DependencyService.Get<IAudio> ().StopAlarm ();
						}
						msg.Text ="bluetooth task is canceled";

					}
				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine ("Toggled Switch: " + ex.Message);
				}
			};
			// Accomodate iPhone status bar.
			this.Padding = new Thickness (10 , Device.OnPlatform (20, 30, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					header,
					switcher,
					StopSound,
					msg,
				}
			};
		}


	}
}
