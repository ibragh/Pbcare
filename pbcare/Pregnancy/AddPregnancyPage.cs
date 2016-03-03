using System;

using Xamarin.Forms;

namespace pbcare
{
	public class AddPregnancyPage : ContentPage
	{
		static string FinaldueDate;

		public AddPregnancyPage ()
		{

			Label OptionText = new Label {
				Text = "أدخلي تاريخ الولادة",
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var dueDate = new DatePicker {
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Button CalMyDate = new Button {
				Text = "Calculate my Due date", 
				TextColor = Color.Red, HorizontalOptions = LayoutOptions.Center,
				Font = Font.SystemFontOfSize (NamedSize.Large),

			};
			CalMyDate.Clicked += (object sender, EventArgs e) => Navigation.PushAsync (new CalMyDueDate ());

			Button AddDueDate = new Button {
				Text = " Add Due Date ", 
				TextColor = Color.Blue, HorizontalOptions = LayoutOptions.Center,
				FontSize = 50,
			};


			AddDueDate.Clicked += (sender, e) => {
				int y = dueDate.Date.Year, m = dueDate.Date.Month, d = dueDate.Date.Day;
				FinaldueDate = d + "/" + m + "/" + y;
				int result = pbcareApp.Database.AddPregnancyToDB (pbcareApp.u.Email, FinaldueDate);
				if (result == -1) {
					DisplayAlert ("Error", "Unkown Error -1", "Cancel");
				} else if (result == 0) {
					Navigation.PopAsync ();
					DisplayAlert ("Error", "User is not registered", "Cancel");

				} else if (result == 1) {
					Navigation.PopAsync ();
					DisplayAlert ("Error", "There is Due Date record rigistered, " +
						"If u want to edit u should press 'Edit my due date' Button", "Cancel");

				} else if (result == 2) {
					Navigation.PopAsync ();
					DisplayAlert ("Error", "Please do not leave Due date Empty", "Cancel");

				} else if (result == 99) {
					Navigation.PopAsync ();
					DisplayAlert ("Done", "Your Due date is " + FinaldueDate, "Cancel");
				} else {
					Navigation.PopAsync ();
					DisplayAlert ("Error", "Unkown Error", "Cancel");

				}
			};


			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.Center, Padding = 20,

				Children = {

					OptionText,
					dueDate,
					CalMyDate,
					AddDueDate
				}
			};

		}

	}
}


