﻿using System;

using Xamarin.Forms;

namespace pbcare
{
	public class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			Title = "مستخدم جديــد";
			BackgroundColor = Color.FromRgb (94, 196, 225);
			var newUser = new Label {
				Text = "مستخدم جديد",
				TextColor = Color.FromHex("#5069A1"),
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize(NamedSize.Large,typeof(Label)),
				HorizontalOptions = LayoutOptions.Center

			};
			var NameLabel = new Label {
				Text = "اسمـــك ",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
				HorizontalOptions = LayoutOptions.End
			};

			var EmailLabel = new Label {
				Text = "بريدك الإلكتروني",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
				HorizontalOptions = LayoutOptions.End

			};

			var PassLabel = new Label {
				Text = "كلمة المرور",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
				HorizontalOptions = LayoutOptions.End

			};

			var ConfirmPassLabel = new Label {
				Text = "تأكيد كلمة المرور",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
				HorizontalOptions = LayoutOptions.End

			};
			//===========================================================================
			var usernameEntry = new Entry1 {
				TextColor = Color.FromHex("#5069A1"),
			};

			var emailEntry = new Entry1 {
				TextColor = Color.FromHex("#5069A1"),

			}; 

			var passwordEntry = new Entry1 {
				TextColor = Color.FromHex("#5069A1"),
				IsPassword = true
			}; 

			var passwordConfirmEntry = new Entry1 {
				TextColor = Color.FromHex("#5069A1"),
				IsPassword = true
			}; 

			var messageSignUp = new Label {
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var SignUpButton = new Button {
				Text = "تسجيل و دخول ",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 50 ,
			};

			SignUpButton.Clicked += (sender, e) => {

				string Email = emailEntry.Text;
				string pwd = passwordEntry.Text;
				string pwdCon = passwordConfirmEntry.Text;
				string name = usernameEntry.Text;
				if (string.IsNullOrWhiteSpace (Email) || string.IsNullOrWhiteSpace (pwd) ||
					string.IsNullOrWhiteSpace (pwdCon) || string.IsNullOrWhiteSpace (name)) {
					messageSignUp.Text = "فضلاً املأ الفراغات"; // please fill all fields
				} else if (!Email.Contains ("@")) {
					messageSignUp.Text = "فضلاً .. تأكد من كتابة الإيميل بشكل صحيح"; // please .. type your Email correctly
				} else if (!pwd.Equals (pwdCon)) {
					messageSignUp.Text = "كلمة المرور غير متطابقة"; // Password not matched
				} else {
					int result = pbcareApp.Database.add_User (Email, pwd, name) ;
					if (result == 1) {
						pbcareApp.u.Email = Email;
						pbcareApp.u.name = name;
						pbcareApp.u.isPregnant = 0 ;
						pbcareApp.u.isSensorOn = 1 ;
						pbcareApp.IsUserLoggedIn = true;
						messageSignUp.TextColor = Color.Green;
						messageSignUp.Text = "تم تسجيل الدخول بنجاح"; 
						pbcareApp.Database.User_Loggedin (true);
						Application.Current.MainPage = pbcareApp.GetMainPage();

					} else if (result == 0){
						messageSignUp.Text = "تم التسجيل بنفس الإيميل مسبقاً"; // Email is rigistered // Email is rigistered
						passwordEntry.Text = string.Empty;
					
					}else if (result == 2){
						messageSignUp.Text = "يجــب الاتصال بالانترنت "; // Email is rigistered
						passwordEntry.Text = string.Empty;
					
					} 
				}
			};

			Content = new ScrollView{
				Content = new StackLayout{
					Spacing = 10 ,
					Children = {
						new StackLayout {
							BackgroundColor = Color.FromHex("#FFA4C1"),
							Padding = new Thickness (0, 10),
							Children = {
								newUser
							}
						},
						new StackLayout {
							Padding = 20 ,
							HorizontalOptions = LayoutOptions.FillAndExpand,
							Spacing = 7, 
							Children = {
								NameLabel,
								usernameEntry,
								EmailLabel,
								emailEntry,
								PassLabel,
								passwordEntry,
								ConfirmPassLabel,
								passwordConfirmEntry,
								SignUpButton,
								messageSignUp
							}
						}
					}
				}
			};
		}
	}
}

