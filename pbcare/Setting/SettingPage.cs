using System;
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

		public SettingPage ()
		{
			this.Title = "الإعدادات";
			BackgroundColor = Color.FromRgb (94, 196, 225);


			settingList.Add (new settingClass ("تغيير الاسم", 1));
			settingList.Add (new settingClass ("تغيير كلمة المرور", 2));
			settingList.Add (new settingClass ("عن تطبـيقنا",3));

			setting.ItemsSource = settingList;
			setting.ItemTemplate = new DataTemplate (typeof(everyCell));
			setting.BackgroundColor = Color.Transparent;
			setting.SeparatorColor = Color.White;

			setting.ItemTapped += (Sender, Event) => {
				var selceted = (settingClass)Event.Item;
				var settingView = new settingView (selceted);
				Navigation.PushAsync (settingView);

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
			};

			logOutButton.Clicked += OnAlertYesNoClicked;

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (10, 20, 10, 53),
				Children = {  
					setting,
					logOutButton
				}
			};

		}

		async void OnAlertYesNoClicked (object sender, EventArgs e)
		{
			var answer = await DisplayAlert ("تسجيل الخروج ", "هل تريد تأكيد تسجيل الخروج ؟ ", "نعم", "لا");
			if (answer == true) {
				pbcareApp.Database.User_Loggedin (false);
				pbcareApp.IsUserLoggedIn = false; 
				await Navigation.PopToRootAsync ();
				await Navigation.PushModalAsync (new pbcareMainPage ());
			} 
		}

		protected override void OnAppearing (){

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
					if (!string.IsNullOrWhiteSpace (nameEntry.Text)) {
						pbcareApp.u.name = nameEntry.Text;
						pbcareApp.Database.update_UserName (nameEntry.Text);
						Navigation.PopAsync ();
						DisplayAlert ("  تم", "  تغيير الاسم إلى" + nameEntry.Text, "موافق");
	
					} else {
						DisplayAlert ("خطأ", "لم يتم إدخال أي اسم", "إلغاء");
	
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
					if (!string.IsNullOrWhiteSpace (passwordEntry.Text) && passConfirm.Text.Equals (passwordEntry.Text)) {
						pbcareApp.Database.update_Password (passwordEntry.Text);
						DisplayAlert (" تم", " تغيير كلمة المرور ", "موافق");
						Navigation.PopAsync ();

					} else if (passwordEntry.Text != passConfirm.Text) {
						DisplayAlert ("خطأ", "كلمة المرور غير متطابقة", "إلغاء");
	
					} else {
						DisplayAlert ("خطأ", "كلمة المرور غير متطابقة", "إلغاء");
					}
				};

				this.Content = new ScrollView {
					Content = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Padding = 20,
						Children = { yourPass, passwordEntry, confYourPass, passConfirm, savePassButton, CancelButton }
					}
				};
				// ------------ Setting Cell Number 3
			} else if (selectedSetting.number == 2) {

				var Copyright = new Label {
					Text = "This Project is Done By",
					FontSize = 35,
					HorizontalOptions = LayoutOptions.Center,
					TextColor = Color.White
				};
				var Copyright1 = new Label {
					Text = "Saud Alqarni \nIbrahim Alghamdi",
					FontSize = 30,
					HorizontalOptions = LayoutOptions.Center,
					TextColor = Color.White
				};
				var Copyright2 = new Label {
					Text = "2016",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Center,
					TextColor = Color.White
				};
				this.Content = new ScrollView {
					Content = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Padding = 20,
						Children = { Copyright, Copyright1 , Copyright2}
					}
				};
			} else if(selectedSetting.number == 3){
				this.Content = new ScrollView {
					Content = new StackLayout {
						HorizontalOptions = LayoutOptions.Center,
						Padding = 20,
						Children = {
							new Label {
								Text = "معـــلومات عن  التطبيق ",
								TextColor = Color.White,
								FontSize = Device.GetNamedSize(NamedSize.Large ,typeof(Label))
							}
						}
					}
				};
			}
		}
	}

}
