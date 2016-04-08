using System;

using Xamarin.Forms;

namespace pbcare
{
	public class AddPregnancyPage : ContentPage
	{
		

		public AddPregnancyPage ()
		{
			this.Title = "إضافة حمل";
			BackgroundImage = "mainPB.jpg";

			Label OptionText = new Label {
				Text = "أدخلي تاريخ الولادة",
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var dueDate = new DatePicker {
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Button CalMyDate = new Button {
				Text = "حاسبة الحمل", 
				TextColor = Color.Red, HorizontalOptions = LayoutOptions.Center,
				Font = Font.SystemFontOfSize (NamedSize.Default), BorderWidth = 1, BorderColor = Color.Red

			};
			CalMyDate.Clicked += (object sender, EventArgs e) => Navigation.PushAsync (new CalMyDueDate ());

			Button AddDueDate = new Button {
				Text = " إضافة", 
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
					DisplayAlert ("خطأ", "يجب أن يكون موعد الولادة المتوقع صحيحاً", "تم");
				} else {
					pbcareApp.FinaldueDate = dueDate.Date; /* Save data for farther use */
					int CurrentWeek = pbcareApp.CurrentWeek(dueDate.Date); // for testing
					//  convert date to formatted string for DB 
					DueDateText = dueDate.Date.ToString("ddMMyyyy"); 
					// convert date to string for display 
					int y = dueDate.Date.Year, m = dueDate.Date.Month, d = dueDate.Date.Day;
					string DueDateDisplay = d + "/" + m + "/" + y; 

					// the result from [AddPregnancyToDB] method will return numbers, each one has a meaning
					int result = pbcareApp.Database.AddPregnancyToDB (pbcareApp.u.Email,DueDateText );
					if (result == -1) {
						DisplayAlert ("خطأ", "خطأ غير معروف", "تم");
					} else if (result == 0) {
						Navigation.PopAsync ();
						DisplayAlert ("خطأ", "المستخدم غير مسجل مسبقاً", "تم");

					} else if (result == 1) {
						Navigation.PopAsync ();
						DisplayAlert ("خطأ", "يوجد لديكي حمل مسبق - لتغيير تاريخ الحمل من الإعدادات", "تم");

					}  else if (result == 99) { /* SUCCESSFUL */
						Navigation.PopAsync ();
						DisplayAlert ("", "موعدك الولادة المتوقع : " + DueDateDisplay+" \nأنتي الآن في الأسبوع الـ "+CurrentWeek, "تم");
					

					} else {
						Navigation.PopAsync ();
						DisplayAlert ("خطأ", "خطأ غير معروف", "تم");

					}
				}
			};
				
			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.Center, Padding = 20,
				Children = {
					CalMyDate,
					OptionText,
					dueDate,
					AddDueDate
				}
			};

		}

	}
}