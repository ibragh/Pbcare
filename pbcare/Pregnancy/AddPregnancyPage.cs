using System;

using Xamarin.Forms;

namespace pbcare
{
	public class AddPregnancyPage : ContentPage
	{
		

		public AddPregnancyPage ()
		{
			this.Title = "إضافة حمل";
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
				Font = Font.SystemFontOfSize (NamedSize.Default), BorderWidth = 1, BorderColor = Color.Red

			};
			CalMyDate.Clicked += (object sender, EventArgs e) => Navigation.PushAsync (new CalMyDueDate ());

			Button AddDueDate = new Button {
				Text = " Add Due Date ", 
				TextColor = Color.Blue, HorizontalOptions = LayoutOptions.Center,
				FontSize = 30, BorderWidth = 1, BorderColor = Color.Blue
			};
			String DueDateText;
			AddDueDate.Clicked += (sender, e) => {
				/* check if data is within a valid pregnancy date 
				 * not before a ten mothns from the current date ,
				 * AND not after ten months from the current date 
				 */
				if (dueDate.Date < DateTime.Now.AddDays (-1) || dueDate.Date > DateTime.Now.AddMonths (11)) {
					Navigation.PopAsync ();
					DisplayAlert ("Error", "Please set a valid Pregnancy Daue Date Or " +
					"Use the Due Date Calculator", "OK");
				} else {
					pbcareApp.FinaldueDate = dueDate.Date; /* Save data for farther use */
					int y = dueDate.Date.Year, m = dueDate.Date.Month, d = dueDate.Date.Day;
					DueDateText = d + "/" + m + "/" + y; /* convert date to string for display */
					// the result from [AddPregnancyToDB] method will return numbers, each one has a meaning
					int result = pbcareApp.Database.AddPregnancyToDB (pbcareApp.u.Email, DueDateText);
					if (result == -1) {
						DisplayAlert ("Error", "Unkown Error -1", "OK");
					} else if (result == 0) {
						Navigation.PopAsync ();
						DisplayAlert ("Error", "User is not registered", "OK");

					} else if (result == 1) {
						Navigation.PopAsync ();
						DisplayAlert ("Error", "There is Due Date record rigistered, " +
						"If u want to edit u should press 'Edit my due date' Button", "OK");

					} else if (result == 2) {
						Navigation.PopAsync ();
						DisplayAlert ("Error", "Please do not leave Due date Empty", "OK");

					} else if (result == 99) { /* SUCCESSFUL */
					
						Navigation.PopAsync ();
						DisplayAlert ("Success", "Your Due date is " + DueDateText, "Done");
					

					} else {
						Navigation.PopAsync ();
						DisplayAlert ("Error", "Unkown Error", "OK");

					}
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