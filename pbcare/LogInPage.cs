using System;

using Xamarin.Forms;

namespace pbcare
{
	public class LogInPage : ContentPage
	{
		public LogInPage ()
		{
			BackgroundColor = Color.FromRgb (94, 196, 225);

			var emailEntry = new Entry1{ 
				Placeholder = "البريد الإلكتروني",
				TextColor = Color.FromHex("#5069A1"),
				PlaceholderColor = Color.FromRgba(255,255,255,225),
				WidthRequest = 30 ,
				AnchorX = 100
			};

			var passwordEntry = new Entry1{
				Placeholder = "كلمة المـــرور",
				TextColor = Color.FromHex("#5069A1"),
				PlaceholderColor = Color.FromRgba(255,255,255,225),
				WidthRequest = 30 ,
			};

			var messageLogin = new Label {
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			var sinUpButton = new Button {
				Text = "مستخدم جديد",
				TextColor = Color.FromHex("#E2E2E2"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.Transparent,
				BorderColor = Color.Transparent
			};

			sinUpButton.Clicked += (sender, e) => {
				Navigation.PushAsync (new SignUpPage ());
			};

			Image i = new Image{ 
				Source= "mainBLogo2.png"
			};

			var empty = new Label {
				HeightRequest = 100
			};

			var LoginButton = new Button {
				Text = "تســـجيل الدخــول",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 40 ,
			};

			LoginButton.Clicked += (sender, e) => {
				string Email = emailEntry.Text;
				string pwd = passwordEntry.Text;

				if (string.IsNullOrWhiteSpace (Email) || string.IsNullOrWhiteSpace (pwd)) {
					messageLogin.Text = "فضلاً  املأ  الفراغات";

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

			Content = new ScrollView{
				
				Content = new StackLayout { 
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness (30, 0, 30, 15),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {
						
						i, empty, emailEntry, passwordEntry, LoginButton,
						new StackLayout {
						Padding = new Thickness (0, 30, 0, 30),
						Children = {
								messageLogin , 
						}
					},

						sinUpButton
				}
				}
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			NavigationPage.SetHasNavigationBar (this, false); 
		}
	}
}


