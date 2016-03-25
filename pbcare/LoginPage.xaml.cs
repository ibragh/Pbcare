using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace pbcare
{
	public partial class LoginPage : ContentPage
	{
		
		public LoginPage ()
		{
			InitializeComponent ();
		}
		void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new SignUpPage ());

		}
		void OnLoginButtonClicked (object sender, EventArgs e)
		{
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
		}

	}

}

