using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public partial class AddBaby : ContentPage
	{
		public AddBaby ()
		{
			InitializeComponent ();
		}

		public void saveChildInfo(object sender , EventArgs e){
			var child = new Child ();
			child.name = childName.Text;
			//child.birthDate = birthdate;
			child.gender = "m";
			s.Text = child.name +" "+child.gender; 
			s.TextColor = Color.Red;
		}

		public void saveChildCancled(object sender , EventArgs e){
			Navigation.PopAsync ();
		}

	}
}

