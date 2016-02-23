﻿using System;

using Xamarin.Forms;

namespace pbcare
{
	public class AddBaby : ContentPage
	{
		public AddBaby ()
		{

			var childName = new Label {
				Text = "إسم الطفل",
				HorizontalOptions = LayoutOptions.End
			};

			var nameEntry = new Entry {
				Placeholder = " اسم الطفل هنا",

			
			};

			var childGender = new Label {
				Text = "الجنس",
				HorizontalOptions = LayoutOptions.End,
			};

			var gender = new Picker ();
			gender.Title = "إختر الجنس";
			gender.Items.Add ("ذكر");
			gender.Items.Add ("أنثى");


			var childBirthdate = new Label {
				Text = "تاريخ الميلاد",
				HorizontalOptions = LayoutOptions.End,
			};

			var birthdate = new DatePicker ();

			var saveButton = new Button {
				Text = "حفظ البيانات"
			};

			saveButton.Clicked += (sender, e) => {
				if(nameEntry.Text != null && gender.SelectedIndex != -1 ){
					var child = new Child (nameEntry.Text , "M");
					pbcareApp.u.MyChilren.Add (child);
					Navigation.PopAsync ();
				
				}else{
					DisplayAlert("Error" , "Child Information did not completed","Cancel");
				}
			};

			var cancelButton = new Button {
				Text = "إلغاء"
			};

			cancelButton.Clicked += (sender, e) => {
				Navigation.PopAsync ();
			};

			Content = new StackLayout {
				Padding = 20, 
				Children = {
					childName,
					nameEntry,
					childGender,
					gender,
					childBirthdate,
					birthdate,
					saveButton,
					cancelButton
				}
			};
		}
	}
}


