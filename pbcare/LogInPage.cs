using System;

using Xamarin.Forms;

namespace pbcare
{
	public class LogInPage : ContentPage
	{
		public LogInPage ()
		{
			BackgroundImage = "B14.png";

			var EmailLabel = new Label { 
				Text= "البريد الإلكـــتروني ",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Black,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

			};

			var emailEntry = new Entry{ 
				Placeholder = "email@abc.abc",
			};

			var PasswordLabel = new Label { 
				Text= "كلـــمة المــرور",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Black,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
			};

			var passwordEntry = new Entry{
				Placeholder = "كلمة المـــرور",
			};

			var messageLogin = new Label {
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var sinUpButton = new Button {
				Text = "مستخدم جديد",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex("#00004c"),
				HorizontalOptions = LayoutOptions.Center
			};

			sinUpButton.Clicked += (sender, e) => {
				Navigation.PushAsync (new SignUpPage ());
			};

			var LoginButton = new Button {
				Text = "دخــول",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex("#004c00"),
				HorizontalOptions = LayoutOptions.Center
			};

			LoginButton.Clicked += (sender, e) => {
				string Email = emailEntry.Text;
				string pwd = passwordEntry.Text;

				if (string.IsNullOrWhiteSpace (Email) || string.IsNullOrWhiteSpace (pwd)) {
					messageLogin.Text = "فضلاً املأ الفراغات";
				} else if (!Email.Contains ("@")) {
					messageLogin.Text = "فضلاً .. تأكد من كتابة الإيميل بشكل صحيح";
				} else if (pbcareApp.Database.checkLogin (Email, pwd)) {
					messageLogin.TextColor = Color.Green;
					messageLogin.Text = "تم تسجيل الدخول بنجاح"; 
					pbcareApp.IsUserLoggedIn = true;
					pbcareApp.MyNavigation.PopModalAsync ();
					pbcareApp.u.Email = Email;
					pbcareApp.Database.InsertUserLoggedin (true);
				} else {
					messageLogin.Text = "فشل تسجيل الدخول .. الرجاء ال";

				}
			};
				
			Content = new StackLayout { 
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness (15, 5, 5, 15),

				Children = {
					EmailLabel, emailEntry, PasswordLabel, passwordEntry,

					new StackLayout {
						Padding = new Thickness (15, 5, 5, 15),
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Children = {
							sinUpButton , LoginButton
						}
					},

					messageLogin
				}
			};
		}

	}
}


