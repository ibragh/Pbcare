using System;

using Xamarin.Forms;

namespace pbcare
{
	public class CalMyDueDate : ContentPage
	{
		public CalMyDueDate ()
		{

			var dueDate = new DatePicker {
				Format= "D",
				VerticalOptions = LayoutOptions.Center
			};
			Button Calculate = new Button {
				Text = "Calculate",
				BorderWidth = 1,
				BorderColor = Color.Red,
				HorizontalOptions = LayoutOptions.Center
			};
			Label MyDueDate = new Label {
				Text = "",
				HorizontalOptions = LayoutOptions.Center,
				TextColor=Color.Blue
			};
			Calculate.Clicked += delegate {
				int y=dueDate.Date.Year, m=dueDate.Date.Month, d=dueDate.Date.Day;
				MyDueDate.Text = d+"/"+m+"/"+y;
				DisplayAlert ("Success", "Your Due date is " + MyDueDate.Text, "Done");
				Navigation.PopToRootAsync();

			};
			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.Center, Padding=20 ,
				Children = {
					new Label { Text = "First day of my last period " ,TextColor=Color.Green},
					dueDate,
					Calculate,
					MyDueDate,
					new Label { Text = "\nThis is how most healthcare providers calculate your due date.", 
								TextColor=Color.Red}
				}
			};
		}
	}
}


