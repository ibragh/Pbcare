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
			 Navigation.PushAsync (new SignUp ());

		}

		 void OnLoginButtonClicked (object sender, EventArgs e)
		{
		
			string Email = emailEntry.Text;
			string pwd = passwordEntry.Text;

			if (pbcareApp.Database.checkLogin (Email, pwd)) {
				pbcareApp.IsUserLoggedIn = true;
				pbcareApp.MyNavigation.PopModalAsync ();
				messageLogin.Text = string.Empty;
			} else {
				messageLogin.Text = "فشل تسجيل الدخول";
				messageLogin.TextColor = Color.Red;
				passwordEntry.Text = string.Empty;
			}

		}

	}
}

