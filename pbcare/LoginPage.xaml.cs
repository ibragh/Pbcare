using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace pbcare
{
	public partial class LoginPage : ContentPage
	{
		//static List<User> UsersList = new List<User>();
		public LoginPage ()
		{
			InitializeComponent ();
		}
		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SignUp ());

		}

		async void OnLoginButtonClicked (object sender, EventArgs e)
		{
			var user = new User() {
				Email = emailEntry.Text,
				Password = passwordEntry.Text
			};
		

			var isValid = AreCredentialsCorrect (user);
			if (isValid) {
				pbcareApp.IsUserLoggedIn = true;
				Navigation.InsertPageBefore (new MyPage (), this);
				await Navigation.PopAsync ();
				messageLogin.Text = string.Empty;
			} else {
				messageLogin.Text = "فشل تسجيل الدخول";
				messageLogin.TextColor = Color.Red;
				passwordEntry.Text = string.Empty;
			}
		}
		bool AreCredentialsCorrect (User user)
		{
			return user.Email == "a" && user.Password == "a";
		}
	}
}

