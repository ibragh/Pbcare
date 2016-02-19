using System;

using Xamarin.Forms;

namespace pbcare
{
	public class WebsitePage : ContentPage
	{
		public WebsitePage ()
		{
			this.Title = "المنتدى";
			var listView = new ListView {ItemsSource = new string[] {
					"ِAAA ", " BB", "CC", "DD"
				},


			};

			Content = new StackLayout {
				Children = {  
					listView   
				}
			};
		}
	}
}


