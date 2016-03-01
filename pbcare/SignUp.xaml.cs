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
		 void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			string Email = emailEntry.Text;
			string pwd = passwordEntry.Text;
			string pwdCon = passwordConfirmEntry.Text;
			string name = usernameEntry.Text;
			if (string.IsNullOrWhiteSpace (Email) || string.IsNullOrWhiteSpace (pwd) || string.IsNullOrWhiteSpace (pwdCon) || string.IsNullOrWhiteSpace (name)) {
				messageSignUp.Text = "1";
			} else if (!Email.Contains ("@")) {
				messageSignUp.Text = "2";
			} else if (!pwd.Equals(pwdCon)) {
				messageSignUp.Text = "3";
			} else {
				if (pbcareApp.Database.signup (Email, pwd, name)) {
					pbcareApp.IsUserLoggedIn = true;
					pbcareApp.MyNavigation.PopModalAsync ();
					messageSignUp.Text = string.Empty;
				} else {
					messageSignUp.Text = "4";
					messageSignUp.TextColor = Color.Red;
					passwordEntry.Text = string.Empty;
				}

			}
			}
		}

}
