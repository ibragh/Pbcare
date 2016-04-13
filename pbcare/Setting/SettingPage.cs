using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class SettingPage : ContentPage
	{
		

		public SettingPage ()
		{
			this.Title = "الإعدادات";


			ListView setting = new ListView {
				RowHeight = 50  
			};
					
			setting.ItemsSource = getSettingList ();
			setting.ItemTemplate = new DataTemplate (typeof(TextCell));
			setting.BackgroundColor = Color.Transparent ;
			setting.ItemTemplate.SetBinding (TextCell.TextProperty, "Name");
			setting.BackgroundColor = Color.Transparent;

			setting.ItemSelected += (Sender, Event) => {
				var selceted = (everyCell)Event.SelectedItem;
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
				BackgroundColor = Color.Red ,
				VerticalOptions = LayoutOptions.End ,
				FontAttributes = FontAttributes.Bold ,
				BorderRadius = 30 ,
				BorderWidth = 4
			};

			logOutButton.Clicked += LogOutButton_Clicked;

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10 ,20 , 10 , 53) ,
				Children = {  
					setting,
					logOutButton
				}
			};

		}

		void LogOutButton_Clicked (object sender, EventArgs e)
		{
			//var a = LogoutAlert ();
			//if (a) {
				pbcareApp.Database.InsertUserLoggedin (false);
				Navigation.PushModalAsync (new LogoutPage ());
		//	} else {
		//	}


		}
		//async void LogoutAlert(){

			//var MyAlert = await DisplayAlert ("Notice", "Confirm logout", "Ok", "Cancel");
			//return MyAlert;
	//	}

		public List<everyCell> getSettingList ()
		{
			
	
			var yourname = new Label {
				Text = "اسمك : ",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.End,
			};

			var nameEntry = new Entry { Placeholder = "أدخل اسمك هنا" ,
				BackgroundColor = Color.Pink
			};
				
			var yourPass = new Label {
				Text = "كلمة المرور : ",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.End,
			};

			var passwordEntry = new Entry {	Placeholder = "أدخل كلمة المرور هنا" };
			var passConfirm = new Entry { Placeholder = " تأكيد كلمة المرور" };
			var saveNameButton = new Button { Text = " حفظ البيانات " };

			saveNameButton.Clicked += (sender, e) => {
				if (!nameEntry.Text.Equals (null)) {
					pbcareApp.u.name = nameEntry.Text;
					Navigation.PopAsync ();
					DisplayAlert ("  تم", "  تغيير الاسم إلى" + nameEntry.Text, "موافق");

				} else {
					DisplayAlert ("خطأ", "لم يتم إدخال أي اسم", "إلغاء");

				}
			};

			var savePassButton = new Button {
				Text = "حفظ البيانات"
			};

			savePassButton.Clicked += (sender, e) => {
				if (!passwordEntry.Text.Equals (null) && passConfirm.Text.Equals (passwordEntry.Text)) {
					//pbcareApp.u.Password = passwordEntry.Text;
					Navigation.PopAsync ();
					DisplayAlert (" تم", " تغيير كلمة المرور ", "موافق");

				} else if (passwordEntry.Text != passConfirm.Text) {
					DisplayAlert ("خطأ", "كلمة المرور غير متطابقة", "إلغاء");

				} else if (passConfirm.Text.Equals (null) && passwordEntry.Text.Equals (null)) {
					DisplayAlert ("خطأ", "لم يتم إدخال كلمة مرور", "إلغاء");
				}

			};

			var CancelNameButton = new Button {
				Text = "إلغاء",

			};

			CancelNameButton.Clicked += (sender, e) => {
				Navigation.PopAsync ();
			};

			var CancelPassButton = new Button {
				Text = "إلغاء",

			};

			CancelPassButton.Clicked += (sender, e) => {
				Navigation.PopAsync ();
			};
			return new List<everyCell> {
				// frist cell " change name " 
				new everyCell {
					Name = "تغيير الاسم",
					View = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Children = { yourname, nameEntry, saveNameButton, CancelNameButton }
					}
				},

				// second cell " change password "
				new everyCell {
					Name = "تغيير كلمة المرور",
					View = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Children = { yourPass, passwordEntry, passConfirm, savePassButton, CancelPassButton }
					}
				},


			};


		}

		protected override void OnAppearing()
		{
			
		}
	}

	//--------------------------------------------------------------
	public class everyCell
	{
		public string Name { get; set; }

		public View View { get; set; }

	}

	//-------------------------------------------------------------

	public class settingView : ContentPage
	{
		public settingView (everyCell sample)
		{
			Title = sample.Name;
			BackgroundColor = Color.White;
			sample.View.HorizontalOptions = LayoutOptions.FillAndExpand;
			Content = new StackLayout {
				Padding = 20,
				Orientation = StackOrientation.Vertical,
				Children = { sample.View }
			};
		}
	}
}



