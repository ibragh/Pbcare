using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace pbcare
{
	public partial class BabyPage : ContentPage
	{
		public BabyPage ()
		{
			InitializeComponent ();
		}

		public void addBaby(object sender, EventArgs e){
			Navigation.PushAsync (new AddBaby ());
			}
		}
	}

				

