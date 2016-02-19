using System;

using Xamarin.Forms;

namespace pbcare
{
	public class Setting : ContentPage
	{
		public Setting ()
		{
			this.Title = "الظبط";
			var listView = new ListView {ItemsSource = new string[] {
					"saud ", " Ibra", "buhari", "Ahmed"
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


