using System;

using Xamarin.Forms;

namespace pbcare
{
	public class FetusWeeklyTry : ContentPage
	{
		public FetusWeeklyTry (int i)
		{
			var a = new Label {
				Text= "AAA Test ",
				TextColor = Color.Blue
			};
			
			var l = new Label {
				TextColor = Color.Red
			};
			if (i == 1) {
				l.Text += "you pressed 1";
			} else if (i == 2) {
				l.Text += "you pressed 2";
			} else {
				l.Text += "you pressed somthing else";
			}
			Content = new StackLayout { 
				Children = {
					a,
					l
				}
			};
		}
	}
}


