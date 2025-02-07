﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using Acr.Notifications;

namespace pbcare
{
	public class SettingPage : ContentPage
	{
		ListView setting = new ListView {
			RowHeight = 50  
		};
		List<settingClass> settingList = new List<settingClass> ();	
		Label sensorStatus = new Label{
			FontAttributes = FontAttributes.Bold,
			FontSize = Device.GetNamedSize(NamedSize.Small,typeof(Label)),
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.CenterAndExpand,
		};
		bool Locked = false ;
		public SettingPage ()
		{
			StyleId = "SettingPage";
			Title = "الإعدادات";
			BackgroundColor = Color.FromRgb (94, 196, 225);
			settingClass sensor_on;
			sensor_on = new settingClass ("جهاز الإستشعار", 3);

			settingList.Add (new settingClass ("تغيير الاسم", 1));
			settingList.Add (new settingClass ("تغيير كلمة المرور", 2));
			if (Device.OS == TargetPlatform.Android) {
				settingList.Add (sensor_on);
			}
			settingList.Add (new settingClass ("عن تطبـيقنا",4));

			setting.ItemsSource = settingList;
			setting.ItemTemplate = new DataTemplate (typeof(everyCell));
			setting.BackgroundColor = Color.Transparent;
			setting.SeparatorColor = Color.White;
			setting.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null; 
			};
			setting.ItemTapped += (Sender, Event) => {
				if(!Locked)
				{
				Locked = true;
				var selceted = (settingClass)Event.Item;
				if(selceted.number == 3){
					sensor_Confirm();

				}else{
					var settingView = new settingView (selceted);
					Navigation.PushAsync (settingView);
				}
				}
			};

			var logOutButton = new Button {
				Text = " تسجيل خــــروج ",
				Image = "logOut.png",
				TextColor = Color.White,
				FontSize = 15,
				WidthRequest = 200,
				HeightRequest = 65,
				BackgroundColor = Color.Red,
				VerticalOptions = LayoutOptions.End,
				FontAttributes = FontAttributes.Bold,
				BorderRadius = 30,
				StyleId = "LogoutButton"
			};

			logOutButton.Clicked += OnAlertYesNoClicked;

