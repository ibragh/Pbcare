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
				messageSignUp.Text = "please fill all fields";
			} else if (!Email.Contains ("@")) {
				messageSignUp.Text = "please type your email correctly";
			} else if (!pwd.Equals(pwdCon)) {
				messageSignUp.Text = "password is not matched";
			} else {
				if (pbcareApp.Database.signup (Email, pwd, name)) {
					pbcareApp.IsUserLoggedIn = true;
					pbcareApp.MyNavigation.PopModalAsync ();
					messageSignUp.Text = string.Empty;
					pbcareApp.u.Email = Email;
					pbcareApp.u.name = name;
				} else {
					messageSignUp.Text = "Email is registered";
					passwordEntry.Text = string.Empty;
				}

			}
		}
	}

}
