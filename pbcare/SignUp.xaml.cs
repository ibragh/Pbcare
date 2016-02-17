using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace pbcare
{
	public partial class SignUp : ContentPage
	{
		public SignUp ()
		{
			InitializeComponent ();
		}
		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			var user = new User () {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text,
				Email = emailEntry.Text
			};

			// Sign up logic goes here

			var signUpSucceeded = AreDetailsValid (user);
			if (signUpSucceeded) {
				var rootPage = Navigation.NavigationStack.FirstOrDefault ();
				if (rootPage != null) {
					pbcareApp.IsUserLoggedIn = true;
					Navigation.InsertPageBefore (new MyPage (), Navigation.NavigationStack.First ());
					await Navigation.PopToRootAsync ();
				}
			} else {
				messageSignUp.Text = "فشل تسجيل الدخول";
				messageSignUp.TextColor = Color.Red;
			}
		}

		bool AreDetailsValid (User user)
		{
			//if (passwordEntry == passwordConfirmEntry)
				return (!string.IsNullOrWhiteSpace (user.Username) && !string.IsNullOrWhiteSpace (user.Password) && !string.IsNullOrWhiteSpace (user.Email) && user.Email.Contains ("@"));
		//	else
			//	return false;
		}

	}
}