			if (Device.OS == TargetPlatform.Android) {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = new Thickness (10, 20, 10, 53),
					Children = {  
						setting,
						sensorStatus,
						logOutButton
					}
				};
			}else{
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = new Thickness (10, 20, 10, 53),
					Children = {  
						setting,
						logOutButton
					}
				};
			}
		}

		async void OnAlertYesNoClicked (object sender, EventArgs e)
		{
			if(!Locked){
				Locked = true;
				var answer = await DisplayAlert ("تسجيل الخروج ", "هل تريد تأكيد تسجيل الخروج ؟ ", "نعم", "لا");
				if (answer == true) {
					pbcareApp.Database.User_Loggedin (false);
					pbcareApp.IsUserLoggedIn = false; 
					pbcareApp.u.isPregnant = 0;
					pbcareApp.u.Email = null;
					Application.Current.MainPage = new NavigationPage (new LogInPage ());
				} else {
					Locked = false; 
				}
			} 
		}

		async void sensor_Confirm(){
			if (pbcareApp.u.isSensorOn == 0) {
				var answer = await DisplayAlert ("تفعيل جهاز الإستشعار؟", "هل تريد تفعيل جهاز الإستشعار ؟", "نعم", "لا");
				if (answer) {
					pbcareApp.u.isSensorOn = 1;
					pbcareApp.Database.updateSensorOn (1);
					sensorStatus.Text = "جهاز الإستشعار مفعل";
					sensorStatus.TextColor = Color.White;
					Application.Current.MainPage = new pbcareMainPage ();
				}
			}else{
				var answer = await DisplayAlert ("تفعيل جهاز الإستشعار؟", "هل تريد إلغاء تفعيل جهاز الإستشعار ؟", "نعم", "لا");
				if (answer) {
					pbcareApp.u.isSensorOn = 0;
					pbcareApp.Database.updateSensorOn (0);
					sensorStatus.Text = "جهاز الاستشعار غير مفعل";
					sensorStatus.TextColor = Color.Red;
					Application.Current.MainPage = new pbcareMainPage ();
				}
			}
			Locked = false; 
		}
			
		protected override void OnAppearing (){
			Locked = false; 
			if (pbcareApp.u.isSensorOn == 1 && pbcareApp.IsUserLoggedIn == true) {
				sensorStatus.Text = "جهاز الإستشعار مفعل";
				sensorStatus.TextColor = Color.White;
			} else if(pbcareApp.u.isSensorOn == 0 && pbcareApp.IsUserLoggedIn == true){
				sensorStatus.Text = "جهاز الإستشعار غير مفعل";
				sensorStatus.TextColor = Color.Red;
			}
			base.OnAppearing ();
		}
	}

	//--------------------------------------------------------------
	public class settingClass
	{
		public string name { get; set; }

		public int number { get; set; }

		public settingClass (string n, int num)
		{
			this.name = n;
			this.number = num;
		}
	}
	//===========================================================
	public class everyCell : ViewCell
	{
		public everyCell ()
		{
			
			var name = new Label {
				Text = " . ",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,


			};
			name.SetBinding (Label.TextProperty, "name");

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				Padding = new Thickness (15, 5, 15, 15),

				Children = {
					new StackLayout {
						Padding = new Thickness (15, 5, 0, 15),
						Orientation = StackOrientation.Vertical,
						HorizontalOptions = LayoutOptions.EndAndExpand,
						Children = { name 
						},


					}
				}
			};
		}
	}

	//-------------------------------------------------------------

	public class settingView : ContentPage
	{
		bool Locked = false ;

		public settingView (settingClass selectedSetting)
		{
			BackgroundColor = Color.FromRgb (94, 196, 225);
			Title = selectedSetting.name;

			var CancelButton = new Button {
				Text = "إلغاء",
				TextColor = Color.FromHex ("#FFFFFF"),
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex ("#FFA4C1"),
				BorderColor = Color.FromHex ("#FFA4C1"),
				HeightRequest = 50,
			};

			CancelButton.Clicked += (sender, e) => {
				Navigation.PopAsync ();
			};
			// ------------ Setting Cell Number 1
			if (selectedSetting.number == 1) {
				var yourname = new Label {
					Text = "اسمك : ",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.End,
					TextColor = Color.White
				};

				var nameEntry = new Entry1 { 
					Placeholder = "أدخل اسمك هنا" ,
					PlaceholderColor = Color.White,
					TextColor = Color.FromHex("#5069A1"),
				};
				var saveNameButton = new Button { 
					Text = " حفظ البيانات ",
					TextColor = Color.FromHex ("#FFFFFF"),
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Button)),
					BackgroundColor = Color.FromHex ("#FFA4C1"),
					BorderColor = Color.FromHex ("#FFA4C1"),
					HeightRequest = 50,
				};
				
				saveNameButton.Clicked += (sender, e) => {
					if(!Locked){
						Locked = true;
						if (!string.IsNullOrWhiteSpace (nameEntry.Text)) {
							pbcareApp.u.name = nameEntry.Text;
							pbcareApp.Database.update_UserName (nameEntry.Text);
							Navigation.PopAsync ();
							DisplayAlert ("تـــم","تغيير الاسم إلى   "+nameEntry.Text ,"موافق");
		
						} else {
							DisplayAlert ("خطأ", "لم يتم إدخال أي اسم", "إلغاء");
							Locked = false ;
						}
					}
				};


				this.Content = new ScrollView {
					Content = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Padding = 20,
						Children = { yourname, nameEntry, saveNameButton, CancelButton }
					}
				};
				// ------------ Setting Cell Number 2
			} else if (selectedSetting.number == 2) {
				var yourPass = new Label {
					Text = "كلمة المرور : ",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.End,
					TextColor = Color.White,
				};
				var confYourPass = new Label {
					Text = "تأكيد كلمة المرور",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.End,
					TextColor = Color.White
				};
				var passwordEntry = new Entry1 {	
					Placeholder = "أدخل كلمة المرور هنا",
					PlaceholderColor = Color.White,
					TextColor = Color.FromHex("#5069A1"),
					IsPassword = true
				};
				var passConfirm = new Entry1 { 
					Placeholder = " تأكيد كلمة المرور",
					PlaceholderColor = Color.White,
					TextColor = Color.FromHex("#5069A1"),
					IsPassword = true
				};
				var savePassButton = new Button {
					Text = "حفظ البيانات",
					TextColor = Color.FromHex ("#FFFFFF"),
					FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Button)),
					BackgroundColor = Color.FromHex ("#FFA4C1"),
					BorderColor = Color.FromHex ("#FFA4C1"),
					HeightRequest = 50,
				};
	
				savePassButton.Clicked += (sender, e) => {
					if(!Locked){
						Locked = true;
						if (!string.IsNullOrWhiteSpace (passwordEntry.Text) && passConfirm.Text.Equals (passwordEntry.Text)) {
							pbcareApp.Database.update_Password (passwordEntry.Text);
							DisplayAlert (" تم", " تغيير كلمة المرور ", "موافق");
							Navigation.PopAsync ();

						} else if (passwordEntry.Text != passConfirm.Text) {
							DisplayAlert ("خطأ", "كلمة المرور غير متطابقة", "إلغاء");
							Locked = false ;
						} else {
							DisplayAlert ("خطأ", "كلمة المرور غير متطابقة", "إلغاء");
							Locked = false ;
						}
					}
				};

				this.Content = new ScrollView {
					Content = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Padding = 20,
						Children = { yourPass, passwordEntry, confYourPass, passConfirm, savePassButton, CancelButton }
					}
				};
				// ------------ Setting Cell Number 4
			} else if (selectedSetting.number == 4) {
				
				Image i = new Image{ 
					Source= "mainBLogo2.png"
				};
				var Copyright1 = new Label {
					Text = "Prgnancy & Baby care application allows mothers to make sure that their health states during pregnancy period are fine. It will be based on the information of the normal pregnancy that every woman should go through.These information include aspects of the fetus development every week, and a general health education about every stage of pregnancy. The application contains also calculation of the due date, reminders of the important events, such as vaccination for child in a particular time that will be defined directly through the application itself. Calculation of vaccination appointment is based on birthday of the child. The application also allows a mother to follow-up the natural status from the birth to 1 year old, which will be helpful in observing the growth of the baby. In addition, the application can alarm the mother if her child came out of bedroom.",
					FontSize = Device.GetNamedSize(NamedSize.Small,typeof(Label)),
					HorizontalOptions = LayoutOptions.Center,
					TextColor = Color.White
				};
				var Copyright2 = new Label {
					Text = "(C) 2016 Ibrahim Alghamdi and Saud AlQarni ALL RIGHTS RESERVED",
					HorizontalOptions = LayoutOptions.Center,
					TextColor = Color.White,
					FontSize = Device.GetNamedSize(NamedSize.Micro,typeof(Label)),
				};
				this.Content = new ScrollView {
					Content = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Padding = 15,
						Spacing = 20,
						Children = { i , Copyright1 , Copyright2}
					}
				};
			} 
		}
	}

}
