using System;

using Xamarin.Forms;

namespace pbcare
{
	public class page1 : ContentPage
	{
		public page1 ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


