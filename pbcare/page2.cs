using System;

using Xamarin.Forms;

namespace pbcare
{
	public class page2 : ContentPage
	{
		public page2 ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


