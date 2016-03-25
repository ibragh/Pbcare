using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace pbcare
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}
		void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			string Email = emailEntry.Text;
			string pwd = passwordEntry.Text;
			string pwdCon = passwordConfirmEntry.Text;
			string name = usernameEntry.Text;
			if (string.IsNullOrWhiteSpace (Email) || string.IsNullOrWhiteSpace (pwd) || 
				string.IsNullOrWhiteSpace (pwdCon) || string.IsNullOrWhiteSpace (name)) {
				messageSignUp.Text = "فضلاً املأ الفراغات"; // please fill all fields
			} else if (!Email.Contains ("@")) {
				messageSignUp.Text = "فضلاً .. تأكد من كتابة الإيميل بشكل صحيح"; // please .. type your Email correctly
			} else if (!pwd.Equals(pwdCon)) {
				messageSignUp.Text = "كلمة المرور غير متطابقة"; // Password not matched
			} else {
				if (pbcareApp.Database.signup (Email, pwd, name)) {
					pbcareApp.IsUserLoggedIn = true;
					messageSignUp.TextColor = Color.Green;
					messageSignUp.Text = "تم تسجيل الدخول بنجاح"; 
					pbcareApp.MyNavigation.PopModalAsync ();
					pbcareApp.u.Email = Email;
					pbcareApp.u.name = name;
					pbcareApp.Database.InsertUserLoggedin (true);
				} else {
					messageSignUp.Text = "تم التسجيل بنفس الإيميل مسبقاً"; // Email is rigistered
					passwordEntry.Text = string.Empty;
				}

			}
		}
	}

}
