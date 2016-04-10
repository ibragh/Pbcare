using System;

using Xamarin.Forms;

namespace pbcare
{
	public class LogInPage : ContentPage
	{
		public LogInPage ()
		{
			BackgroundImage = "mainB.png";

			var emailEntry = new Entry1
			{ 
				Placeholder = "البريد الإلكتروني",
				TextColor = Color.FromHex("#5069A1"),
				PlaceholderColor = Color.FromHex("#5069A1"),
				WidthRequest = 30 ,
				AnchorX = 100
			};

			var passwordEntry = new Entry1{
				Placeholder = "كلمة المـــرور",
				TextColor = Color.FromHex("#5069A1"),
				PlaceholderColor = Color.FromHex("#5069A1"),
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
				VerticalOptions = LayoutOptions.EndAndExpand,
				BackgroundColor = Color.Transparent, // Color.FromHex("#5069A1"),
				BorderColor = Color.Transparent, // Color.FromHex("#5069A1"),
				HeightRequest = 33,
			};

			sinUpButton.Clicked += (sender, e) => {
				Navigation.PushAsync (new SignUpPage ());
			};
			Image i = new Image{ 
				Source= "mainBLogo.png"};

			var LoginButton = new Button {
				Text = "دخــول",
				TextColor = Color.FromHex("#E2E2E2"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#5069A1"),
				BorderColor = Color.FromHex("#5069A1"),
				HeightRequest = 47 ,
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
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = new Thickness (30, 60, 30, 0),
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Children = {
							i,emailEntry, passwordEntry,

							new StackLayout {
								Children = {
									LoginButton, messageLogin, 

									new StackLayout{
									//VerticalOptions = LayoutOptions.EndAndExpand,
										Padding = new Thickness (0, 60, 0, 0),
										Children = {
											sinUpButton ,
									}
								}
							}
						}
					}
				}
					
			};
		}

	}
}


