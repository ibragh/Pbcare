using System;

using Xamarin.Forms;

namespace pbcare
{
	public class AddBaby : ContentPage
	{
		public AddBaby ()
		{
			Title = "إضــافة طــفل ";
			BackgroundImage = null;

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
				if (!string.IsNullOrWhiteSpace (nameEntry.Text) && gender.SelectedIndex != -1) {
					Child baby = new Child{
						mother = pbcareApp.u.Email,
						ChildName = nameEntry.Text,
						birthDate = birthdate.Date.ToString("ddMMyyyy") ,
						gender = gender.Items [gender.SelectedIndex]
					};
					bool check = pbcareApp.Database.AddChildToDB(baby);

					if (check) {
						pbcareApp.Database.insertChildVaccinations(baby.ChildName);
						Navigation.PopAsync ();
					} else {
						DisplayAlert ("خطأ", "معلومات الطفل غير كاملة", "إلغاء");
					}
				} else {
					DisplayAlert ("خطأ", "معلومات الطفل غير كاملة22", "إلغاء");
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


