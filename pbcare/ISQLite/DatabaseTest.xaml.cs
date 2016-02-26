using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace pbcare
{
	public partial class DatabaseTest : ContentPage
	{
		private int updateID = 0;

		public DatabaseTest ()
		{
			InitializeComponent ();
		}
		public DatabaseTest (int id)
		{
			InitializeComponent ();
			var user = pbcareApp.DB.getUser(id);
			Username.Text = user.Username;
			Email.Text = user.Email;
			Password.Text = user.Password;
			updateID = id;
		}
		private void Clear(){
			Username.Text = Email.Text = Password.Text = String.Empty;
		}
		public void onSave(object o, EventArgs e){

			User user = new User ();

			user.Username = Username.Text;
			user.Password = Password.Text;
			user.Email = Email.Text;
			user.ID = updateID;
			Clear ();

			pbcareApp.DB.saveUser (user);
			Navigation.PushAsync (new BabyPage ());
		}

	}
}

