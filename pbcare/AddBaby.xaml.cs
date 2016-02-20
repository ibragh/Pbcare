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
			var child = new Child (childName.Text , 'M');
			pbcareApp.u.MyChilren.Add (child);
			Navigation.PopAsync ();

		}

		public void saveChildCancled(object sender , EventArgs e){
			Navigation.PopAsync ();
		}
	}
}

